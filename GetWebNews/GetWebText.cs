using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GetWebNews
{
    class GetWebText
    {
        public static string GetWebT(string url)
        {
            //sss
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
            return htmlCode;
        }
        public static bool IsUtf8(byte[] PageCode)
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
        public static bool isLuan(string txt)
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
    }
}
