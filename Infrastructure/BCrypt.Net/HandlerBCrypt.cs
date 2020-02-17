using System;

using Bcrypt = Auth.Net.Infrastructure.BCrypt.Net.BCrypt;

namespace Auth.Net.Infrastructure.BCrypt.Net
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