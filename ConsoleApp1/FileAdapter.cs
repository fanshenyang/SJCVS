using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    public class FileAdapter
    {
        public static void WriteToFile(String s)
        {
            if (!File.Exists("C:\\Users\\Administrator\\Desktop\\快点我.txt"))
            {
                StreamWriter strmsave = new StreamWriter("C:\\Users\\10492\\Desktop\\快点我.txt", false, System.Text.Encoding.Default);
                strmsave.WriteLine(s);
                Console.WriteLine("写入完成");
                strmsave.Close();
            }
            else
            {
                StreamWriter strmsave = new StreamWriter("C:\\Users\\10492\\Desktop\\快点我.txt", false, System.Text.Encoding.Default);
                strmsave.WriteLine(s);
                Console.WriteLine("写入完成");
                strmsave.Close();
            }

        }
    }
}
