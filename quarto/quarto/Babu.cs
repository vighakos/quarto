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
        public bool Szmotyi, Szin, Magas, Karika;

        public Babu(int id, bool szmotyi, bool szin, bool magas, bool karika)
        {
            ID = id;
            //img = Image.FromFile($"{ID}.png");
            Szmotyi = szmotyi;
            Szin = szin;
            Magas = magas;
            Karika = karika;
        }
    }
}
