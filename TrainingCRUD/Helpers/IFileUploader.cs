namespace TrainingCRUD.Helpers
{
    public interface IFileUploader
    {
        Task<string?> UploadAsync(IFormFile file, string folderName);
    }
}
