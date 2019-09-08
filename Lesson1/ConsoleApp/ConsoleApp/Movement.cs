using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Movement
    {
        public float DirectionX { get; private set; }
        public float DirectionY { get; private set; }
        public float Speed { get; private set; }

        public Movement(float movementDirectionX, float movementDirectionY, float movementSpeed)
        {
            DirectionX = movementDirectionX;
            DirectionY = movementDirectionY;
            Speed = movementSpeed;
        }

        public void Move()
        {
            //Do move
        }
    }
}
