namespace Task2
{
    public class Inventory : IInventory
    {
        private readonly List<Cell> _cells;

        public Inventory() => _cells = new List<Cell>();

        public IEnumerable<Cell> Cells => _cells;

        public void Add(Cell newCell)
        {
            if (TryFind(newCell.Good, out Cell cell))
            {
                int index = _cells.IndexOf(cell);
                _cells[index] = cell.Merge(newCell);
            }
            else
                _cells.Add(newCell);
        }

        public Cell Take(Cell required)
        {
            if (TryFind(required.Good, out Cell found) == false)
                throw new InvalidOperationException(nameof(required));

            if (required.Count > found.Count)
                throw new InvalidOperationException(nameof(required));

            if (required.Count < found.Count)
            {
                int index = _cells.IndexOf(found);
                _cells[index] = found.Unmerge(required);
            }
            else if (required.Count == found.Count)
                _cells.Remove(found);

            return required;
        }

        private bool TryFind(Good good, out Cell found)
        {
            if (good is null)
                throw new ArgumentNullException(nameof(good));

            int index = _cells.FindIndex(cell => cell.Good.Equals(good));
            found = _cells[index];

            return index != -1;
        }
    }
}