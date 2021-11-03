using AEOI.Editor.Web.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Xml.Serialization;

namespace AEOI.Editor.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        public IWebHostEnvironment HostingEnvironment { get; set; }

        public DataController(IWebHostEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        [HttpGet("[action]")]
        public AEOIUKSubmissionFIReport GetData(string fileName)
        {
            var path = Path.Combine(HostingEnvironment.ContentRootPath, "Uploads", fileName);

            XmlSerializer serializer = new XmlSerializer(typeof(AEOIUKSubmissionFIReport));

            StreamReader reader = new StreamReader(path);
            var report = (AEOIUKSubmissionFIReport)serializer.Deserialize(reader);
            reader.Close();

            return report;
        }
    }
}
