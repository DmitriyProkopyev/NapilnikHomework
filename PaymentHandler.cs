using System;

namespace IMJunior
{
    public class PaymentHandler
    {
        public void ShowPaymentResult(PaymentSystem system)
        {
            Console.WriteLine($"Вы оплатили с помощью {system.ID}");

            system.ShowPaymentResult();

            Console.WriteLine("Оплата прошла успешно!");
        }
    }
}
