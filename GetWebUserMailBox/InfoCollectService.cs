using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ConsoleApp1
{
    public class InfoCollectService
    {
        public List<DeepWebPage> getSonPage(String url)
        {
            List<DeepWebPage> deepWebPages = new List<DeepWebPage>();
            
            string htmlCode = "";
            WebClient MyWebClient = new WebClient();

            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据
            if (IsUtf8(pageData))
            {
                string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
                htmlCode = pageHtml;
            }
            else
            {
                string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            
                htmlCode = pageHtml;
            }
            string key1= "http://pdc.hzau.edu.cn/jgfw/desktop/";//寻找url的第一个键
            int pos = htmlCode.IndexOf(key1);
            IList<int> list = new List<int>();
            while (pos > -1)
            {
                list.Add(pos);
                pos += key1.Length;
                if (pos >= htmlCode.Length) break;
                pos = htmlCode.IndexOf(key1, pos);
            }
            foreach (var item in list)
            {
                DeepWebPage deepWebPage = new DeepWebPage();
                deepWebPage.webUrl = htmlCode.Substring(item, 66);//截取网址长度可以配
                deepWebPages.Add(deepWebPage);
                //var l = htmlCode.Remove(0, item).IndexOf("\"");
                //surfaceWebPage.sonUrls.Add(htmlCode.Substring(item, 66));
                //Console.WriteLine(htmlCode.Substring(item, item + 10).Length);
            }
            //foreach (var item in surfaceWebPage.sonUrls)
            //{
            //    Console.WriteLine(item);
            //}
            return deepWebPages;

        }
        public bool IsUtf8(byte[] PageCode)
        {
            bool isUtf8;
            //var data = this.DownloadData(url);
            var r_utf8 = new System.IO.StreamReader(new System.IO.MemoryStream(PageCode), Encoding.UTF8); //将html放到utf8编码的StreamReader内
            var r_gbk = new System.IO.StreamReader(new System.IO.MemoryStream(PageCode), Encoding.Default); //将html放到gbk编码的StreamReader内
            var t_utf8 = r_utf8.ReadToEnd(); //读出html内容
            var t_gbk = r_gbk.ReadToEnd(); //读出html内容
            if (!isLuan(t_utf8)) //判断utf8是否有乱码
            {
                isUtf8 = true;
            }
            else
            {
                isUtf8 = false;
            }

            return isUtf8;
        }
        bool isLuan(string txt)
        {
            var bytes = Encoding.UTF8.GetBytes(txt);
            //239 191 189
            for (var i = 0; i < bytes.Length; i++)
            {
                if (i < bytes.Length - 3)
                    if (bytes[i] == 239 && bytes[i + 1] == 191 && bytes[i + 2] == 189)
                    {
                        return true;
                    }
            }
            return false;
        }
        //public List<string> GetAllMailbox(List<DeepWebPage> deepWebPages)
        //{
        //    List<string> Mailboxes = new List<string>();
        //    foreach (var dwp in deepWebPages)
        //    {

        //    }
        //    return Mailboxes;
        //}
        public List<string> GetSingleMailbox(DeepWebPage deepWebPage)
        {
            List<string> smailboxes = new List<string>();
            WebClient MyWebClient = new WebClient();
            string htmlCode="";





            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            Byte[] pageData = MyWebClient.DownloadData(deepWebPage.webUrl); //从指定网站下载数据
            if (IsUtf8(pageData))
            {
                string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
                htmlCode = pageHtml;
            }
            else
            {
                string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            
                htmlCode = pageHtml;
            }
            /*暂时认为一个页面只有一个电子邮箱*/
            string key1 = "<li>电子邮箱：<span><strong>";//寻找url的第一个键
            int pos = htmlCode.IndexOf(key1);
            string key2 = "user-name";
            int pos1 = htmlCode.IndexOf(key2);
            
            smailboxes.Add(htmlCode.Substring(pos1 + 11, htmlCode.Remove(0, pos1 + 11).IndexOf("</h5>")) + "\t"+ htmlCode.Substring(pos + 23, htmlCode.Remove(0, pos + 23).IndexOf("</strong>")) + "\n");//24可修改
            return smailboxes;

        }
        public List<string> GetAllUrl(string url)
        {
            List<string> vs = new List<string>();
            WebClient MyWebClient = new WebClient();
            string htmlCode = "";





            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据
            if (IsUtf8(pageData))
            {
                string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
                htmlCode = pageHtml;
            }
            else
            {
                string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            
                htmlCode = pageHtml;
            }
            string key1 = "师资力量";
            int pos1 = htmlCode.IndexOf(key1);
            string t = htmlCode.Substring(pos1, 500);
            string key2 = "<a href=\"";
            var pos = t.IndexOf(key2);
            IList<int> list = new List<int>();
            while (pos > -1)
            {
                list.Add(pos);
                pos += key1.Length;
                if (pos >= t.Length) break;
                pos = t.IndexOf(key1, pos);
            }
            foreach (var item in list)
            {

                var u=t.Substring(pos + 11, t.Remove(0, pos + 11).IndexOf("\""));
                if (u!=url)
                {
                    vs.Add(u);
                }

            }
            //不等于当前url +=
            return vs;
        }
    }
    
}
