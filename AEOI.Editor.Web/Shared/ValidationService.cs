using Microsoft.Extensions.Logging;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AEOI.Editor.Web.Shared
{
    public class ValidationService
    {
        private readonly HttpClient client;
        private readonly ILogger<ValidationService> logger;
        private List<string> result = new List<string>();
        private XmlSchema typesSchema;
        private XmlSchema schema;

        public ValidationService(HttpClient client, ILogger<ValidationService> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<List<string>> Validate(AEOIUKSubmissionFIReport report)
        {
            logger.LogInformation("Validate started");

            try
            {
                result.Clear();

                await LoadSchema();

                var doc = SerializeToXml(report);

                doc.Schemas.Add(schema);
                doc.Schemas.Add(typesSchema);

                doc.Schemas.Compile();

                doc.Validate(ValidationEventHandler);
            }
            catch (Exception ex)
            {
                logger.LogError("Validate failed", ex);
                throw;
            }
            

            logger.LogInformation("Validate Completed");


            return result;
        }

        private async Task LoadSchema()
        {
            if (typesSchema == null)
            {
                var typesStream = await client.GetStreamAsync("Templates/isofatcatypes_v1.1.xsd");
                typesSchema = XmlSchema.Read(typesStream, SchemaValidationHandler);

                var byteOfTheFile = await client.GetStreamAsync("Templates/uk_aeoi_submission_v2.0.xsd");
                schema = XmlSchema.Read(byteOfTheFile, SchemaValidationHandler);
            }
        }

        private void SchemaValidationHandler(object sender, ValidationEventArgs e)
        {
            logger.LogInformation(e.Message);
        }

        private void DocumentValidationHandler(object sender, ValidationEventArgs e)
        {
            logger.LogInformation(e.Message);
        }

        public XmlDocument SerializeToXml<T>(T source)
        {
            var document = new XmlDocument();
            var navigator = document.CreateNavigator();

            using (var writer = navigator.AppendChild())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, source);
            }
            return document;
        }

        private void ValidationEventHandler(object? sender, ValidationEventArgs e)
        {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse("Error", out type))
            {
                if (type == XmlSeverityType.Error)
                {
                    logger.LogInformation(e.Message);
                }
            }

            result.Add(e.Message);
        }
    }

}
