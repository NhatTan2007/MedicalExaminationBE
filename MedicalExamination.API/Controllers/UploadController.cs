using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    public class UploadController : BaseApiController
    {

        private IWebHostEnvironment _environment;

        public UploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public class FIleUploadAPI // model 
        {
            //public string userA {get;set;}
        }

        [HttpPost, DisableRequestSizeLimit]
        public string Upload()
        {
            IFormFile files = Request.Form.Files[0];
            if (files.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
                    }
                    var uniqueFilename = Guid.NewGuid().ToString() + "_" + files.FileName;
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + uniqueFilename))
                    {
                        files.CopyTo(filestream);
                        filestream.Flush();
                        return "\\uploads\\" + files.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Unsuccessful";
            }


        }
    }
}
