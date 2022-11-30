﻿using System;
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
        static PictureBox selectedPbox = null;
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

            if (selectedPbox != null)
            {
                selectedPbox.BackColor = Color.Transparent;
                selectedPbox.Visible = false;
                selectedPbox = null;
            }
        }

        private void p_Valaszt(object sender, EventArgs e)
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
