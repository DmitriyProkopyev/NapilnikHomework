using System.IO;

namespace Lesson
{
    internal class FileLogger : ILogger
    {
        public void WriteError(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }
}
