using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Cell
    {
        public int Count;
        public Item Item { get; }

        public Cell(Item item)
        {
            Item = item;
        }
    }
}
