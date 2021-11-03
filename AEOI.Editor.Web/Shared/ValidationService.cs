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

        private List<string> result = new List<string>();

        public ValidationService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<string>> Validate(AEOIUKSubmissionFIReport report)
        {

            var byteOfTheFile = await client.GetStreamAsync("Templates/uk_aeoi_submission_v2.0.xsd");
         
            XmlSchema schema = XmlSchema.Read(byteOfTheFile, SchemaValidationHandler);

            Console.WriteLine(schema.SourceUri);

            var doc = SerializeToXml(report);
            var node = doc.FirstChild;

            doc.Schemas.Add(schema);

            doc.Validate(ValidationEventHandler);


            return result;
        }


        private static void SchemaValidationHandler(object sender, ValidationEventArgs e)
        {
            System.Console.WriteLine(e.Message);
        }

        private static void DocumentValidationHandler(object sender, ValidationEventArgs e)
        {
            System.Console.WriteLine(e.Message);
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
                    Console.WriteLine(e.Message);
                }
            }

            result.Add(e.Message);
        }
    }

}
