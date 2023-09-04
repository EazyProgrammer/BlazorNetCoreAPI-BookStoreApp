namespace BookStoreApp.BusinessLogic.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string CreateFile(string rootPath, string imageBase64, string imageName, string url)
        {
            var ext = Path.GetExtension(imageName);
            var fileName = $"{Guid.NewGuid()}{ext}";

            var path = $"{rootPath}\\BookCoverImages";
            var filePath = $"{path}\\{fileName}";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            byte[] image = Convert.FromBase64String(imageBase64);

            var fileStream = File.Create(filePath);
            fileStream.Write(image, 0, image.Length);
            fileStream.Close();

            return $"https://{url}/BookCoverImages/{fileName}";
        }
    }
}
