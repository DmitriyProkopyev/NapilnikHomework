using System;

namespace Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var friday = DayOfWeek.Friday;

            var fileLogger = new Pathfinder(new FileLogger());
            var consoleLogger = new Pathfinder(new ConsoleLogger());
            var fridayFileLogger = new Pathfinder(new TimeLogger(friday, new FileLogger()));
            var fridayConsoleLogger = new Pathfinder(new TimeLogger(friday, new ConsoleLogger()));

            var customLogger = new CustomLogger(new ConsoleLogger(), new TimeLogger(friday, new FileLogger()));
            var specialLogger = new Pathfinder(customLogger);
        }
    }
}
