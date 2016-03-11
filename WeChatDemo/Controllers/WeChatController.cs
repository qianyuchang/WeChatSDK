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

            WeChatHelper wechat=new WeChatHelper();

            using (var stream = System.Web.HttpContext.Current.Request.InputStream)
            {
                Byte[] postBytes = new Byte[stream.Length];
                stream.Read(postBytes, 0, (Int32)stream.Length);
                var postString = System.Text.Encoding.UTF8.GetString(postBytes);

                var r=XMLHelper.DeSeriailze<WxReceiveMsg>(postString);
                wechat.ReciveText+= OnReciveText;
 
               
            }
            return null;


        }

        public void OnReciveText(WxReceiveMsg msg)
        {
            var r= XMLHelper.Seriailze(new WxSendMsg()
            {
                ToUserName = msg.FromUserName,
                FromUserName = msg.ToUserName,
                MsgType = "text",
                Content ="Hello World!",
                CreateTime = DateTime.UtcNow.ToTimeStamp()
            });
        }
        public void OnReciveImg(WxReceiveMsg msg)
        {

        }
        public void OnReciveVoice(WxReceiveMsg msg)
        {

        }
        public void OnReciveVideo(WxReceiveMsg msg)
        {

        }
        public void OnReciveShortVideo(WxReceiveMsg msg)
        {

        }
        public void OnReciveShortLocation(WxReceiveMsg msg)
        {

        }
        public void OnReciveLink(WxReceiveMsg msg)
        {

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