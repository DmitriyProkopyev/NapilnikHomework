using System;

namespace Lesson
{
    internal class ConsoleLogger : ILogger
    {
        public void WriteError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
