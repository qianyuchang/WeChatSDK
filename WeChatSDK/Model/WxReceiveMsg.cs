using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeChatSDK.Model
{
    [Serializable]
    [XmlRoot("xml")]
   public class WxReceiveMsg
    {
        public Int64 MsgId { get; set; }
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public int CreateTime { get; set; }
        public string MsgType { get; set; }
        public string MediaId { get; set; }
        /// <summary>
        /// 缩略图Id
        /// </summary>
        public string ThumbMediaId { get; set; }
        public string Location_X { get; set; }
        public string Location_Y { get; set; }
        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public string Scale { get; set; }
        /// <summary>
        /// 地图位置信息
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }
    }
}
