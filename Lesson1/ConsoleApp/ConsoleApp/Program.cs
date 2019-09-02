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
            List<Object> objects = new List<Object>();

            objects.Add(new Object(5, 5, true));
            objects.Add(new Object(10, 10, true));
            objects.Add(new Object(15, 15, true));


            while (true)
            {
                CheckForCollide(objects[1], objects[2]);
                CheckForCollide(objects[1], objects[3]);
                CheckForCollide(objects[2], objects[3]);

                for (int i = 0; i < objects.Count; i++)
                {
                    objects[i].RandomMove();
                    TryVsualize(objects[i], i);
                }

                void CheckForCollide(Object object1, Object object2)
                {
                    if (object1.Xpositions == object2.Xpositions && object1.Ypositions == object2.Ypositions)
                    {
                        object1.IsAlive = false;
                        object1.IsAlive = false;
                    }
                }

                void TryVsualize(Object _object, int index)
                {
                    if (_object.IsAlive)
                    {
                        Console.SetCursorPosition(_object.Xpositions, _object.Ypositions);
                        Console.Write(index + 1);
                    }
                }
            }
        }
    }
}
