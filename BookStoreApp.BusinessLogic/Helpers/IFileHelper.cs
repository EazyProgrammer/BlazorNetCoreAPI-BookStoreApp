
namespace BookStoreApp.BusinessLogic.Helpers
{
    public interface IFileHelper
    {
        string CreateFile(string rootPath, string imageBase64, string imageName, string url);
    }
}
