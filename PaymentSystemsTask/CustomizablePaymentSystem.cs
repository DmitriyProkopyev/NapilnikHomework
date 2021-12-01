using System;
using System.Linq;

class CustomizablePaymentSystem : IPaymentSystem<string>
{
    private readonly string _link;
    private readonly IPaymentSystem<int>[] _payments;

    public CustomizablePaymentSystem(string link, params IPaymentSystem<int>[] payments)
    {
        if (link is null || link == string.Empty)
            throw new ArgumentNullException(nameof(link));

        if (payments.Any(payment => payment is null))
            throw new ArgumentException(nameof(payments));

        _link = link;
        _payments = payments;
    }

    public string GetPaylink(Order order)
    {
        if (order is null)
            throw new ArgumentNullException(nameof(order));

        long hash = _payments.Select(payment => payment.GetPaylink(order)).Sum();

        return _link + hash;
    }
}