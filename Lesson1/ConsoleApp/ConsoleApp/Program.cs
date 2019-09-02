using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Bag // До этого делал классы в разных файлах, помню что это правильно во время обычной работы, 
    {         // но сейчас для удобства проверки засуну все в один файл. Можно ли так делать с учебыми заданиями? 
        private List<Item> _items;
        private int _maxWeidth;

        public Bag(List<Item> items, int maxWeidth)
        {
            _items = items;
            _maxWeidth = maxWeidth;
        }

        public List<Item> Items => _items;
        public int MaxWeidth => _maxWeidth;

        public void AddItem(string name, int count)
        {
            int currentWeidth = _items.Sum(item => item.Count);
            Item targetItem = _items.FirstOrDefault(item => item.Name == name);

            if (targetItem == null)
                throw new InvalidOperationException();

            if (currentWeidth + count > _maxWeidth)
                throw new InvalidOperationException();

            targetItem.Count += count;
        }
    }

    class Item
    {
        private int _count;
        private string _name;

        public Item(string name, int count)
        {
            _name = name;
            _count = count;
        }

        public int Count { get { return _count; } set { _count = value; } }
        public string Name => _name;
    }
}
