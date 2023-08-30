using Microsoft.Extensions.Configuration;
using SalaryManagement.Common;

namespace SalaryManagement.Utility.Mail
{
    public class MailInfo
    {
        public const string MAIL_SENDER = "salaryconfirmmangement@gmail.com";
        public const string MAIL_APP_PASSWORD = "szhpojyotwapodsv";

        public const int MAIL_PORT = 587;
        public const string MAIL_HOST = "smtp.gmail.com";

        public const string MAIL_TITLE = "Title of gmail";
        public const string MAIL_YOURNAME = "Yourname";
        public const string MAIL_GMAIL_LECTURER = "Email lecturer";
        public const string MAIL_IMAGE = "https://cdn.icon-icons.com/icons2/1378/PNG/512/avatardefault_92824.png";

        public static readonly string MAIL_API_KEY_SENDGRID = GetApiSendGrid();

        public static string GetApiSendGrid()
        {
            var MyConfig = new ConfigurationBuilder().AddJsonFile(Settings.APP_SETTINGS_JSON).Build();
            var apiKey = MyConfig.GetValue<string>(Settings.API_KEY_SENDGRID_CONFIG);

            return apiKey;
        }
    }
}
