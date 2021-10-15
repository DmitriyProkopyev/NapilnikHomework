using System;

namespace IMJunior
{
    public sealed class Qiwi : PaymentSystem
    {
        public Qiwi() : base("QIWI") { }

        public override void TryPay() => Console.WriteLine("Перевод на страницу QIWI...");
    }
}
