using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WeChatDemo.Helper;
using WeChatSDK;
using WeChatDemo.Filter;
using WeChatSDK.Helper;
using WeChatSDK.Model;

namespace WeChatDemo.Controllers
{
    [LogAttribute]
    public class WeChatController : Controller
    {
        [HttpGet]
        public String GetWxMsg(string signature, string timestamp, string nonce,string echostr )
        {
            var token = new AppSettingsReader().GetValue("Token",typeof(string)) as string;
            if (Basic.CheckSignature(signature, timestamp, nonce, token))
                return echostr;
            return null;
        }
        [HttpPost]
        public string GetWxMsg(string signature, string timestamp, string nonce)
        {
            var token = new AppSettingsReader().GetValue("Token", typeof(string)) as string;
            if (!Basic.CheckSignature(signature, timestamp, nonce, token))
                return null;

            using (var stream = System.Web.HttpContext.Current.Request.InputStream)
            {
                Byte[] postBytes = new Byte[stream.Length];
                stream.Read(postBytes, 0, (Int32)stream.Length);
                var postString = System.Text.Encoding.UTF8.GetString(postBytes);

                var r=XMLHelper.DeSeriailze<WxReceiveMsg>(postString);
                var list = new List<string>()
                {
                    "Hello Wrold!",
                    "hi",
                    "逗比",
                    "神经病",
                    "好无聊",
                    "tx的文档真蛋疼",
                    "xml各种恶心"
                };
                switch (r.MsgType)
                {
                    case "text":
                        return XMLHelper.Seriailze(new WxSendMsg()
                        {
                            ToUserName=r.FromUserName,
                            FromUserName = r.ToUserName,
                            MsgType = "text",
                            Content=list[new Random().Next(list.Count-1)],
                            CreateTime = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
                            
                        });
                        break;
                    case "image": break;
                    case "voice": break;
                    case "video": break;
                    case "shortvideo": break;
                    case "location": break;
                    case "link": break;
                }
            }
            return null;


        }

        [HttpGet]
        public string TestApi()
        {
            return "success";
        }

        [HttpPost]
        public string TestApi(string sign)
        {
            return sign;
        }

    }
}