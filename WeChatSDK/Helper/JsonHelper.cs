using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Serialization;
using  System.IO;
using System.Web.Script.Serialization;

namespace WeChatSDK.Helper
{
    public static class JsonHelper
    {
        public static T Deseriailze<T>(string json) where T : class,new()
        {
            return new JavaScriptSerializer().Deserialize<T>(json);

        }

        public static string Seriailze<T>(T entity) where T : class
        {
            return new JavaScriptSerializer().Serialize(entity);
            
        }

    }
}
