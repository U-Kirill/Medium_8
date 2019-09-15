using System;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class ConsoleElement : Rect
    {
        public IElementContent ElementContent { get; }

        public ConsoleElement(IElementContent elementContent, int positionX, int positionY, int width, int height) : base(positionX, positionY, width, height)
        {
            ElementContent = elementContent;
        }
    }
    class Rect
    {
        public int PositionX { get; }
        public int PositionY { get; }
        public int Width { get; }
        public int Height { get; }

        public Rect(int positionX, int positionY, int width, int height)
        {
            if(width < 3 || height < 3)
            {
                throw new InvalidOperationException("Rect must have size larger then 2");
            }

            if (!IsInAWindow())
                throw new InvalidOperationException();

            PositionX = positionX;
            PositionY = positionY;
            Width = width;
            Height = height;
        }

        bool IsInAWindow()
        {
            if (PositionX - Width < 0 || PositionX + Width >= Console.BufferWidth || PositionY - Height < 0 || PositionX + Height >= Console.BufferHeight)
                return false;
            else
                return true;
        }

        public bool Intersect(int xPosition, int yPosition)
        {
            return Math.Abs(xPosition - PositionX) <= Width / 2 && Math.Abs(yPosition - PositionY) <= Height / 2;
        }
    }
    class Cursor
    {
        public Cursor(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public void MoveLeft()
        {
            PositionX--;

            if (PositionX < 0)
                PositionX = 0;

        }
        public void MoveRight()
        {
            PositionX++;

            if (PositionX >= Console.BufferWidth)
                PositionX = Console.BufferWidth - 1;
        }
        public void MoveUp()
        {
            PositionY--;

            if (PositionY < 0)
                PositionY = 0;
        }
        public void MoveDown()
        {
            PositionY++;

            if (PositionY >= Console.BufferHeight)
                PositionY = Console.BufferHeight - 1;
        }

    }
    class Painter
    {
        public static void WriteAtPosition(int left, int top, char symbol)
        {
            Console.SetCursorPosition(left,top);
            Console.Write(symbol);
        }
    }
    class CursorPainter : Painter
    {
        public static void Paint(Cursor cursor)
        {
            WriteAtPosition(cursor.PositionX, cursor.PositionY, '†');
        }
    }
    class ElementPainter : Painter
    {
        public static void Paint(ConsoleElement consoleElement)
        {
            DrawRect(consoleElement);
            DrawContent(consoleElement.ElementContent, consoleElement);
        }
        static void DrawRect(Rect rect)
        {
            for (int i = 0; i < rect.Width; i++)
            {
                WriteAtPosition(rect.PositionX - rect.Width / 2 + i, rect.PositionY - rect.Height / 2, '═');
                WriteAtPosition(rect.PositionX - rect.Width / 2 + i, rect.PositionY + rect.Height / 2, '═');
            }

            for (int i = 0; i < rect.Height; i++)
            {
                WriteAtPosition(rect.PositionX - rect.Width / 2, rect.PositionY - rect.Height / 2 + i, '║');
                WriteAtPosition(rect.PositionX + rect.Width / 2, rect.PositionY - rect.Height / 2 + i, '║');
            }

            WriteAtPosition(rect.PositionX - rect.Width / 2, rect.PositionY - rect.Height / 2, '╔');
            WriteAtPosition(rect.PositionX - rect.Width / 2, rect.PositionY + rect.Height / 2, '╚');
            WriteAtPosition(rect.PositionX + rect.Width / 2, rect.PositionY - rect.Height / 2, '╗');
            WriteAtPosition(rect.PositionX + rect.Width / 2, rect.PositionY + rect.Height / 2, '╝');
        }
        static void DrawContent(IElementContent elementContent, Rect rect)
        {
            if(elementContent is Checkbox checkbox)
            {
                char Checkmark;
                if (checkbox.Active)
                    Checkmark = '█';
                else
                    Checkmark = '\0';
                WriteAtPosition(rect.PositionX, rect.PositionY, Checkmark);
            }

            if(elementContent is TextField textField)
            {
                PrintAllTextInRect(textField.Text, rect);
            }
           
        }
        static void PrintAllTextInRect(string text, Rect rect)
        {
            for (int i = 1; i < rect.Height; i++)
            {
                for (int j = 1; j < rect.Width; j++)
                {

                    if (((i -1) * (rect.Width - 1)) + j -1 < text.Length)
                        WriteAtPosition(rect.PositionX - rect.Width/2 + j, rect.PositionY - rect.Height/2 + i, text[((i - 1) * (rect.Width - 1)) + j -1]);
                }
            }
        }
    }
}
