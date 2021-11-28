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

            foreach (var cell in warehouse.Inventory.Cells)
                Show(cell);

            Cart cart = shop.Cart();
            cart.Add(iPhone12, 4);
            cart.Add(iPhone11, 3);

            foreach (var cell in cart.Inventory.Cells)
                Show(cell);

            Console.WriteLine(cart.Order().Paylink);

            cart.Add(iPhone12, 9);
        }

        private static void Show(Cell cell) => Console.WriteLine($"{cell.Good.Name} - {cell.Count}");
    }
}
