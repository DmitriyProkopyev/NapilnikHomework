namespace Task2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var iPhone12 = new Good("IPhone 12");
            var iPhone11 = new Good("IPhone 11");
            
            var warehouse = new Warehouse();

            var shop = new Shop(warehouse);

            warehouse.Delive(iPhone12, 10);
            warehouse.Delive(iPhone11, 1);

            foreach (var pair in warehouse.Goods)
                Show(pair.Key, pair.Value);

            Cart cart = shop.Cart();
            cart.Add(iPhone12, 4);
            cart.Add(iPhone11, 3);

            foreach (var pair in cart.Goods)
                Show(pair.Key, pair.Value);

            Console.WriteLine(cart.Order().Paylink);

            cart.Add(iPhone12, 9);
        }

        private static void Show(Good good, int count)
        {
            if (good is null)
                throw new ArgumentNullException(nameof(good));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            Console.WriteLine($"{good.Name} - {count}");
        }
    }
}
