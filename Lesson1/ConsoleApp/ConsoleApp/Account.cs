using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    abstract class Action
    {
        public Action(Bank bank)
        {
            Bank = bank;
        }
        public Bank Bank { get; }

        public abstract void Do();
        public abstract void Undo();
    }
    class CreateAccount : Action
    {
        private string _name;
        private int _quantity;

        public CreateAccount(Bank bank, string name, int quantity) : base( bank)
        {
            if (quantity < 0)
                throw new InvalidOperationException();

            _name = name;
            _quantity = quantity;
        }
        
        public override void Do()
        {
            Bank.CreateAccount(_name, _quantity);
            Bank.AddAction(this);
        }

        public override void Undo()
        {
            Bank.CloseAccount(_name);
        }
    }

    class CloseAccount : Action
    {
        private string _name;
        private int _quantity;

        public CloseAccount(Bank bank, string name, int quantity) : base(bank)
        {
            if (quantity < 0)
                throw new InvalidOperationException();

            _name = name;
            _quantity = quantity;
        }

        public override void Do()
        {
            Bank.CloseAccount(_name);
            Bank.AddAction(this);
        }

        public override void Undo()
        {
            Bank.CreateAccount(_name, _quantity);
        }
    }
    class TransferMoney : Action
    {
        private string _sender;
        private string _recipient;
        private int _quantity;

        public TransferMoney(Bank bank, string sender, string recipient, int quantity) : base(bank)
        {
            _sender = sender;
            _recipient = recipient;
            _quantity = quantity;
        }

        public override void Do()
        {
            Bank.TransferMoney(_sender, _recipient, _quantity);
            Bank.AddAction(this);
        }

        public override void Undo()
        {
            Bank.TransferMoney(_recipient, _sender, _quantity);
        }
    }


    class Bank
    {
        private List<Account> _accounts = new List<Account>();
        private List<Action> _actions = new List<Action>();
        private int _id = 0;

        public void CreateAccount(string name, int quantity)
        {
            Account newAccount = new Account(_id, name, new RussianRuble(), quantity);

            if (!_accounts.Exists(user => user.Name == name))
            {
                _accounts.Add(newAccount);
            }
            else
            {
                throw new InvalidOperationException();
            }
            _id++;
        }

        public void CloseAccount(string name)
        {
            if (_accounts.Exists(account => account.Name == name))
            {
                _accounts.RemoveAll(account => account.Name == name);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void TransferMoney(string NameFrom, string NameTo, int quantity)
        {
            Account accountFrom = _accounts.First(accounts => accounts.Name == NameFrom);
            Account accountTo = _accounts.First(accounts => accounts.Name == NameTo);

            accountFrom.WithdrawMoney(quantity);
            accountTo.AddMoney(quantity);
        }

        public void AddAction(Action action)
        {
            _actions.Add(action);
        }
        public void Rollback()
        {
            if (_actions.Count < 1)
                return;

            Action action = _actions[_actions.Count - 1];
            action.Undo();
            _actions.Remove(action);
        }

        public Account GetAccountByName(string name)
        {
           return _accounts.First(account => account.Name == name);
        }
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }
    }

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
