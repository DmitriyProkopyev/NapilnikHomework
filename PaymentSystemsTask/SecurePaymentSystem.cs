using System;

public class SecurePaymentSystem : IPaymentSystem<int>
{
    private readonly int _secretKey;

    public SecurePaymentSystem(int secretKey)
    {
        if (secretKey < 0)
            throw new ArgumentOutOfRangeException(nameof(secretKey));

        _secretKey = secretKey;
    }

    public int GetPaylink(Order order) => _secretKey;
}