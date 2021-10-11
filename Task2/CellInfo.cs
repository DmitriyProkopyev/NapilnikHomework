namespace Task2
{
    internal class CellInfo
    {
        private readonly Cell _cell;

        public string Name => _cell.Good.Name;
        public int Count => _cell.Count;

        public CellInfo(Cell cell)
        {
            _cell = cell;
        }
    }
}