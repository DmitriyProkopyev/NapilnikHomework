using System;

internal class CustomLogger : ILogger
{
    private readonly ILogger[] _loggers;

    public CustomLogger(ILogger[] loggers)
    {
        if (loggers == null)
            throw new ArgumentNullException(nameof(loggers));

        foreach (var logger in loggers)
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

        _loggers = loggers;
    }

    public void WriteError()
    {
        foreach (var logger in _loggers)
            logger.WriteError();
    }
}