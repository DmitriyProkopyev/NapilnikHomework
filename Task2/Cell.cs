using System;

namespace Task2
{
    internal class Cell
    {
        public readonly Good Good;

        public int Count { get; private set; }

        public Cell(Good good, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            Good = good;
            Count = count;
        }

        public void Merge(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            Count += count;
        }

        public void Unmerge(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            Count -= count;
        }
    }
}
