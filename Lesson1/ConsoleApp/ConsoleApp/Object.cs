using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Object
    {
        private int _xPosition;
        private int _yPosition;
        private bool _isAlive;
        private Random random = new Random();

        public Object (int xPosition, int yPosition,bool isAlive)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _isAlive = isAlive;
        }

        public int Xpositions => _xPosition;
        public int Ypositions => _yPosition;
        public bool IsAlive { get { return _isAlive; } set { _isAlive = value; } }

        public void RandomMove()
        {
            _xPosition += random.Next(-1, 1);
            _yPosition += random.Next(-1, 1);

            if (_xPosition < 0)
                _xPosition = 0;

            if (_yPosition < 0)
                _yPosition = 0;
        }
    }
}
