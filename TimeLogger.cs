using System;

namespace Lesson
{
    internal class TimeLogger : ILogger
    {
        private readonly DayOfWeek _day;
        private readonly ILogger _logger;

        public TimeLogger(DayOfWeek day, ILogger logger)
        {
            _day = day;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == _day)
                _logger.WriteError(message);
        }
    }
}
