using System.IO;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Reader
    {
        public virtual IEnumerable<string> Read(string path)
        {
            return File.ReadLines(path);
        }
    }
}
