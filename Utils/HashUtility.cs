using System;

using bCrypt =  BCrypt.Net.BCrypt;

namespace dotapp.Utils
{
    public sealed class HashUtility
    {
        public static String HashGenerated(String value)
        {
            String salt = bCrypt.GenerateSalt();
            String hash = bCrypt.HashPassword(value, salt);

            return hash;
        }

        public static bool HashValidate(String value, String hash)
        {
            return bCrypt.Verify(value, hash);
        }
    }
}