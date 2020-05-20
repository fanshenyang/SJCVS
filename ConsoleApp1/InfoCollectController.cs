using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class InfoCollectController
    {
        public static List<string> GetAllUrl(string url)
        {
            List<string> vs = new List<string>();
            InfoCollectService infoCollectService = new InfoCollectService();
            return infoCollectService.GetAllUrl(url);
        }
        public static List<string> GetAllMailbox(string url)
        {
            List<string> list = new List<string>();
            InfoCollectService infoCollectService = new InfoCollectService();
            List<DeepWebPage> deepWebPages = new List<DeepWebPage>();
            deepWebPages = infoCollectService.getSonPage(url);
            foreach (var d in deepWebPages)
            {
                List<string> ms = new List<string>();
                InfoCollectService infoCollectService1 = new InfoCollectService();
                ms = infoCollectService1.GetSingleMailbox(d);
                foreach (var item in ms)
                {
                    if (item.Length < 1000)//暂时异常解决
                    {
                        list.Add(item);
                    }
                }

            }
            return list;
        }
    }
}
