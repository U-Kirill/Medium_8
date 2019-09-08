using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Bag 
    {          

        public Bag(int maxWeidth)
        {
            MaxWeidth = maxWeidth;
        }

        public IEnumerable<Item> Items => _cells.Select(cell => cell.Item);
        public int MaxWeidth { get; }
        public int currentWeidth => _cells.Sum(cell => cell.Count);

        private List<Cell> _cells = new List<Cell>();

        public void AddItem(Item item, int count)
        {
            Cell targetCell = _cells.Find(cell => cell.Item == item);

            if (currentWeidth + count > MaxWeidth)
                throw new InvalidOperationException();

            if (targetCell == null)
            {
                targetCell = new Cell(item);
                _cells.Add(targetCell);
            }

            targetCell.Count += count;
        }

        public Item GetItem(string name)
        {
            Cell targetCell = _cells.First(cell => cell.Item.Name == name);
            return targetCell.Item;
        }
    }
}
