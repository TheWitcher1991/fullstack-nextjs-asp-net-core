using System.Text;

namespace backend
{
    public class Config
    {
        public static int MAX_TITLE_LENGTH = 255;
        public static int MAX_DESCRIPTION_LENGTH = 3000;
        public static decimal MIN_PRICE = 1.0m;
        public static int SESSION_EXPIRES_HOURS = 730;
        public static string TOKEN_NAME = "access_token";
        public static string SECRET_KEY = "*********";
        public static byte[] SECRET_KEY_BYTES = Encoding.UTF8.GetBytes(Config.SECRET_KEY);
        public static string MEDIA_FOLDER_NAME = "uploads";
    }
}
