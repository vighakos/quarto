using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quarto
{
    class Cella
    {
        public PictureBox Pbox;
        public Babu Babu;
        public int X, Y;
        public bool Szabad;

        public Cella(PictureBox pbox, int x, int y, bool szabad)
        {
            Pbox = pbox;
            Babu = null;
            X = x;
            Y = y;
            Szabad = szabad;
        }
    }
}
