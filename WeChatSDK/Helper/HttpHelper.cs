using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

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

                var content = new StringContent(args);

                var response =  client.PostAsync(url, content);

                var responseString =  response.Result.Content.ReadAsStringAsync();

                return responseString.Result;
            }
        }
    }
}
