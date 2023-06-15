using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Test.Views.Admin
{
    public class OpenCVModel : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<OpenCVModel> _logger;

        public OpenCVModel(IWebHostEnvironment hostingEnvironment, ILogger<OpenCVModel> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        public IActionResult OnGet(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return NotFound();
            }

            string cvFilesDirectory = Path.Combine(_hostingEnvironment.WebRootPath, "CVs");

           
            string cvFilePath = Path.Combine(cvFilesDirectory, fileName);

            
            if (!System.IO.File.Exists(cvFilePath))
            {
                return NotFound();
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(cvFilePath);

            
            string contentType;
            string fileExtension = Path.GetExtension(fileName).ToLowerInvariant();
            switch (fileExtension)
            {
                case ".pdf":
                    contentType = "application/pdf";
                    break;
                case ".jpg":
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                default:
                    contentType = "application/octet-stream";
                    break;
            }

            
            return File(fileBytes, contentType, fileName);
        }
    }
}
