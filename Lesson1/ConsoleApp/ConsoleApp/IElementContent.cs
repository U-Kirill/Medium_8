using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public interface IElementContent
    {
        void OnClick();
    }

    public class Checkbox : IElementContent
    {
        public bool Active { get; private set; }

        public void OnClick()
        {
            if (Active)
                Active = false;
            else
                Active = true;
        }
    }

    public class TextField : IElementContent
    {
        public string Text { get; private set; }

        public TextField(string text)
        {
            Text = text;
        }

        public void SetText(string newText)
        {
            Text = newText;
        }
        public void AddChar(char newChar)
        {
            Text += newChar;
        }
        public virtual void OnClick()
        {

        }
    }
    public class Button : TextField, IElementContent
    {
        public Action Action { get; }

        public Button(Action action, string text) : base(text)
        {
            Action = action;
        }
        public override void OnClick()
        {
            Action?.Invoke();
        }
    }

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
