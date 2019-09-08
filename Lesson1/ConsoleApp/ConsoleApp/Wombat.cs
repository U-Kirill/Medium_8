using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Wombat : Living
    {
        public int Armor { get; private set; }

        public Wombat(int armor, int health) : base(health)
        {
            Armor = armor;
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage - Armor);
        }
    }
}
