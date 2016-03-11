using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatSDK.Helper;

namespace WeChatSDK
{
    public class Basic
    {
     

        public static bool CheckSignature(string signature, string timestamp, string nonce, string token)
        {

            var paramsList=new List<string>()
            {
                timestamp,
                nonce,
                token
            };

            var paramsStr = new StringBuilder();
            paramsList.OrderBy(m=>m).ToList().ForEach(m=>paramsStr.Append(m));

            return paramsStr.ToSha1().Equals(signature);
         
        }

        public static void GetAccessToken(string appid,string secret)
        {
            var url=
                $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={appid}&secret={secret}";

            HttpHelper.HttpPost(url,null);

        }

        public static void SendMsg(string accessToken)
        {
            var url = $"https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={accessToken} ";

            
            HttpHelper.HttpPost(url, null);
        }
    }
}
