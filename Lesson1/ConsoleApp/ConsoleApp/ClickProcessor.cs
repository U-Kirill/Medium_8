using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class ClickProcessor
    {
        public void Click(Cursor cursor, List<ConsoleElement> consoleElements)
        {
            ConsoleElement consoleElement = consoleElements.Find(element => element.Intersect(cursor.PositionX, cursor.PositionY));
            if (consoleElement != null)
                consoleElement.ElementContent.OnClick();
        }
    }
}
