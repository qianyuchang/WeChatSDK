using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WeChatSDK.Helper
{
    public  static class StringHelper
    {
        public static string ToSha1(this string originStr)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(originStr));
                return string.Join("", hash.Select(b => b.ToString("x2"))
                             .ToArray());
            }
        }

        public static string ToSha1(this StringBuilder originStr)
        {
            return ToSha1(originStr.ToString());
        }
    }
}
