using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int xPosition, int yPosition)
        {
            X = xPosition;
            Y = yPosition;
        }

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }

        public void MakeNonNegative()
        {
            if (X < 0)
                X = 0;

            if (Y < 0)
                Y = 0;
        }
    }
}
