public class Game
{
    static void Main(string[] args)
    {
        var player1 = new Player();
        var player2 = new Player();
        var player3 = new Player();
        var room = player1.CreateRoom();

        player2.Join(room);
        player3.Join(room);
    }
}
