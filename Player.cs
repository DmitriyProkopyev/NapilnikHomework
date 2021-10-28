using System;

public class Player
{
    private GameRoom _currentRoom;
    private IChat _chat;

    public event Action<Player> BecomeReady;
    public event Action<Player> BecomeUnready;

    public void Join(GameRoom room)
    {
        if (_currentRoom != null)
            throw new InvalidOperationException(nameof(room));

        _currentRoom = room;
        _currentRoom.GetIn(this);
        _chat = _currentRoom.GiveAccessToChat(this);
    }

    public void LeaveRoom()
    {
        BecomeUnready?.Invoke(this);
        _currentRoom.Remove(this);
        _currentRoom = null;
        _chat = null;
    }

    public void Play()
    {
        BecomeReady?.Invoke(this);
        _chat.WriteMessage("I am ready");
    }

    public GameRoom CreateRoom()
    {
        var room = new GameRoom(4);
        Join(room);
        return room;
    }
}
