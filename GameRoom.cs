using System;
using System.Collections.Generic;

public class GameRoom
{
    private readonly int _maxAmountOfPlayers;
    private readonly List<Player> _players;
    private readonly List<Player> _readyPlayers;
    private readonly IChat _chat;

    private GameMode _gameMode = GameMode.Waiting;

    public GameRoom(int maxAmountOfPlayers)
    {
        if (maxAmountOfPlayers < 0)
            throw new ArgumentOutOfRangeException(nameof(maxAmountOfPlayers));

        _maxAmountOfPlayers = maxAmountOfPlayers;
        _players = new List<Player>();
        _readyPlayers = new List<Player>();
        _chat = new Chat();
    }

    public IChat GiveAccessToChat(Player player)
    {
        return new SecureChatAccessor(_chat, () =>
        {
            if (_gameMode == GameMode.Waiting)
                return _players.Contains(player);
            else
                return _readyPlayers.Contains(player);
        });
    }

    public void GetIn(Player player)
    {
        if (_players.Count >= _maxAmountOfPlayers)
            throw new InvalidOperationException(nameof(_maxAmountOfPlayers));

        _players.Add(player);
        player.BecomeReady += OnPlayerBecomeReady;
        player.BecomeUnready += OnPlayerBecomeUnready;
        _chat.WriteMessage("New player is here");
    }

    public void Remove(Player player)
    {
        if (_players.Contains(player) == false)
            throw new InvalidOperationException(nameof(player));

        _players.Remove(player);
        player.BecomeReady -= OnPlayerBecomeReady;
        player.BecomeUnready -= OnPlayerBecomeUnready;
    }

    private void OnPlayerBecomeReady(Player player)
    {
        _readyPlayers.Add(player);
        if (_readyPlayers.Count == _players.Count)
            _gameMode = GameMode.Playing;
    }

    private void OnPlayerBecomeUnready(Player player)
    {
        _readyPlayers.Remove(player);
        _gameMode = GameMode.Waiting;
    }

    public enum GameMode
    {
        Waiting,
        Playing
    }
}
