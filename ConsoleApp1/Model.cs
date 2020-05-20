using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface IWebPage
    {
        public String webUrl { get; set; }
    }
    public class DeepWebPage : IWebPage
    {
        public String webUrl { get; set; }
        public String mailBox { get; set; }
        public string infoOwner { get; set; }
    }
    public class SurfaceWebPage : IWebPage
    {
        public String webUrl { get; set; }
        public List<DeepWebPage> sonPage { get; set; }
        public List<string> sonUrls { get; set; }

    }
}
