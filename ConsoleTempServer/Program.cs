using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTempServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "http://localhost:5000";
            using (WebApp.Start<Startup>(baseUrl))
            {
                Console.WriteLine("Press Enter to quit.");
                Console.ReadKey();

            }
        }
    }
}

