using System;

public class Order
{
    public readonly int Id;
    public readonly int Amount;

    public Order(int id, int amount)
    {
        if (id < 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        (Id, Amount) = (id, amount);
    }
}
