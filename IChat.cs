using System.Collections.Generic;

public interface IChat
{
    IEnumerable<string> ReadMessages();

    void WriteMessage(string message);
}
