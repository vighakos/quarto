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
        public bool Szmotyi, Sotet, Nagy, Karika;

        public Babu(int id, bool sotet, bool szmotyi, bool nagy, bool karika)
        {
            ID = id;
            Img = Image.FromFile($"img/{ID}.png");
            Sotet = sotet;
            Szmotyi = szmotyi;
            Nagy = nagy;
            Karika = karika;
        }

        public string Kiir()
        {
            string sotete = Sotet ? "Sötét" : "Világos",
                   lyukase = Szmotyi ? "lyukas" : "lyuktalan",
                   nagye = Nagy ? "nagy" : "kicsi",
                   karikae = Karika ? "kör" : "négyzet";

            return $"{ID}: {sotete} {lyukase} {nagye} {karikae}";
        }
    }
}
