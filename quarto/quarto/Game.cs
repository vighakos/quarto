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
            {
                babuk.Add(new Babu(i, Convert.ToBoolean(i / 8 % 2), Convert.ToBoolean(i / 4 % 2), Convert.ToBoolean(i / 2 % 2), Convert.ToBoolean(i % 2)));
                comboBox1.Items.Add(babuk[i].Kiir());
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
                    comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                    babuk.Remove(selectedBabu);
                    kattolt.Szabad = false;
                    
                    selectedPbox.BackColor = Color.Transparent;
                    selectedPbox.Visible = false;
                    selectedPbox = null;

                    lerakottBabuk.Add(kattolt);

                    Check(kattolt);

                    kovetkezo = true;
                    button1.Enabled = true;
                }
            }
        }

        private void Check(Cella kattolt)
        {
            List<Cella> kattoltSor = lerakottBabuk.FindAll(x => x.Y == kattolt.Y);
            List<Cella> kattoltOszlop = lerakottBabuk.FindAll(x => x.X == kattolt.X);

            if (kattoltSor.Count == 4) negyCheck(kattoltSor);
            if (kattoltOszlop.Count == 4) negyCheck(kattoltOszlop);
        }

        private void negyCheck(List<Cella> lista)
        {
            /*
            for (int i = 0; i < lista.Count; i++)
            {
                int counter = 0;
                bool talalt = false;
                for (int j = 0; j < lista.Count; j++)
                {
                    if (lista[i].Babu.Sotet == lista[j].Babu.Sotet)
                    {
                        counter++;
                        if (counter == 4) Win();
                    }
                    if (lista[i].Babu.Szmotyi == lista[j].Babu.Szmotyi)
                    {
                        counter++;
                        if (counter == 4) Win();
                    }
                    if (lista[i].Babu.Nagy == lista[j].Babu.Nagy)
                    {
                        counter++;
                        if (counter == 4) Win();
                    }
                    if (lista[i].Babu.Karika == lista[j].Babu.Karika)
                    {
                        counter++;
                        if (counter == 4) Win();
                    }
                    if (talalt) continue;
                    else break;
                }
            }
            */
        }

        private void Win()
        {
            MessageBox.Show($"{currentPlayer.Name} nyert");
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
                comboBox1.SelectedItem = babuk.Find(x => x.ID.ToString() == selectedPbox.Name.Split('_')[1]).Kiir();
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

            ToolTip tt = new ToolTip();
            tt.SetToolTip(hover.Pbox, hover.Babu == null ? "Üres" : hover.Babu.Kiir());
        }

        private void UpdateLabels()
        {
            p1Lbl.Text = $"{p1.Name}: {p1.Victories}";
            p2Lbl.Text = $"{p2.Name}: {p2.Victories}";

            kijonLbl.Text = $"{currentPlayer.Name} következik idk";
        }
    }
}
