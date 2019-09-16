namespace ConsoleApp
{
    class ElementPainter : Painter
    {
        public static void Paint(ConsoleElement consoleElement)
        {
            PaintRect(consoleElement);
            PaintContent(consoleElement.ElementContent, consoleElement);
        }
        static void PaintRect(Rect rect)
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
        static void PaintContent(IElementContent elementContent, Rect rect)
        {
            if (elementContent is Checkbox checkbox)
            {
                char Checkmark;
                if (checkbox.Active)
                    Checkmark = '█';
                else
                    Checkmark = '\0';
                WriteAtPosition(rect.PositionX, rect.PositionY, Checkmark);
            }

            if (elementContent is TextField textField)
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

                    if (((i - 1) * (rect.Width - 1)) + j - 1 < text.Length)
                        WriteAtPosition(rect.PositionX - rect.Width / 2 + j, rect.PositionY - rect.Height / 2 + i, text[((i - 1) * (rect.Width - 1)) + j - 1]);
                }
            }
        }
    }
}
