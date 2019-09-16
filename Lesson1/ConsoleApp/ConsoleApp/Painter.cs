using System;

namespace ConsoleApp
{
    class Painter
    {
        public static void WriteAtPosition(int left, int top, char symbol)
        {
            Console.SetCursorPosition(left,top);
            Console.Write(symbol);
        }
    }
}
