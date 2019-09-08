using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Player
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Weapon Weapon { get; private set; }
        public Movement Movement { get; private set; }

        public Player(string name, int age, Weapon playerWeapon, Movement playerMovement)
        {
            Name = name;
            Age = age;
            Weapon = playerWeapon;
            Movement = playerMovement;
        }
    }
}
