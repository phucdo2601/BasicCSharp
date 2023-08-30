using LearnNet6ApiUploadFileb01.Repositories.Abstract;

namespace LearnNet6ApiUploadFileb01.Repositories.Implementation
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env; 
        }

        public bool DeleteImage(string imageFileName)
        {
            try
            {
                var wwwPath = this._env.WebRootPath;
                var path = Path.Combine(wwwPath, "Uploads\\", imageFileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                return false;

            }
            catch (Exception)
            {
                return false;

                throw;
            }
        }

        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try
            {
                var contentPath = this._env.ContentRootPath;
                var path = Path.Combine(contentPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                }
                //Chex the allowed extension
                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }

                string uniqueString = Guid.NewGuid().ToString();
                //we are trying to create a unique filename here
                var newFilename = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFilename);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();
                return new Tuple<int, string>(1, newFilename);
            }
            catch (Exception)
            {
                return new Tuple<int, string>(0, "Error has occured");


                throw;
            }
        }
    }
}
