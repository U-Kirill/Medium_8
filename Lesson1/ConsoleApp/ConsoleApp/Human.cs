using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Human : Living
    {
        public int Agility { get; private set; }

        public Human(int agility, int health) : base(health)
        {
            Agility = agility;
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage / Agility);
        }
    }
}
