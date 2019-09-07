using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Users
    {
        private List<User> _allUsers;

        public IEnumerable<User> GetAllUsers()
        {
            return _allUsers;
        }
        public void AddUser(User user)
        {
            _allUsers.Add(user);
        }

        public User GetUserById(int id)
        {
            return _allUsers.Find(x => x.Id == id);
        }

        public User GetUserByName(string name)
        {
            return _allUsers.Find(x => x.Name == name);
        }

        public List<User> GetUsersWhereMinSalary(int salary)
        {
            return _allUsers.FindAll(x => x.Salary >= salary);
        }

        public List<User> GetUsersWhereMaxSalary(int salary)
        {
            return _allUsers.FindAll(x => x.Salary <= salary);
        }

        public List<User> GetUsersWithSalaryBetween(int minSalary, int maxSalary)
        {
            return _allUsers.FindAll(x => x.Salary > minSalary && x.Salary < maxSalary);
        }
    }
}
