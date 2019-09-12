using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Storage
    {
        public Currency Currency { get; }
        public int Quantity { get; set; }

        public Storage(Currency currency, int quantity)
        {
            Currency = currency;
            Quantity = quantity;
        }
    }
}
