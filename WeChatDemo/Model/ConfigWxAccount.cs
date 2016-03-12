using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Web;
using WeChatSDK;
using WeChatSDK.Helper;

namespace WeChatDemo.Model
{
    public class ConfigWxAccount:IWxAccount
    {
        public string Appid => GetConfigValue("Appid");

        public string AppSecret => GetConfigValue("AppSecret");

        private object _accessTokenLocoker;
        public string AccessToken
        {
            get
            {
                lock (_accessTokenLocoker)
                {
                    var token= GetConfigValue("AccessToken");
                    if (string.IsNullOrEmpty(token)|| IsAccessTokenExpires(token))
                       token=WriteToekn();
                    return token;
                }
            }   
        } //=> GetConfigValue("AccessToken");
        public string OriginId =>GetConfigValue("OriginId");
        public string Token => GetConfigValue("Token");


        private AppSettingsReader _builder;

        public AppSettingsReader Bulider => _builder ?? new AppSettingsReader();
        
        private string  GetConfigValue(string key)
        {
           return  _builder.GetValue(key, typeof (string)) as string;
        }

        private string WriteToekn()
        {
            
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings.Remove("AccessToken");

            var token = Basic.GetAccessToken(this.Appid, this.AppSecret);
            config.AppSettings.Settings.Add("AccessToken", token+"&"+DateTime.UtcNow.ToTimeStamp());

            config.Save(ConfigurationSaveMode.Modified);
            return token;
        }

        private bool IsAccessTokenExpires(string token)
        {
            var args=token.Split('&');
            var time = int.Parse(args[1]);
            DateTime.UtcNow.GetTimeSpan(time);
            return time <= 20;
        }
    }
}