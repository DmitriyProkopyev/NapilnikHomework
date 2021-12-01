using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

class StandardPaymentSystem : IPaymentSystem<int>
{
    private readonly int _orderInfo;

    public StandardPaymentSystem(int orderInfo)
    {
        if (orderInfo < 0)
            throw new ArgumentOutOfRangeException(nameof(orderInfo));

        _orderInfo = orderInfo;
    }

    public int GetPaylink(Order order) => _orderInfo;
}
