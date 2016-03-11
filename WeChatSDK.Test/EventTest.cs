using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WeChatSDK.Test
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void Test()
        {
            var test=new Test();
            test.ReciveMsg += OnReciveMsg;
            test.Msg();
        }

        public void OnReciveMsg(object sender, EventArgs args)
        {
            Console.WriteLine("aaa");
        }
    }

    public class Test
    {
        public event EventHandler ReciveMsg;

        public void Msg()
        {
            if (ReciveMsg != null)
                ReciveMsg(this, EventArgs.Empty);
        }
    }
}
