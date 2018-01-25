using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualTestsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new {Date = DateTime.Now};
            var b = JsonConvert.SerializeObject(a);
            Console.WriteLine(b);
            Console.ReadKey();
        }
    }
}
