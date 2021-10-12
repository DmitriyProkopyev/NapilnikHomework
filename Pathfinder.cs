namespace Lesson
{
    internal class Pathfinder
    {
        private ILogger[] _loggers;

        public Pathfinder(params ILogger[] loggers)
        {
            _loggers = loggers;
        }

        public void Find()
        {
            foreach (var logger in _loggers)
                logger.WriteError("some message");
        }
    }
}
