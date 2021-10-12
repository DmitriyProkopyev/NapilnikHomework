using System;

namespace Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var friday = DayOfWeek.Friday;

            var fileLogWriter = new FileLogger();
            var consoleLogWriter = new ConsoleLogger();

            var fileLogger = new Pathfinder(fileLogWriter);
            var consoleLogger = new Pathfinder(consoleLogWriter);
            var fridayFileLogger = new Pathfinder(new TimeLogger(friday, fileLogWriter));
            var fridayConsoleLogger = new Pathfinder(new TimeLogger(friday, consoleLogWriter));
            var specialLogger = new Pathfinder(consoleLogWriter, new TimeLogger(friday, fileLogWriter));
        }
    }
}
