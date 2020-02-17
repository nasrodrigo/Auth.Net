using System;

using Bcrypt = dotapp.Infrastructure.BCrypt.Net.BCrypt;

namespace dotapp.Infrastructure.BCrypt.Net
{
    public sealed class HandlerBCrypt
    {
        public static String HashGenerated(String value)
        {
            String salt = Bcrypt.GenerateSalt();
            String hash = Bcrypt.HashPassword(value, salt);

            return hash;
        }

        public static bool HashValidate(String value, String hash)
        {
            return Bcrypt.Verify(value, hash);
        }
    }
}