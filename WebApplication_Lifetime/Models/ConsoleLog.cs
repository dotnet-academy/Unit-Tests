using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Lifetime.Models
{
    public class ConsoleLog : ILog
    {
        private string lastInfo_;

        public string GetLastInfo()
        {
            return lastInfo_;
        }

        public void Info(string str)
        {
            lastInfo_ = str;
            Console.WriteLine(str);
        }
    }
}
