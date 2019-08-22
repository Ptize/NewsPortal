using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NewsPortal.Domain
{
    public class CryptoService
    {
        public static string ComputeHash(string data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] byteMas = md5.ComputeHash(Encoding.UTF8.GetBytes(data));
            string pass = BitConverter.ToString(byteMas).Replace("-", string.Empty).ToLower();
            return pass;
        }
    }
}
