namespace ConsoleApp
{
    class CursorPainter : Painter
    {
        public static void Paint(Cursor cursor)
        {
            WriteAtPosition(cursor.PositionX, cursor.PositionY, '†');
        }
    }
}
