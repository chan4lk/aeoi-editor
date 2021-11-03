using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyBlazorApp.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UploadController : Controller
    {
        public IWebHostEnvironment HostingEnvironment { get; set; }

        public UploadController(IWebHostEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Save(IFormFile file) // must match SaveField which defaults to "files"
        {
            if (file != null)
            {
                try
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    var physicalPath = Path.Combine(HostingEnvironment.ContentRootPath, "Uploads", fileName);

                    // Implement security mechanisms here - prevent path traversals,
                    // check for allowed extensions, types, size, content, viruses, etc.
                    // This sample always saves the file to the root and is not sufficient for a real application.

                    using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
                catch
                {
                    // Implement error handling here, this example merely indicates an upload failure.
                    Response.StatusCode = 500;
                    await Response.WriteAsync("some error message"); // custom error message
                }
            }

            // Return an empty string message in this case
            return new EmptyResult();
        }


        [HttpPost]
        public ActionResult Remove(string fileToRemove) // must match RemoveField which defaults to "files"
        {
            if (fileToRemove != null)
            {
                try
                {
                    var fileName = Path.GetFileName(fileToRemove);
                    var physicalPath = Path.Combine(HostingEnvironment.WebRootPath, fileName);

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // Implement security mechanisms here - prevent path traversals,
                        // check for allowed extensions, types, permissions, etc.
                        // this sample always deletes the file from the root and is not sufficient for a real application.

                        System.IO.File.Delete(physicalPath);
                    }
                }
                catch
                {
                    // Implement error handling here, this example merely indicates an upload failure.
                    Response.StatusCode = 500;
                    Response.WriteAsync("some error message"); // custom error message
                }
            }

            // Return an empty string message in this case
            return new EmptyResult();
        }
    }
}