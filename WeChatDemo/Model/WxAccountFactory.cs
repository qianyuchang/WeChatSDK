using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatDemo.Model
{
    public class WxAccountFactory
    {
        public static IWxAccount GetWxAccount(WechatAccountSource source)
        {
            switch (source)
            {
                case  WechatAccountSource.Config:
                    return new ConfigWxAccount();   
            }
            return null;

        }

        public enum  WechatAccountSource
        {
            Db=1,
            Config=2,
            //Hardcoded,dont recommand
            Text = 3
        }

        public static object _locker;

        private static IWxAccount _wxAccount;

        public static IWxAccount WxAccount
        {
            get
            {
                lock (_locker)
                {
                    if (_wxAccount == null)
                    {
                        _wxAccount = GetWxAccount(WechatAccountSource.Config);
                    }
                    return _wxAccount;
                }
 
            }
        } 

        public static string AppId => WxAccount.Appid;
        public static string AccessToken => WxAccount.AccessToken;
        public static string AppSecret => WxAccount.AppSecret;
        public static string Token => WxAccount.Token;
        public static string OriginId => WxAccount.Appid;

    }
}