using System;
using System.Net;
using System.Text;

namespace GetWebNews
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入网址");
            var url = Console.ReadLine();
            var html=GetWebText.GetWebT(url);
            //Console.WriteLine(GetMainContentHelper.getDataFromUrl(html));
            Console.WriteLine(GetMainContentHelper.GetMainContent(html));


        }

    }
}
