using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace WeChatSDK.Helper
{
    public static class DateTimeHelper
    {
        public static int ToTimeStamp(this DateTime date)
        {
            return (Int32) (date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        
    }
}
