using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatSDK.Model
{
    [Serializable]
    public class WxResultBase
    {
        
        public int expires_in { get; set; }

        public string errmsg { get; set; }

        public int errcode { get; set; }
    }
}
