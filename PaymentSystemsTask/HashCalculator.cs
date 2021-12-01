using System;

public abstract class HashCalculator : IPaymentSystem<int>
{
    private readonly Func<Order, string> _origin;

    public HashCalculator(Func<Order, string> origin)
    {
        if (origin is null)
            throw new ArgumentNullException(nameof(origin));

        _origin = origin;
    }

    public int GetPaylink(Order order)
    {
        if (order is null)
            throw new ArgumentNullException(nameof(order));

        string data = _origin.Invoke(order);
        return CalculateHash(data);
    }

    protected abstract int CalculateHash(string input);
}