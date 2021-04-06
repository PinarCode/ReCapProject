using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var result = newPath(file);
            var sourcePath = Path.GetTempFileName();
            using (var fileStream = new FileStream(sourcePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            File.Move(sourcePath, result.newPath);
            return result.Path2;
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            using (var fileStream = new FileStream(result.newPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            File.Delete(sourcePath);
            return result.Path2;
        }

        public static IResult Delete(string path)
        {
            File.Delete(path);
            return new SuccessResult();
        }

        public static (string newPath, string Path2) newPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;//dosyanın uzantısını alır
            var newFileName = Guid.NewGuid().ToString("N") + fileExtension;
            string path12 = @"\wwwroot\Images";
            string result = Environment.CurrentDirectory + path12 + newFileName;
            return (result, $"\\Images\\{newFileName}");
        }
    }
}
