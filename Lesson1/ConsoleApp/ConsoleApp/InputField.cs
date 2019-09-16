using System;

namespace ConsoleApp
{
    public class InputField : TextField, IElementContent
    {

        public InputField(string text) : base(text)
        {

        }


        public override void OnClick()
        {
            Console.Clear();
            Console.WriteLine("Нажмите ESC для возвращения");

            string text = string.Empty;
            

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            while (keyInfo.Key != ConsoleKey.Escape)
            {
                text += keyInfo.KeyChar;
                keyInfo = Console.ReadKey();
            }

            SetText(text);
        }
    }
}
