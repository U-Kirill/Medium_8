using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Weapon
    {
        public float Cooldown { get; private set; }
        public int Damage { get; private set; }

        public Weapon(float weaponCooldown, int weaponDamage)
        {
            Cooldown = weaponCooldown;
            Damage = weaponDamage;
        }

        public bool IsReloading()
        {
            throw new NotImplementedException();
        }
        public void Attack()
        {
            //Attack
        }
    }
}
