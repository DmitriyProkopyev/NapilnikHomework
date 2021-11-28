using System;

namespace Task2
{
    public struct Cell
    {
        public readonly Good Good;
        public readonly int Count;

        public Cell(Good good, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            Good = good ?? throw new ArgumentNullException(nameof(good));
            Count = count;
        }

        public Cell Merge(Cell cell)
        {
            if (Good.Equals(cell.Good) == false)
                throw new InvalidOperationException(nameof(cell));

            return new Cell(Good, Count + cell.Count);
        }

        public Cell Unmerge(Cell cell)
        {
            if (Good.Equals(cell.Good) == false)
                throw new InvalidOperationException(nameof(cell));

            if (Count < cell.Count)
                throw new ArgumentException(nameof(cell.Count));

            return new Cell(Good, Count - cell.Count);
        }
    }
}
