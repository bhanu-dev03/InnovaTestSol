using System;
using System.Collections.Generic;
using System.Text;

namespace InnovaSolTest.Common.Helper
{
    public static class PasswordHelper
    {
        public static string EncryptPassword(this string password)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}
