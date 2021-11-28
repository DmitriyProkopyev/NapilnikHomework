namespace Task2
{
    public class Cart
    {
        private readonly Warehouse _warehouse;
        private readonly Inventory _inventory;

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
            _inventory = new Inventory();
        }

        public IInventory Inventory => _inventory;

        public void Add(Good good, int count)
        {
            var cell = _warehouse.Ship(good, count);
            _inventory.Add(cell);
        }

        public Order Order() => new Order("paylink");
    }
}
