using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Bank
    {
        private List<Account> _accounts = new List<Account>();
        private List<BankAction> _actions = new List<BankAction>();
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

        public void AddAction(BankAction action)
        {
            _actions.Add(action);
        }
        public void Rollback()
        {
            if (_actions.Count < 1)
                return;

            BankAction action = _actions[_actions.Count - 1];
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
}
