
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using System.Reflection;
using System.Collections.Specialized;

namespace aotoHttpGet
{
    class Program
    {
        //static String url=new string("http://uat.centralbanknews.cn/api_v2/question/response/questionList?page=1");
        static int i;
        //static int count = 0;
        static int n = 0;
        static void Main(string[] args)
        {
            for (i = 0; i < 100000; i++)
            {
                Thread thread = new Thread(Test);
                thread.Start();
            }
        }
        static void Test()
        {
            try
            {
                //行为
                HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create("http://uat.centralbanknews.cn/api_v2/question/response/questionList?page=1");

                SetHeaderValue(httpRequest.Headers, "XX-Api-Version", "1.1.0");
                SetHeaderValue(httpRequest.Headers, "XX-Device-Typen", "wxapp");
                SetHeaderValue(httpRequest.Headers, "XX-Token", "1f2652e86938b2e34b13dcd544a6a22240003b7ea900c4870105dd91d5225502");
                //发送请求的方式
                httpRequest.Method = "GET";
                //发送的协议
                httpRequest.Accept = "HTTP";
                Console.WriteLine(n+httpRequest.GetResponse().ToString());
                n++;
                Test();
            }
            catch (Exception)
            {
                Console.WriteLine(i);
                throw;
            }
        }
        private static void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", BindingFlags.Instance | BindingFlags.NonPublic);
            if (property != null)
            {
                var collection = property.GetValue(header, null) as NameValueCollection;
                collection[name] = value;
            }
        }
    }
}
