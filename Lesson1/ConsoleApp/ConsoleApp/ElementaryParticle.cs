using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class ElementaryParticle
    {
        public Position Position { get; private set; }
        public bool IsAlive { get; set; }

        public ElementaryParticle (int xPosition, int yPosition,bool isAlive)
        {
            Position = new Position(xPosition, yPosition);
            IsAlive = isAlive;
        }       
        public void RandomMove(Random random)
        {
            Position.Move(random.Next(-1, 1), random.Next(-1, 1));

            Position.MakeNonNegative();
        }
        public void Intersect(ElementaryParticle otherElementaryParticle)
        {
            if (Position.X == otherElementaryParticle.Position.X && Position.Y == otherElementaryParticle.Position.Y)
            {
                IsAlive = false;
                otherElementaryParticle.IsAlive = false;
            }
        }
    }
}
