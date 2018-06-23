using System;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILog, ConsoleLog>()
                .BuildServiceProvider();

            //resolve
            var log = serviceProvider.GetService<ILog>();

            //use
            log.Info("Hello World!");

            Console.ReadLine();
        }
    }
}
