using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ConsoleLog : ILog
    {
        public void Info(string str)
        {
            Console.WriteLine($"[{DateTime.Now}]: {str}");
        }
    }
}
