using System;

namespace IMJunior
{
    public abstract class PaymentSystem
    {
        public readonly string ID;

        public PaymentSystem(string id)
        {
            ID = id;
        }

        public static PaymentSystem Choose(string id)
        {
            switch (id)
            {
                case "QIWI":
                    return new Qiwi();
                case "WebMoney":
                    return new WebMoney();
                case "Card":
                    return new Card();
            }

            throw new ArgumentException(nameof(id));
        }

        public void ShowPaymentResult() => Console.WriteLine($"Проверка платежа через {ID}...");

        public abstract void TryPay();
    }
}
