using LibraryApp.Contract;
using System;

namespace LibraryApp.Data
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
