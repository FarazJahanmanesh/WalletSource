﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Extensions
{
    public static class Extensions
    {
        public static string SHA1HashCode(this string f)
        {
            var sha1 = new SHA1Managed();
            var plaintextBytes = Encoding.UTF8.GetBytes(f);
            var hashBytes = sha1.ComputeHash(plaintextBytes);

            var sb = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                sb.AppendFormat("{0:x2}", hashByte);
            }

            var hashString = sb.ToString();
            return hashString;
        }
    }
}
