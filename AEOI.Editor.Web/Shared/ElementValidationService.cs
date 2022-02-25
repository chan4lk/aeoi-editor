using Microsoft.Extensions.Logging;
using System.Collections;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Diagnostics;

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

        public async Task<List<string>> Validate(string elementName,AEOIUKSubmissionFIReport report)
        {
            try
            {
                Stopwatch sw = Stopwatch.StartNew();

                result.Clear();
                await LoadSchema();

                var xmlDoc = SerializeToXml(report);

                // XMLDocument to XMLReader conversion
                XmlReader reader = new XmlNodeReader(xmlDoc);

                // The XmlSchemaSet object containing the schema used to validate the XML document.
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add(schema);
                schemaSet.Add(typesSchema);
                    
                // The Xml
                // Manager object used to handle namespaces.
                XmlNamespaceManager manager = new XmlNamespaceManager(reader.NameTable);

                // Assign a ValidationEventHandler to handle schema validation warnings and errors.
                XmlSchemaValidator validator = new XmlSchemaValidator(reader.NameTable, schemaSet, manager, XmlSchemaValidationFlags.None);
                validator.ValidationEventHandler += new ValidationEventHandler(SchemaValidationEventHandler);

                // Initialize the XmlSchemaValidator object.
                validator.Initialize();
                logger.LogError("Validation Initialized");

                // Validate the element, verify that all required attributes are present
                // and prepare to validate child content.
                validator.ValidateElement("PersonInformation", "http://hmrc.gov.uk/AEOIUKSubmissionFIReport", null);

                validator.GetUnspecifiedDefaultAttributes(new ArrayList());
                validator.ValidateEndOfAttributes(null);

                // Get the next exptected element in the bookstore context.
                XmlSchemaParticle[] particles = validator.GetExpectedParticles();
                XmlSchemaElement nextElement = particles[0] as XmlSchemaElement;
                logger.LogInformation("Expected Element: '{0}'", nextElement.Name);

                DisplaySchemaInfo();

                // Validate the content of the bookstore element.
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

        static XmlSchemaInfo schemaInfo = new XmlSchemaInfo();
        static object dateTimeGetterContent;

        static object dateTimeGetterHandle()
        {
            return dateTimeGetterContent;
        }

        static XmlValueGetter dateTimeGetter(DateTime dateTime)
        {
            dateTimeGetterContent = dateTime;
            return new XmlValueGetter(dateTimeGetterHandle);
        }

        static void DisplaySchemaInfo()
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

        static void SchemaValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("\nError: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("\nWarning: {0}", e.Message);
                    break;
            }
        }
    }

    [XmlRootAttribute("bookstore", Namespace = "http://www.contoso.com/books", IsNullable = false)]
    public class ContosoBooks
    {
        [XmlElementAttribute("book")]
        public BookType[] Book;
    }

    public class BookType
    {
        [XmlAttributeAttribute("genre")]
        public string Genre;

        [XmlAttributeAttribute("publicationdate", DataType = "date")]
        public DateTime PublicationDate;

        [XmlAttributeAttribute("ISBN")]
        public string Isbn;

        [XmlElementAttribute("title")]
        public string Title;

        [XmlElementAttribute("author")]
        public BookAuthor Author;

        [XmlElementAttribute("price")]
        public Decimal Price;
    }


    public class BookAuthor
    {
        [XmlElementAttribute("name")]
        public string Name;

        [XmlElementAttribute("first-name")]
        public string FirstName;

        [XmlElementAttribute("last-name")]
        public string LastName;
    }



}
