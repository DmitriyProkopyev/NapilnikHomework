public class Player
{
    private readonly Mover _mover;
    private readonly Weapon _weapon;

    public string Name { get; private set; }
    public int Age { get; private set; }
}

public class Mover
{
    public float DirectionX { get; private set; }
    public float DirectionY { get; private set; }
    public float Speed { get; private set; }

    public void Move()
    {
        throw new NotImplementedException();
    }
}

public class Weapon
{
    public float Cooldown { get; private set; }
    public int Damage { get; private set; }

    public bool IsReloading()
    {
        throw new NotImplementedException();
    }

    public void Attack()
    {
        throw new NotImplementedException();
    }
}
