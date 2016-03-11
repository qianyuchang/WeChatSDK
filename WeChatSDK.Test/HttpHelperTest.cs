using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeChatSDK.Helper;
using  System.Collections.Generic;
using System.Net.Http;

namespace WeChatSDK.Test
{
    [TestClass]
    public class HttpHelperTest
    {
        [TestMethod]
        public void TestHttpGet()
        {
            var r=HttpHelper.HttpGet("http://localhost:8077/Wechat/TestApi");
            Assert.AreEqual("success",r,"request fail");
            Console.WriteLine(r);
        }

         [TestMethod]
        public void TestHttpPost()
        {
            var args = new Dictionary<string, string>
            {
                { "sign", "1" }
            };
            var r = HttpHelper.HttpPost("http://localhost:8077/Wechat/TestApi", args);
            Assert.AreEqual("1", r, "request fail");
            Console.WriteLine(r);
        }
    }
}
