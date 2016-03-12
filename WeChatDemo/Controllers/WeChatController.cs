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
using WeChatDemo.Model;
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
            
            if (Basic.CheckSignature(signature, timestamp, nonce, WxAccountFactory.Token))
                return echostr;
            return null;
        }
        [HttpPost]
        public string GetWxMsg(string signature, string timestamp, string nonce)
        {
            if (!Basic.CheckSignature(signature, timestamp, nonce, WxAccountFactory.Token))
                return null;

            var wechat=new WeChatHelper();
            wechat.ReciveText += OnReciveText;
            using (var stream = System.Web.HttpContext.Current.Request.InputStream)
            {
                wechat.ReceiveMsg(stream);
            }
            return null;
        }

        public void OnReciveText(WxReceiveMsg msg)
        {
            //var r= XMLHelper.Seriailze(new WxSendMsg()
            //{
            //    ToUserName = msg.FromUserName,
            //    FromUserName = msg.ToUserName,
            //    MsgType = "text",
            //    Content ="Hello World!",
            //    CreateTime = DateTime.UtcNow.ToTimeStamp()
            //});

            WeChatSDK.Basic.SendText(WxAccountFactory.AccessToken, msg.FromUserName,"Hello World");
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