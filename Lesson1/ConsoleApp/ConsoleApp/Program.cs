using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ConsoleElement> consoleElements = new List<ConsoleElement>();
            Console.CursorVisible = false;

            Cursor cursor = new Cursor(Console.BufferWidth / 2, 10);
            ClickProcessor clickProcessor = new ClickProcessor();

            // Creating console elements

            consoleElements.Add(new ConsoleElement(new TextField("SIGN IN WINDOW"), 35, 2, 70, 3));
            consoleElements.Add(new ConsoleElement(new TextField("Login"), 5, 5, 10, 3));
            consoleElements.Add(new ConsoleElement(new InputField("Input Field"), 25, 5, 26, 3));

            consoleElements.Add(new ConsoleElement(new TextField("Password"), 5, 8, 10, 3));
            consoleElements.Add(new ConsoleElement(new InputField("Input Field"), 25, 8, 26, 3));

            consoleElements.Add(new ConsoleElement(new TextField("Stay logged in"), 8, 13, 16, 3));
            consoleElements.Add(new ConsoleElement(new Checkbox(), 19, 13, 3, 3));

            consoleElements.Add(new ConsoleElement(new Button(() => Console.Beep(), "ENTER"), 15,17,30,4));

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        cursor.MoveLeft();
                        break;

                    case ConsoleKey.UpArrow:
                        cursor.MoveUp();
                        break;

                    case ConsoleKey.RightArrow:
                        cursor.MoveRight();
                        break;

                    case ConsoleKey.DownArrow:
                        cursor.MoveDown();
                        break;

                    case ConsoleKey.Enter:
                        clickProcessor.Click(cursor, consoleElements);
                        break;
                }

                Console.Clear();
                foreach (ConsoleElement item in consoleElements)
                {
                    ElementPainter.Paint(item);
                }
                CursorPainter.Paint(cursor);
            }
        }
    }
}
