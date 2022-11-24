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
        static List<Cella> cellak;
        static List<Babu> babuk;
        static Player p1, p2, currentPlayer;
        public Game(string p1name, string p2name)
        {
            InitializeComponent();

            Setup(p1name, p2name);
        }

        private void Setup(string p1name, string p2name)
        {
            p1 = new Player(p1name);
            p2 = new Player(p2name);
            currentPlayer = new Random().Next(0, 2) == 1 ? p1 : p2;

            babuk = new List<Babu>();
            for (int i = 0; i < 16; i++)
            {
                babuk.Add(new Babu(i, Convert.ToBoolean(i / 8 % 2), Convert.ToBoolean(i / 4 % 2), Convert.ToBoolean(i / 2 % 2), Convert.ToBoolean(i % 2)));
                comboBox1.Items.Add($"{babuk[i].ID}: {babuk[i].Szmotyi}, {babuk[i].Vilagos}, {babuk[i].Nagy}, {babuk[i].Karika}");
            }

            cellak = new List<Cella>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PictureBox uj = new PictureBox()
                    {
                        Location = new Point(250 + j * 50, 10 + i * 50),
                        Size = new Size(40, 40),
                        BackColor = Color.Black,
                        Name = $"{i}_{j}"
                    };
                    cellak.Add(new Cella(uj, i, j, true));
                    uj.Click += new EventHandler(Cella_Click);
                    Controls.Add(uj);
                }
            }

            UpdateLabels();
        }

        private void Cella_Click(object sender, EventArgs e)
        {
            PictureBox item = (PictureBox)sender;

            Cella kattolt = cellak.Find(x => x.X == Convert.ToInt32(item.Name.Split('_')[0]) && x.Y == Convert.ToInt32(item.Name.Split('_')[1]));

            if (kattolt.Szabad)
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Válassz ki egy bábut!");
                    return;
                }
                else
                {
                    Babu selectedBabu = babuk.Find(x => x.ID == Convert.ToInt32(comboBox1.SelectedItem.ToString().Split(':')[0]));
                    kattolt.Babu = selectedBabu;
                    kattolt.Pbox.Image = selectedBabu.Img;
                    comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                    babuk.Remove(selectedBabu);
                    kattolt.Szabad = false;
                    selectedBabu = null;
                }
            }
            else
            {
                MessageBox.Show($"{kattolt.X}, {kattolt.Y}: {kattolt.Babu.ID}, {kattolt.Babu.Szmotyi}, {kattolt.Babu.Vilagos}, {kattolt.Babu.Nagy}, {kattolt.Babu.Karika}");
            }

        }

        private void UpdateLabels()
        {
            p1Lbl.Text = $"{p1.Name}: {p1.Victories}";
            p2Lbl.Text = $"{p2.Name}: {p2.Victories}";

            kijonLbl.Text = $"{currentPlayer.Name} következik idk";
        }
    }
}
