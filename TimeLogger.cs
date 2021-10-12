using System;

namespace Lesson
{
    internal class TimeLogger : ILogger
    {
        private DayOfWeek _day;
        private ILogger _logger;

        public TimeLogger(DayOfWeek day, ILogger logger)
        {
            _day = day;
            _logger = logger;
        }

        public void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == _day)
                _logger.WriteError(message);
        }
    }
}
