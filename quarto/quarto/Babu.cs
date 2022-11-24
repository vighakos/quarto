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
        public Image Img;
        public bool Szmotyi, Vilagos, Nagy, Karika;

        public Babu(int id, bool szmotyi, bool vilagos, bool nagy, bool karika)
        {
            ID = id;
            Img = Image.FromFile($"{ID}.png");
            Szmotyi = szmotyi;
            Vilagos = vilagos;
            Nagy = nagy;
            Karika = karika;
        }
    }
}
