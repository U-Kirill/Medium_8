using System;

namespace ConsoleApp
{
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
}
