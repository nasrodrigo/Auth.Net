using System;
using System.Text;
using System.Collections.Generic;

using dotapp.BCrypt;

namespace dotapp.Util
{
    public class Authentic
    {
        public String HashGenerated(String value)
        {
            String salt = BCrypt.BCrypt.GenerateSalt();
            String hash = BCrypt.BCrypt.HashPassword(value, salt);

            return hash;
        }

        public bool HashValidate(String value, String hash)
        {
            return BCrypt.BCrypt.Verify(value, hash);
        }
    }
}