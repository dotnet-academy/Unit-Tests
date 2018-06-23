using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Lifetime.Models
{
    public class SimpleCalc : ICalc
    {
        private readonly ILog log_;

        public SimpleCalc(ILog log)
        {
            log_ = log;
        }

        public int Add(int a, int b)
        {
            log_.Info($"adding {a} and {b}");

            return a + b;
        }
    }
}
