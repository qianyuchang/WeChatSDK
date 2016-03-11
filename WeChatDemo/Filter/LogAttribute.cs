using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WeChatDemo.Helper;

namespace WeChatDemo.Filter
{
    public class LogAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var Form = filterContext.RequestContext.HttpContext.Request.Form;

            var url = filterContext.RequestContext.HttpContext.Request.Url;
            Log.Info("url:"+url+"\n\n");
            if (Form != null)
                Log.Info("params:" + string.Join("\n", Form.AllKeys.Select(m => m + ":" + Form[m]))+"\n");
            
            base.OnActionExecuting(filterContext);
        }
    }
}