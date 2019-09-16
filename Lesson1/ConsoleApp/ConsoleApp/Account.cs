using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Account
    {
        public int Id { get; }
        public string Name { get; }
        public int Quantity => Storage.Quantity;

        private Storage Storage;

        public Account(int id, string name, Currency currency, int quantity)
        {
            Id = id;
            Name = name;
            Storage = new Storage(currency, quantity);
        }

        public void AddMoney(int quantity)
        {
            if (quantity < 0)
                throw new InvalidOperationException();

            Storage.Quantity += quantity;
        }

        public void WithdrawMoney(int quantity)
        {
            if (Storage.Quantity - quantity < 0 || quantity < 0)
                throw new InvalidOperationException();

            Storage.Quantity -= quantity;
        }
    }   
}
