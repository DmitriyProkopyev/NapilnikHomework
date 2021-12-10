namespace Task2
{
    public class Warehouse
    {
        private readonly Dictionary<Good, int> _goods;

        public Warehouse() => _goods = new Dictionary<Good, int>();

        public IEnumerable<KeyValuePair<Good, int>> Goods => _goods;

        public void Delive(Good good, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (good is null)
                throw new ArgumentNullException(nameof(good));

            if (_goods.Keys.Contains(good))
                _goods[good] += count;
            else
                _goods.Add(good, count);
        }

        public void Ship(Good good, int count)
        {
            if (_goods.Keys.Contains(good) == false)
                throw new InvalidOperationException(nameof(good));

            if (count < _goods[good])
                throw new InvalidOperationException(nameof(count));

            _goods[good] -= count;
        }
    }
}
