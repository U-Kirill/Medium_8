namespace ConsoleApp
{
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
}
