using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            List<ElementaryParticle> objects = new List<ElementaryParticle>();

            objects.Add(new ElementaryParticle(5, 5, true));
            objects.Add(new ElementaryParticle(10, 10, true));
            objects.Add(new ElementaryParticle(15, 15, true));


            while (true)
            {
                for (int i = 0; i < objects.Count - 1; i++)
                {
                    for (int j = i; j < objects.Count - 1; j++)
                    {
                        objects[i].Intersect(objects[j + 1]);
                    }
                }

                for (int i = 0; i < objects.Count; i++)
                {
                    objects[i].RandomMove(random);
                    TryVsualize(objects[i], i);
                }
            }
        }
        static void TryVsualize(ElementaryParticle _object, int index)
        {
            if (_object.IsAlive)
            {
                Console.SetCursorPosition(_object.Position.X, _object.Position.Y);
                Console.Write(index + 1);
            }
        }
    }
}
