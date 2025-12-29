namespace TrainingCRUD.Helpers
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _env;

        public FileUploader(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string?> UploadAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                return null;

            var rootPath = _env.WebRootPath;
            var folderPath = Path.Combine(rootPath, folderName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var fullPath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // return relative path (DB friendly)
            return $"/{folderName}/{fileName}";
        }
    }
}
