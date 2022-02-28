using System;

namespace Lesson
{
    internal class Pathfinder
    {
<<<<<<< Updated upstream
        private readonly ILogger _logger;

        public Pathfinder(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
=======
        private ILogger _logger;

        public Pathfinder(ILogger logger)
        {
            _logger = logger;
>>>>>>> Stashed changes
        }

        public void Find()
        {
<<<<<<< Updated upstream
            logger.WriteError("some message");
=======
            _logger.WriteError("some message");
>>>>>>> Stashed changes
        }
    }
}
