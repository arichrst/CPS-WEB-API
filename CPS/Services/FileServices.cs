using System.IO;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CPS.Controllers;

namespace CPS
{
    public class FileServices
    {
        MastersController Controller;
        public FileServices(MastersController controller)
        {
            Controller = controller;
        }
        public async Task Upload(IFormFile file, string filename , string path)
        {
            string filePath = Controller.HttpContext.Request.Path + "/" + path + "/";
            Console.WriteLine("UPLOAD : " + file.FileName + "\nto Directory : " + filePath + filename);
            if(!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            using (var fileStream = new FileStream(filePath + filename, FileMode.Create)) {
                await file.CopyToAsync(fileStream);
            }
        }

        
    }
}