using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace TrainingCRUD.Service
{
    public class FileUploader
    {

        private readonly IWebHostEnvironment _env;

        public FileUploader(IWebHostEnvironment env)
        {
            _env = env;
        }


        public string? BaseString(string path, string folder)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            var match = Regex.Match(path.Trim(),
                @"^data:(image|application)/(png|jpeg|jpg|gif|webp|pdf);base64,(.*)$"
                ,
                RegexOptions.IgnoreCase);

           if (!match.Success) return null;

            var extensions = match.Groups[2].Value.ToLower() switch
            {
                "png" => ".png",
                "jpg" => ".jpg",
                "jpeg" => ".jpeg",
                "pdf" =>".pdf",
                "webp" => ".webp",
                _=> ".jpg"
            };
                var baseString = match.Groups[3].Value;

            try
            {
                var bytes = Convert.FromBase64String(baseString);

                var folderPath = Path.Combine(_env.WebRootPath, "uploads", folder);
                Directory.CreateDirectory(folderPath);

                var filename = $"{Guid.NewGuid()}{extensions}";
                var filepath = Path.Combine(folderPath, filename);
                File.WriteAllBytes(filepath, bytes);


                return $"/uploads/{folder}/{filename}";
            }
            catch
            {
                return null;

            }
            
        }
    }
}
