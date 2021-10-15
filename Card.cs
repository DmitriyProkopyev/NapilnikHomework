using System;

namespace IMJunior
{
    public sealed class Card : PaymentSystem
    {
        public Card() : base("Card") { }

        public override void TryPay() => Console.WriteLine("Вызов API банка эмитера карты Card...");
    }
}
