using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var good1 = new Good("good1");
            var good2 = new Good("good2");

            var warehouse = new Warehouse();

            var shop = new Shop(warehouse);

            warehouse.Delive(good1, 10);
            warehouse.Delive(good2, 1);

            shop.ShowInfo();

            Cart cart = shop.GetCart();
            cart.Add(good1, 4);
            cart.Add(good1, 3);

            cart.ShowInfo();

            Console.WriteLine(cart.GetOrder().Paylink);
        }
    }
}
