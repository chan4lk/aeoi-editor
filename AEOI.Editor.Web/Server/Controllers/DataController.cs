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
        public ILogger<DataController> Logger { get; }

        public DataController(IWebHostEnvironment hostingEnvironment, ILogger<DataController> logger)
        {
            HostingEnvironment = hostingEnvironment;
            Logger = logger;
        }

        [HttpGet("[action]")]
        public AEOIUKSubmissionFIReport GetData(string fileName, bool large, int records = 100)
        {
            try
            {
                var path = Path.Combine("/tmp", "Uploads", fileName);

                Logger.LogInformation("upload file path @{path}", path);

                XmlSerializer serializer = new XmlSerializer(typeof(AEOIUKSubmissionFIReport));

                StreamReader reader = new StreamReader(path);
                var report = (AEOIUKSubmissionFIReport)serializer.Deserialize(reader);
                reader.Close();

                if (large)
                {
                    report.Submission.FIReturn.AccountData = Enumerable.Range(0, records).Select(i =>
                    {
                        return report.Submission.FIReturn.AccountData[0];
                    }).ToArray();
                }

                return report;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                Response.WriteAsync(ex.Message);
                throw;
            }
          
        }
    }
}
