namespace Library.API.Services.Abstract
{
    public interface IFileService
    {
        Task<Tuple<int, string>> SaveImage(byte[] imageBytes, string fileName);
        bool DeleteImage(string imageFileName);
    }
}
