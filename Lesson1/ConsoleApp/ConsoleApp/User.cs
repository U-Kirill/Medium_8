using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Salary { get; private set; }

        public User(int id, string name, int salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }
    }
}
