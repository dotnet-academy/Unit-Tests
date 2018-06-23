using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Lifetime.Models
{
    public interface ILog
    {
        string GetLastInfo();

        void Info(string str);
    }
}
