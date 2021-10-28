using System;
using System.Collections.Generic;

public class SecureChatAccessor : IChat
{
    private readonly IChat _chat;
    private readonly Func<bool> _checkSecurity;

    public SecureChatAccessor(IChat chat, Func<bool> checkSecurity)
    {
        _chat = chat;
        _checkSecurity = checkSecurity;
    }

    public IEnumerable<string> ReadMessages() => _checkSecurity.Invoke() ? 
        _chat.ReadMessages() : throw new InvalidOperationException(nameof(_checkSecurity));

    public void WriteMessage(string message)
    {
        if (_checkSecurity.Invoke()) 
            _chat.WriteMessage(message);

        throw new InvalidOperationException(nameof(_checkSecurity));
    }
}
