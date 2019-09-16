using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Network.SendRequestAsync("http://ijunior.ru/", (html) => Console.WriteLine(html));
            Console.WriteLine("Request sended");
            Console.ReadKey();
        }
    }
    delegate void Callback(string html);
    
}
