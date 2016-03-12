using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using WeChatSDK.Model;

namespace WeChatSDK.Helper
{
    public static class HttpHelper
    {
        public static string HttpGet(string url)
        {
            using (var client = new HttpClient())
            {
                var responseString = client.GetStringAsync(url);
                return responseString.Result;
            }
        }

        public static string HttpPost(string url,string args)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(args,Encoding.UTF8,"application/json");

                var response =  client.PostAsync(url, content);

                var responseString =  response.Result.Content.ReadAsStringAsync();

                return responseString.Result;
            }
        }

        public static T HttpGetWechatResult<T>(string url, string paramStr = "") where T : WxResultBase, new()
        {
            var r = HttpGet(url);
            if (r == null)
                return null;

            var entity = JsonHelper.Deseriailze<T>(r);
            
            if (entity?.errcode != 0)
            {
                if (entity == null)
                {
                    //todo write log
                    return null;
                }
                //todo write log

            }
            return entity;
        }
    }
}
