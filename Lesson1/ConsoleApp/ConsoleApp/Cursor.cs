using System;

namespace ConsoleApp
{
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
}
