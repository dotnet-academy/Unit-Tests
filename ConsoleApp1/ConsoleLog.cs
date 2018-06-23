using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ConsoleLog : ILog
    {
        public void Info(string str)
        {
            Console.WriteLine(str);
        }
    }
}
