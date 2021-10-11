using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Warehouse
    {
        private readonly List<Cell> _cells;

        public Warehouse()
        {
            _cells = new List<Cell>();
        }

        public CellInfo this[int index] => new CellInfo(_cells[index]);
        public int CountOfCells => _cells.Count;

        public void Delive(Good good, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            var cell = Find(good);

            if (cell is null)
                _cells.Add(new Cell(good, count));
            else
                cell.Merge(count);
        }

        public Cell Take(Good good, int count)
        {
            if (HasEnoughGoods(good, count) == false)
                throw new InvalidOperationException(nameof(good));

            var cell = Find(good);

            if (cell.Count == count)
            {
                _cells.Remove(cell);
                return cell;
            }
            else
            {
                cell.Unmerge(count);
                return new Cell(cell.Good, count);
            }
        }

        public bool HasEnoughGoods(Good good, int count)
        {
            var cell = Find(good);
            return cell != null && cell.Count >= count;
        }

        private Cell Find(Good good) => _cells.Find(cell => cell.Good.Equals(good));
    }
}
