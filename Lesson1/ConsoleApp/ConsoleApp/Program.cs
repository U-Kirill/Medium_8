using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            string name = string.Empty;
            string operation = string.Empty;
            int quantity = 0;

            while (true)
            {
                ShowUsers(bank);

                Console.WriteLine("Введите имя");
                name = Console.ReadLine().ToLower();

                Console.WriteLine("Что вы хотите сделать? (создать / перевести / закрыть / undo)");
                operation = Console.ReadLine().ToLower();

                switch (operation)
                {
                    case "создать":
                        Console.WriteLine("Сколько денег положить на счет клиенту");
                        GetIntFromConsole(out quantity);

                        CreateAccount createAccount = new CreateAccount(bank, name, quantity);
                        createAccount.Do();
                        break;

                    case "перевести":
                        Console.WriteLine("Кому вы хотите перевести деньги?");
                        string recipient = Console.ReadLine().ToLower();

                        Console.WriteLine("Сколько денег перевести на счет клиенту");
                        GetIntFromConsole(out quantity);

                        TransferMoney transferMoney = new TransferMoney(bank, name, recipient, quantity);
                        transferMoney.Do();
                        break;

                    case "закрыть":
                        CloseAccount closeAccount = new CloseAccount(bank, name, bank.GetAccountByName(name).Quantity);
                        closeAccount.Do();
                        break;

                    case "undo":
                        bank.Rollback();
                        break;
                }

                Console.WriteLine();
            }
        }

        static void GetIntFromConsole(out int value)
        {
            string line;
            do
            {
                line = Console.ReadLine();
            }
            while (!int.TryParse(line, out value));
        }

        static void ShowUsers(Bank bank)
        {
            foreach (Account account in bank.GetAllAccounts())
            {
                Console.WriteLine(account.Name +" "+account.Quantity);
            }
        }
    }
}
