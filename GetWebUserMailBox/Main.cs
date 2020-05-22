using System;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //WebClient MyWebClient = new WebClient();

            //MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            //Byte[] pageData = MyWebClient.DownloadData("http://shipin.hzau.edu.cn/szll/js.htm"); //从指定网站下载数据
            //string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            
            //                                                         //string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
            //Console.WriteLine(pageHtml);



            Console.WriteLine("输入您要抓取邮箱的网址");//http://shipin.hzau.edu.cn/szll.htm
            String fileString="";
            var url = Console.ReadLine();
            //var urlList = InfoCollectController.GetAllUrl(url);
            //foreach (var u in urlList)
            //{
                var result = InfoCollectController.GetAllMailbox(url);
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                    fileString += item;
                }
            //}
            
            FileAdapter.WriteToFile(fileString);
           
            //DeepWebPage deepWebPage = new DeepWebPage();
            //deepWebPage.webUrl = "http://pdc.hzau.edu.cn/jgfw/desktop/grzy/show.htm?zgh=105041994057";
            //InfoCollectService infoCollectService = new InfoCollectService();
            //infoCollectService.GetSingleMailbox(deepWebPage);
        }
    }
}
