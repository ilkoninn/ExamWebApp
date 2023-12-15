using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.IO;

namespace ExamWebApp.Helper
{
    public static class FileManager
    {
        public static bool CheckLength(this IFormFile file, int length)
        {
            return file.Length <= length;
        }
        public static bool CheckType(this IFormFile file, string type)
        {
            return file.ContentType.Contains(type);
        }
        public static string Upload(this IFormFile file, string web, string folderName, int Id)
        {
            if(!Directory.Exists(web + folderName))
            {
                Directory.CreateDirectory(web + folderName);
            }

            string fileName = $"{Id}" + file.FileName;

            string create = web + folderName + fileName;

            using (var filestream = new FileStream(create, FileMode.Create))
            {
                file.CopyTo(filestream);
            }

            return fileName;
        }

        public static void Delete(this IFormFile file, string web, string folderName) 
        {
            string delete = file.FileName + web + folderName;
            if(File.Exists($"{delete}"))
            {
                File.Delete(delete);
            }
        }

    }
}
