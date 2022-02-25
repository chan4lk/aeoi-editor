using Microsoft.Extensions.Logging;
using System.Collections;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AEOI.Editor.Web.Shared
{
    public class ElementValidationService
    {
        //Referred Url
        //https://docs.microsoft.com/en-us/dotnet/api/system.xml.schema.xmlschemavalidator.validateelement?view=net-6.0#system-xml-schema-xmlschemavalidator-validateelement(system-string-system-string-system-xml-schema-xmlschemainfo)

        private readonly HttpClient client;
        private readonly ILogger<ElementValidationService> logger;

        private List<string> result = new List<string>();
        private XmlSchema typesSchema;
        private XmlSchema schema;
        private string nameSpaceUri = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport";

        private XmlSchemaInfo schemaInfo = new XmlSchemaInfo();
        private object dateTimeGetterContent;

        public ElementValidationService(HttpClient client, ILogger<ElementValidationService> logger)
        {
            this.client = client;
            this.logger = logger;
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

        public async Task<List<string>> Validate(string elementName, AEOIUKSubmissionFIReport report)
        {
            try
            {
                Stopwatch sw = Stopwatch.StartNew();

                result.Clear();
                await LoadSchema();

                XmlDocument xmlDoc = SerializeToXml(report);

                // The XmlSerializer object.
                //XmlSerializer serializer = new XmlSerializer(typeof(AEOIUKSubmissionFIReport));
                //AEOIUKSubmissionFIReport books = (AEOIUKSubmissionFIReport)serializer.Deserialize(reader);

                // XMLDocument to XMLReader conversion
                XmlReader reader = new XmlNodeReader(xmlDoc);

                // The XmlSchemaSet object containing the schema used to validate the XML document.
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add(typesSchema);
                schemaSet.Add(schema);

                // The XmlManager object used to handle namespaces.
                XmlNamespaceManager manager = new XmlNamespaceManager(reader.NameTable);

                // Assign a ValidationEventHandler to handle schema validation warnings and errors.
                XmlSchemaValidator validator = new XmlSchemaValidator(reader.NameTable, schemaSet, manager, XmlSchemaValidationFlags.None);
                validator.ValidationEventHandler += new ValidationEventHandler(SchemaValidationEventHandler);

                // Initialize the XmlSchemaValidator object.
                validator.Initialize();
                logger.LogError("Validation Initialized");


                // Validate the element, verify that all required attributes are present
                // and prepare to validate child content.
                validator.ValidateElement("AEOIUKSubmissionFIReport", nameSpaceUri, null);
                validator.ValidateEndElement(null);

                validator.GetUnspecifiedDefaultAttributes(new ArrayList());
                validator.ValidateEndOfAttributes(null);

                // Get the next expected element in the AEOIUKSubmissionFIReport context.
                XmlSchemaParticle[] particles = validator.GetExpectedParticles();
                XmlSchemaElement nextElement;
                foreach (XmlSchemaParticle particle in particles)
                {
                    nextElement = particle as XmlSchemaElement;
                    logger.LogInformation("Expected Element: '{0}'", nextElement.Name);
                }

                // Validate the MessageData Element
                validator.ValidateElement("MessageData", nameSpaceUri, null);
                validator.ValidateEndElement(null);

                // Get the next exptected element in the AEOIUKSubmissionFIReport context.
                particles = validator.GetExpectedParticles();
                nextElement = particles[0] as XmlSchemaElement;
                logger.LogInformation("Expected Element: '{0}'", nextElement.Name);

                DisplaySchemaInfo();

                foreach (AEOIUKSubmissionFIReportSubmissionFIReturnAccountData account in report.Submission.FIReturn.AccountData)
                {
                    if (account.Person != null)
                    {
                        validator.ValidateElement("Person", nameSpaceUri, null);
                        // Get the exptected attributes for the Person element.
                        Console.Write("\nExpected attributes: ");
                        XmlSchemaAttribute[] attributes = validator.GetExpectedAttributes();
                        //foreach (XmlSchemaAttribute attribute in attributes)
                        //{
                        //    Console.Write("'{0}' ", attribute.Name);
                        //}
                        if (account.Person.FirstName != null)
                        {
                            validator.ValidateAttribute("FirstName", "", account.Person.FirstName, schemaInfo);
                        }
                        if (account.Person.LastName != null)
                        {
                            validator.ValidateAttribute("LastName", "", account.Person.LastName, schemaInfo);
                        }

                        validator.ValidateAttribute("Address", "", account.Person.FirstName, schemaInfo);

                        DisplaySchemaInfo();
                    }

                }

                // Validate the content of the AEOIUKSubmissionFIReport element.
                validator.ValidateEndElement(null);

                // Close the XmlReader object.
                reader.Close();

                sw.Stop();
                logger.LogInformation("Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError("Validate Failed", ex);
                throw;
            }
        }

        private void DisplaySchemaInfo()
        {
            if (schemaInfo.SchemaElement != null)
            {
                Console.WriteLine("Element '{0}' with type '{1}' is '{2}'",
                    schemaInfo.SchemaElement.Name, schemaInfo.SchemaType, schemaInfo.Validity);
            }
            else if (schemaInfo.SchemaAttribute != null)
            {
                Console.WriteLine("Attribute '{0}' with type '{1}' is '{2}'",
                    schemaInfo.SchemaAttribute.Name, schemaInfo.SchemaType, schemaInfo.Validity);
            }
        }

        private void SchemaValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("\nError: {0}", e.Message);
                    result.Add(e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("\nWarning: {0}", e.Message);
                    break;
            }
        }
    }
}
