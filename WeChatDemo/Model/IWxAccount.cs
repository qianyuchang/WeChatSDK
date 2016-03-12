using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatDemo.Model
{
    public interface IWxAccount
    {
       string Appid { get;}
       
       string AppSecret { get; }

       string AccessToken { get; }

       string OriginId { get; }
       
       string Token { get; }
        
    }
}