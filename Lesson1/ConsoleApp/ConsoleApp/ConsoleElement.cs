using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class ConsoleElement : Rect
    {
        public IElementContent ElementContent { get; }

        public ConsoleElement(IElementContent elementContent, int positionX, int positionY, int width, int height) : base(positionX, positionY, width, height)
        {
            ElementContent = elementContent;
        }
    }
}
