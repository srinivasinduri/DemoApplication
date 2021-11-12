using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeb.Utility
{
    public class FileUpload
    {
        IConfiguration Configuration { get; }
        public string _rootpath;
        public FileUpload(IConfiguration configuration,IHostingEnvironment env)
        {
            this.Configuration = configuration;
            _rootpath = env.ContentRootPath;
        }

        public string UploadFile(IFormFile file)
        {
            using(var ms=new MemoryStream())
            {
                file.CopyTo(ms);
                byte[] fileData = ms.ToArray();
                try
                {
                    
                    string filename = Path.GetFileName(file.FileName);
                    //string folderName = @"Image\Profile\";
                    //string newPath = Path.Combine(_rootpath, folderName);
                    string fullpath = Path.Combine(_rootpath, file.FileName);
                    using (var stream = new FileStream(fullpath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var fileextension = Path.GetExtension(filename);
                    //var newFileName = string.Concat(Convert.ToString(Guid.NewGuid()), fileextension);
                    var newFileName = fullpath;
                    return newFileName;
                }
                catch(Exception ex) 
                {
                    return ex.Message;
                }
            }
        }
    }
}
