using BCryptNet = BCrypt.Net.BCrypt;

namespace BCP.Muchik.Infrastructure.CrossCutting.BCrypt
{
    public static class BCryptManager
    {
        public static string HashText(string textToHash)
        {
            if (string.IsNullOrEmpty(textToHash)) return string.Empty;
            return BCryptNet.HashPassword(textToHash);
        }

        public static bool Verify(string passwordText, string passwordHash)
        {
            if (string.IsNullOrEmpty(passwordText)) return false;
            if (string.IsNullOrEmpty(passwordHash)) return false;
            return BCryptNet.Verify(passwordText, passwordHash);
        }
    }
}
