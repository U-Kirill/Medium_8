using System;

namespace ConsoleApp
{
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
}
