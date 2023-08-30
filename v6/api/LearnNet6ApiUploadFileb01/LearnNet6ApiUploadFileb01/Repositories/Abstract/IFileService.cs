namespace LearnNet6ApiUploadFileb01.Repositories.Abstract
{
    public interface IFileService
    {
        Tuple<int, string> SaveImage(IFormFile imageFile);

        bool DeleteImage(string imageFileName);
    }
}
