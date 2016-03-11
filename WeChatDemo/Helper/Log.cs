using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WeChatDemo.Helper
{
    public class Log
    {
        public static void Info(string msg)
        {
            var path = "C://Log";
            var pathAll = "C://Log/log.txt";
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            System.IO.File.AppendAllText(pathAll, msg);
        }
    }
}