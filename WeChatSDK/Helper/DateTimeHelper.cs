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

        public static int GetTimeSpan(this DateTime date,int toTime)
        {
            var time=new DateTime(toTime);
            var from = new TimeSpan(DateTime.UtcNow.ToTimeStamp());
            var to=new TimeSpan(toTime);
            return (int)Math.Floor(from.Subtract(to).TotalMinutes);
        }

        
    }
}
