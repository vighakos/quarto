using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quarto
{
    public partial class Game : Form
    {
        static List<Babu> babuk;
        static Player p1, p2, currentPlayer;
        public Game(string p1name, string p2name)
        {
            InitializeComponent();

            Setup(p1name, p2name);
        }

        private void Setup(string p1name, string p2name)
        {
            // player kezdőke

            Graphics myGraphics = base.CreateGraphics();
            Pen myPen = new Pen(Color.Black);
            SolidBrush mySolidBrush = new SolidBrush(Color.Black);
            myGraphics.DrawEllipse(myPen, 50, 50, 150, 150);


            // lista feltöltőke
            // i / 16 % 2, i / 8 % 2, i / 4 % 2, i % 2
        }
    }
}
