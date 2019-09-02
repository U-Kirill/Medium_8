using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class User
    {
        private int _id;
        private string _name;
        private int _salary;

        User(int id, string name, int salary)
        {
            _id = id;
            _name = name;
            _salary = salary;
        }

        public int Id => _id;
        public string Name => _name;
        public int Salary => _salary;
    }
}
