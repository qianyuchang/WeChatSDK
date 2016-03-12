using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeChatSDK.Helper;
using  System.Collections.Generic;
using System.Net.Http;
using WeChatSDK.Model;

namespace WeChatSDK.Test
{
    [TestClass]
    public class JsonHelperTest
    {
        [TestMethod]
        public void TestDeSeriailze()
        {
            
        }

         [TestMethod]
        public void TestSeriailze()
        {
          var json=JsonHelper.Seriailze(new
            {
               test=111 
            });

            Assert.AreEqual("{\"test\":111}",json,"json seriailze fail");
            Console.WriteLine(json);
        }
    }
}
