using System;

namespace IMJunior
{
    public sealed class WebMoney : PaymentSystem
    {
        public WebMoney() : base("WebMoney") { }

        public override void TryPay() => Console.WriteLine("Вызов API WebMoney...");
    }
}
