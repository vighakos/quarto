using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quarto
{
    class Babu
    {
        public int ID;
        //private Image img;
        public bool Szmotyi, Feher, Nagy, Karika;

        public Babu(int id, bool szmotyi, bool feher, bool nagy, bool karika)
        {
            ID = id;
            //img = Image.FromFile($"{ID}.png");
            Szmotyi = szmotyi;
            Feher = feher;
            Nagy = nagy;
            Karika = karika;
        }
    }
}
