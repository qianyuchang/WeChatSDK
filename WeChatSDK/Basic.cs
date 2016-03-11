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
    }
}
