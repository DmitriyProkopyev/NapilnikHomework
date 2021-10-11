using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Cart
    {
        private readonly Warehouse _warehouse;
        private readonly List<Cell> _cells;

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse;
            _cells = new List<Cell>();
        }

        public void Add(Good good, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (_warehouse.HasEnoughGoods(good, count) == false)
                throw new InvalidOperationException(nameof(good));

            var cell = _cells.Find(oldCell => oldCell.Good.Equals(good));

            if (cell is null)
            {
                var neededCell = _warehouse.Take(good, count);
                _cells.Add(neededCell);
            }
            else
                cell.Merge(count);
        }

        public void ShowInfo()
        {
            foreach (var cell in _cells)
                Console.WriteLine($"{cell.Good.Name} - {cell.Count}");
        }

        public Order GetOrder() => new Order("paylink");

        internal class Order
        {
            public readonly string Paylink;

            internal Order(string paylink)
            {
                Paylink = paylink;
            }
        }
    }
}