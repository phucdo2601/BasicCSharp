using System.Text;

namespace LearnNet8ShoppingWebMVCB01.Helpers
{
	public class MyUtils
	{
		public static string GenerateRandomKey(int length = 5)
		{
			var pattern = @"qazwsxedcrfvtgbyhnujmiklopQAZWSXEDCRFVTGBYHNUJMIKLOP!";

			var sb = new StringBuilder();
			var rd = new Random();
            for (int i = 0; i < length; i++)
            {
				sb.Append(pattern[rd.Next(0, pattern.Length)]);
            }

			return sb.ToString();
        }

		public static string UploadHinh(IFormFile Hinh, string folder)
		{
			try
			{
				var currentTimeStamp = DateTime.Now.ToFileTime();

				var fileName = Hinh.FileName.Split(".")[0] + "-" + currentTimeStamp + "."+ Hinh.FileName.Split(".")[1];

                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder, fileName);
				using (var myFile = new FileStream(fullPath, FileMode.CreateNew))
				{
					Hinh.CopyTo(myFile);
				}

				return fileName;
			}
			catch (Exception ex)
			{

				return string.Empty;
			}
		}
	}
}
