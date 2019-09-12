using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Living
    {
        public int Health { get; private set; }

        public Living(int health)
        {
            Health = health;
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Console.WriteLine("Я умер");
            }
        }
    }
}
