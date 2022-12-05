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
        static List<Cella> lerakottBabuk;
        static List<Babu> babuk;
        static Player p1, p2, currentPlayer;
        static PictureBox selectedPbox = null;
        static bool kovetkezo = true;

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
                babuk.Add(new Babu(i, Convert.ToBoolean(i / 8 % 2), Convert.ToBoolean(i / 4 % 2), Convert.ToBoolean(i / 2 % 2), Convert.ToBoolean(i % 2)));

            cellak = new List<Cella>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PictureBox uj = new PictureBox()
                    {
                        Location = new Point(250 + j * 50, 50 + i * 50),
                        Size = new Size(40, 40),
                        BackColor = Color.White,
                        Name = $"{i}_{j}",
                        SizeMode = PictureBoxSizeMode.CenterImage
                    };
                    cellak.Add(new Cella(uj, i, j, true));
                    uj.Click += new EventHandler(Cella_Click);
                    uj.MouseHover += new EventHandler(Cella_Hover);
                    Controls.Add(uj);
                }
            }

            lerakottBabuk = new List<Cella>();

            p1Lbl.Text = $"{p1.Name} vs {p2.Name}";
            valasztottLbl.Text = "Nincs kiválasztott bábu"; 

            UpdateLabels();
        }

        private void Cella_Click(object sender, EventArgs e)
        {            
            if (!kovetkezo)
            {
                PictureBox item = (PictureBox)sender;
                Cella kattolt = cellak.Find(x => x.X == Convert.ToInt32(item.Name.Split('_')[0]) && x.Y == Convert.ToInt32(item.Name.Split('_')[1]));

                if (kattolt.Szabad)
                {
                    Babu selectedBabu = babuk.Find(x => x.ID == Convert.ToInt32(selectedPbox.Name.Split('_')[1]));
                    kattolt.Babu = selectedBabu;
                    kattolt.Pbox.Image = selectedBabu.Img;
                    babuk.Remove(selectedBabu);
                    kattolt.Szabad = false;
                    
                    selectedPbox.BackColor = Color.Transparent;
                    selectedPbox.Visible = false;
                    selectedPbox = null;

                    lerakottBabuk.Add(kattolt);

                    valasztottLbl.Text = "Nincs kiválasztott bábu";

                    Check(kattolt);

                    if (lerakottBabuk.Count == 16) Draw();

                    kovetkezo = true;
                    button1.Enabled = true;
                }
            }
        }

        private void Check(Cella kattolt)
        {
            NegyCheck(lerakottBabuk.FindAll(x => x.X == kattolt.X));
            NegyCheck(lerakottBabuk.FindAll(x => x.Y == kattolt.Y));
            NegyCheck(lerakottBabuk.FindAll(x => x.X == x.Y));
            NegyCheck(lerakottBabuk.FindAll(x => x.X + x.Y == 3));
        }

        private void NegyCheck(List<Cella> lista)
        {
            if (lista.Count == 4)
            {
                int counter1 = 0, counter2 = 0, counter3 = 0, counter4 = 0;
                for (int i = 1; i < lista.Count; i++)
                {
                    if (lista[0].Babu.Sotet == lista[i].Babu.Sotet) counter1++;
                    if (lista[0].Babu.Szmotyi == lista[i].Babu.Szmotyi) counter2++;
                    if (lista[0].Babu.Nagy == lista[i].Babu.Nagy) counter3++;
                    if (lista[0].Babu.Karika == lista[i].Babu.Karika) counter4++;
                }

                if (counter1 == 3 || counter2 == 3 || counter3 == 3 || counter4 == 3)
                {
                    foreach (Cella item in lista) item.Pbox.BackColor = Color.Green;

                    Win();
                }
            }
        }

        private void p_Valaszt(object sender, EventArgs e)
        {            
            if (kovetkezo)
            {
                PictureBox item = (PictureBox)sender;
                if (selectedPbox != null && item.Name != selectedPbox.Name)
                {
                    selectedPbox.BackColor = Color.Transparent;
                    selectedPbox = item;
                }
                else if (selectedPbox == null) selectedPbox = item;

                selectedPbox.BackColor = Color.Green;
                valasztottLbl.Text = babuk.Find(x => x.ID.ToString() == selectedPbox.Name.Split('_')[1]).Kiir();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedPbox != null)
            {
                kovetkezo = false;
                selectedPbox.BackColor = Color.Red;
                currentPlayer = currentPlayer == p1 ? p2 : p1;
                button1.Enabled = false;
                UpdateLabels();
            }
            else MessageBox.Show("Válassz ki egy bábut");
        }

        private void Cella_Hover(object sender, EventArgs e)
        {
            PictureBox item = (PictureBox)sender;
            Cella hover = cellak.Find(x => x.X == Convert.ToInt32(item.Name.Split('_')[0]) && x.Y == Convert.ToInt32(item.Name.Split('_')[1]));

            new ToolTip().SetToolTip(hover.Pbox, hover.Babu == null ? "Üres" : $"{hover.Babu.Kiir()}");
        }

        private void UpdateLabels()
        {
            kijonLbl.Text = $"{currentPlayer.Name} következik";
        }

        private void Win()
        {
            MessageBox.Show($"{currentPlayer.Name} nyert");
            Application.Restart();
        }

        private void Draw()
        {
            MessageBox.Show("A meccs döntetlen!");
            Application.Restart();
        }
    }
}
