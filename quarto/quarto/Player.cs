using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quarto
{
    class Player
    {
        public string Name, Color;
        public int Victories;

        public Player(string name, string color)
        {
            Name = name;
            Color = color;
            Victories = 0;
        }
    }
}
