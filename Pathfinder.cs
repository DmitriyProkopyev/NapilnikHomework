using System;

namespace Lesson
{
    internal class Pathfinder
    {
        private readonly ILogger _logger;

        public Pathfinder(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Find()
        {
            _logger.WriteError("some message");
        }
    }
}
