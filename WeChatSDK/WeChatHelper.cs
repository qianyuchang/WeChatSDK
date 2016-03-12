using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatSDK.Helper;
using WeChatSDK.Model;

namespace WeChatSDK
{
    public class WeChatHelper
    {
        public delegate void WxReceiveMsgHandle(WxReceiveMsg msg);

        public event WxReceiveMsgHandle ReciveText;

        public event WxReceiveMsgHandle ReciveImg;

        public event WxReceiveMsgHandle ReciveVoice;

        public event WxReceiveMsgHandle ReciveVideo;

        public event WxReceiveMsgHandle ReciveShortVideo;

        public event WxReceiveMsgHandle ReciveLocation;

        public event WxReceiveMsgHandle ReciveLink;

        public void ReceiveMsg(Stream stream)
        {
            var postBytes = new Byte[stream.Length];
            stream.Read(postBytes, 0, (Int32)stream.Length);
            var postString = System.Text.Encoding.UTF8.GetString(postBytes);

            var msg = XMLHelper.DeSeriailze<WxReceiveMsg>(postString);

            if (string.IsNullOrEmpty(msg?.MsgType))
                return;
            switch (msg.MsgType)
            {
                case "text":
                    ReciveText?.Invoke(msg);
                    break;
                case "image":
                    ReciveImg?.Invoke(msg);
                    break;
                case "voice":
                    ReciveVoice?.Invoke(msg);
                    break;
                case "video":
                    ReciveVideo?.Invoke(msg);
                    break;
                case "shortvideo":
                    ReciveShortVideo?.Invoke(msg);
                    break;
                case "location":
                    ReciveLocation?.Invoke(msg);
                    break;
                case "link":
                    ReciveLink?.Invoke(msg);
                    break;
            }
        }




    }
}
