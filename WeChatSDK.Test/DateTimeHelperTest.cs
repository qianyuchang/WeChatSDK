using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeChatSDK.Helper;
using  System.Collections.Generic;
using System.Net.Http;
using WeChatSDK.Model;

namespace WeChatSDK.Test
{
    [TestClass]
    public class DateTimeHelperTest
    {
        [TestMethod]
        public void TestGetTimeSpan()
        {
            var time1 = DateTime.UtcNow.AddMinutes(-2).ToTimeStamp();
            //var str=DateTime.UtcNow.GetTimeSpan(time1);
            Console.WriteLine( new DateTime(time1).ToString());
           
            //Console.WriteLine(str);
        }

         
    }
}
