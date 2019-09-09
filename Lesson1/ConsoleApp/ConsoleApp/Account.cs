using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    abstract class Action
    {
        public Action(Account account, Bank bank)
        {
            Account = account;
            Bank = bank;
        }
        public Account Account { get; }
        public Bank Bank { get; }

        public abstract void Do();
        public abstract void Undo();
    }
    class CreateAccount : Action
    {
        private string _name;

        public CreateAccount(Account account, Bank bank, string name) : base(account, bank)
        {
            _name = name;
        }
        
        public override void Do()
        {
            Bank.CreateAccount(_name);
        }

        public override void Undo()
        {
            Bank.CloseAccount(_name);
        }
    }

    class CloseAccount : Action
    {
        private string _name;

        public CloseAccount(Account account, Bank bank, string name) : base(account, bank)
        {
            _name = name;
        }

        public override void Do()
        {
            Bank.CloseAccount(_name);            
        }

        public override void Undo()
        {
            Bank.CreateAccount(_name);
        }
    }
    class TransferMoney : Action
    {
        private string _nameFrom;
        private string _nameTo;
        private int _quantity;

        public TransferMoney(Account account, Bank bank, string nameFrom, string nameTo, int quantity) : base(account, bank)
        {
            _nameFrom = nameFrom;
            nameTo = _nameTo;
            quantity = _quantity;
        }

        public override void Do()
        {
            Bank.TransferMoney(_nameFrom, _nameTo, _quantity);
        }

        public override void Undo()
        {
            Bank.TransferMoney(_nameTo, _nameFrom, _quantity);
        }
    }


    class Bank
    {
        private List<Account> Accounts = new List<Account>();

        public void CreateAccount(string name)
        {
            Accounts.Add(new Account(Accounts.Count, name, new RussianRuble()));
        }

        public void CloseAccount(string name)
        {
            Accounts.RemoveAll(account => account.Name == name);
        }

        public void TransferMoney(string NameFrom, string NameTo, int quantity)
        {
            Account accountFrom = Accounts.First(accounts => accounts.Name == NameFrom);
            Account accountTo = Accounts.First(accounts => accounts.Name == NameTo);

            accountFrom.WithdrawMoney(quantity);
            accountTo.AddMoney(quantity);
        }
    }

    class Account
    {
        public int Id { get; }
        public string Name { get; }

        private Storage Storage;

        public Account(int id, string name, Currency currency)
        {
            Id = id;
            Name = name;
            Storage = new Storage(currency, 0);
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

    class Storage
    {
        public Currency Currency { get; }
        public int Quantity { get;  set; }

        public Storage(Currency currency, int quantity)
        {
            Currency = currency;
            Quantity = quantity;
        }
    }
    abstract class Currency
    {

    }
    
    class RussianRuble : Currency
    {

    }
}
