using System.Text;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
namespace Assignment_Management
{
    public class AccountUtil
    {
        // To get a hashed value to store in the database
        public static string GetHash(string text, string salt)
        {
            // Converting text to Byte array
            byte[] textBytes = Encoding.ASCII.GetBytes(text);
            byte[] saltBytes = Encoding.ASCII.GetBytes(salt);
            // Combining salt and text
            byte[] textAndSalt = new byte[textBytes.Length + saltBytes.Length + 1];
            int i;
            for (i = 0; i <= textBytes.Length - 1; i++)
                textAndSalt[i] = textBytes[i];
            for (var j = 0; j <= saltBytes.Length - 1; j++)
            {
                i += 1;
                textAndSalt[i] = saltBytes[j];
            }
            // Now with both the salt and text in one array, let us put them through
            // The SHA256 hash algorithm
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashvalue = sha.ComputeHash(textAndSalt);
                return Convert.ToBase64String(hashvalue);
            }
        }

        // To generate salt
        public static string GenerateSalt()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+-=[]{}|;:,.<>?";
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] randomBytes = new byte[20];
            rng.GetBytes(randomBytes);

            char[] result = new char[20];
            for (int i = 0; i < 20; i++)
            {
                result[i] = validChars[randomBytes[i] % validChars.Length];
            }

            return new string(result);
        }

        // To generate password
        public static string GeneratePassword()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] randomBytes = new byte[5];
            rng.GetBytes(randomBytes);

            char[] result = new char[5];
            for (int i = 0; i < 5; i++)
            {
                result[i] = validChars[randomBytes[i] % validChars.Length];
            }

            return new string(result);
        }

        public static void SendMail( string recieverAddr, string MailSubject, string MailMessage ) {
            var Mail = new MailMessage("apractice552@gmail.com", recieverAddr, MailSubject, MailMessage);
            var SMTP = new SmtpClient("smtp.gmail.com", 587);
            SMTP.Credentials = new NetworkCredential("apractice552@gmail.com", "jccu zjfv owvd scpn");
            SMTP.EnableSsl = true;
            SMTP.Send(Mail);
        }
    }
}