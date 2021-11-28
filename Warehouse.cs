namespace Task2
{
    public class Warehouse
    {
        private readonly Inventory _inventory;

        public Warehouse() => _inventory = new Inventory();

        public IInventory Inventory => _inventory;

        public void Delive(Good good, int count)
        {
            var cell = new Cell(good, count);
            _inventory.Add(cell);
        }

        public Cell Ship(Good good, int count)
        {
            var required = new Cell(good, count);
            return _inventory.Take(required);
        }
    }
}
