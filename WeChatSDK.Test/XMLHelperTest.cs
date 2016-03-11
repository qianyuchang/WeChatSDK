using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeChatSDK.Helper;
using  System.Collections.Generic;
using System.Net.Http;
using WeChatSDK.Model;

namespace WeChatSDK.Test
{
    [TestClass]
    public class XMLHelperTest
    {
        [TestMethod]
        public void TestDeSeriailze()
        {
            var xml = @"<xml><ToUserName><![CDATA[gh_d5e1debe3276]]></ToUserName>
                        <FromUserName><![CDATA[oiSLrvlivX57YmmCAc0lEDFbSA28]]></FromUserName>
                        <CreateTime>1457677225</CreateTime>
                        <MsgType><![CDATA[text]]></MsgType>
                        <Content><![CDATA[qe]]></Content>
                        <MsgId>6260676009901474487</MsgId>
                        </xml>";
            var r=XMLHelper.DeSeriailze<WxReceiveMsg>(xml);
            Assert.AreEqual(6260676009901474487,r.MsgId,"序列化失败");
            Console.WriteLine(r.MsgId);
        }

         [TestMethod]
        public void TestSeriailze()
        {
            
            //var r = XMLHelper.Seriailze<WxReceiveMsg>(new WxReceiveMsg(){ToUserName = "111111"});
            ////Assert.AreEqual(6260676009901474487, r.MsgId, "序列化失败");
            //Console.WriteLine(r);
            //var o = XMLHelper.DeSeriailze<WxReceiveMsg>(r);
            //Assert.AreEqual("111111", o.ToUserName, "序列化失败");

           var r= XMLHelper.Seriailze(new WxSendMsg()
            {
                ToUserName = "111",
                FromUserName = "gh_d5e1debe3276",
                MsgType = "text",
                Content = "Hello Wrold!",
                CreateTime=(Int32) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
            });
             Console.WriteLine(r);
        }
    }
}
