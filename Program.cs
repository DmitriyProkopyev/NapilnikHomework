namespace IMJunior
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderForm = new OrderForm();
            var paymentHandler = new PaymentHandler();

            string systemId = orderForm.ShowForm();

            var paymentSystem = PaymentSystem.Choose(systemId);

            paymentHandler.ShowPaymentResult(paymentSystem);
        }
    }
}
