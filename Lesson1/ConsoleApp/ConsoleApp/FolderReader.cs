using System.IO;
using System.Collections.Generic;


namespace ConsoleApp
{
    class FolderReader : Reader
    {
        public override IEnumerable<string> Read(string path)
        {
            List<string> text = new List<string>();

            for (int i = 1; i < int.MaxValue; i++)
            {
                if (File.Exists(Path.Combine(path, i + ".txt")))
                    text.AddRange(base.Read(Path.Combine(path, i + ".txt")));
                else
                    break;
            }
            return text;
        }
    }
}
