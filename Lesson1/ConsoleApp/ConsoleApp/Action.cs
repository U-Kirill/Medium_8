using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    abstract class BankAction
    {
        public BankAction(Bank bank)
        {
            Bank = bank;
        }
        public Bank Bank { get; }

        public abstract void Do();
        public abstract void Undo();
    }
    class CreateAccount : BankAction
    {
        private string _name;
        private int _quantity;

        public CreateAccount(Bank bank, string name, int quantity) : base(bank)
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

    class CloseAccount : BankAction
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
    class TransferMoney : BankAction
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
}
