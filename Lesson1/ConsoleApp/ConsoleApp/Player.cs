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
        public Weapon PlayerWeapon { get; private set; }
        public Movement PlayerMovement { get; private set; }

        public Player(string name, int age, Weapon playerWeapon, Movement playerMovement)
        {
            Name = name;
            Age = age;
            PlayerWeapon = playerWeapon;
            PlayerMovement = playerMovement;
        }
    }

    class Weapon
    {
        public float WeaponCooldown { get; private set; }
        public int WeaponDamage { get; private set; }

        public Weapon(float weaponCooldown, int weaponDamage)
        {
            WeaponCooldown = weaponCooldown;
            WeaponDamage = weaponDamage;
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
    class Movement
    {
        public float MovementDirectionX { get; private set; }
        public float MovementDirectionY { get; private set; }
        public float MovementSpeed { get; private set; }

        public Movement(float movementDirectionX, float movementDirectionY, float movementSpeed)
        {
            MovementDirectionX = movementDirectionX;
            MovementDirectionY = movementDirectionY;
            MovementSpeed = movementSpeed;
        }

        public void Move()
        {
            //Do move
        }
    }
}
