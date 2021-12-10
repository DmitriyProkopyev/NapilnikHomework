namespace Task2
{
    public class Cart
    {
        private readonly Warehouse _warehouse;
        private readonly Dictionary<Good, int> _goods;

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
            _goods = new Dictionary<Good, int>();
        }

        public IEnumerable<KeyValuePair<Good, int>> Goods => _goods;

        public void Add(Good good, int count)
        {
            _warehouse.Ship(good, count);

            if (_goods.Keys.Contains(good))
                _goods[good] += count;
            else
                _goods.Add(good, count);
        }

        public Order Order() => new Order("paylink");
    }
}
