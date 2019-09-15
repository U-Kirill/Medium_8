namespace ConsoleApp
{
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
}
