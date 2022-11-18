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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (player1.Text == "" || player2.Text == "") { MessageBox.Show("Írj be egy nevet!", "Error"); return; }
            if (player1.Text == player2.Text) { MessageBox.Show("A nevek nem egyezhetnek", "Error"); return; }

            Form gameForm = new Game(player1.Text, player2.Text);
            this.Visible = false;
            gameForm.ShowDialog();
            Close();
        }
    }
}
