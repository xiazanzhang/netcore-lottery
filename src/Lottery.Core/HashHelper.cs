using System;

namespace Lottery.Core
{
    public static class HashHelper
    {
        public static string Hash(string value, string salt)
        {
            byte[] passwordAndSaltBytes = System.Text.Encoding.UTF8.GetBytes(value + salt);

            byte[] hashBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordAndSaltBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
