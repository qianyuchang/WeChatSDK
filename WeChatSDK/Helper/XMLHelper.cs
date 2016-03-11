using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Serialization;
using  System.IO;

namespace WeChatSDK.Helper
{
    public static class XMLHelper
    {
        public static T DeSeriailze<T>(string xmlDocumentText) where T : class,new()
        {
           // xmlDocumentText = xmlDocumentText.Replace("<xml>", "<" + typeof(T).Name + ">").Replace("</xml>", "</" + typeof(T).Name + ">");

            var serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xmlDocumentText))
            {
                T entity = (T)(serializer.Deserialize(reader));
                return entity;
            }      
        }

        public static string Seriailze<T>(T entity) where T : class,new()
        {
            var serializer = new XmlSerializer(entity.GetType());
            using (var stringwriter = new StringWriter())
            {
                serializer.Serialize(stringwriter, entity);
                var r= stringwriter.ToString();
                if (!string.IsNullOrEmpty(r))
                {
                    r = r.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "")
                         .Replace("<xml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">", "<xml>")
                         .Trim();   
                }
                return r;
            }
            
        }

    }
}
