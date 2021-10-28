using System.Collections.Generic;

public class Chat : IChat
{
    private readonly List<string> _messages = new List<string>();

    public IEnumerable<string> ReadMessages() => _messages;

    public void WriteMessage(string message) => _messages.Add(message);
}
