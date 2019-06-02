using System;

namespace After.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void NewLine()
        {
            Console.WriteLine();
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}