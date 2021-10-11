using System;

namespace Task2
{
    class Shop
    {
        private readonly Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void ShowInfo()
        {
            for (int i = 0; i < _warehouse.CountOfCells; i++)
            {
                var cell = _warehouse[i];
                string name = cell.Name;
                int count = cell.Count;
                Console.WriteLine($"{name} - {count}\n");
            }
        }

        public Cart GetCart() => new Cart(_warehouse);
    }
}