using Library.API.Services.Abstract;

namespace Library.API.Services.Concrete
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public FileService(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public async Task<Tuple<int, string>> SaveImage(byte[] imageBytes, string filename)
        {
            try
            {
                var webRootPath = _appEnvironment.WebRootPath;
                var imagesPath = Path.Combine(webRootPath, "Images");

                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                var extension = Path.GetExtension(filename);
                Console.WriteLine(extension);
                if (!allowedExtensions.Contains(extension))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }
                string uniqueString = Guid.NewGuid().ToString();
                var newFileName = uniqueString + extension;
                var fileWithPath = Path.Combine(imagesPath, newFileName);
                await File.WriteAllBytesAsync(fileWithPath, imageBytes);
                return new Tuple<int, string>(1, newFileName);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, "Error has occured");
            }
        }

        public bool DeleteImage(string imageFileName)
        {
            try
            {
                var webRootPath = _appEnvironment.WebRootPath;
                var imagesPath = Path.Combine(webRootPath, "Images");
                var fileWithPath = Path.Combine(imagesPath, imageFileName);
                if (File.Exists(fileWithPath))
                {
                    File.Delete(fileWithPath);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
