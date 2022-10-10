﻿using Piltform;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piltform
{
    public class MatchingGame : Pildid
    {
        string title;
        Random rnd = new Random();
        TableLayoutPanel table;
        Label firstClicked = null;
        Label secondClicked = null;
        Timer timer1 = new Timer { Interval = 750 };
        List<string> icons = new List<string>() //väärtuste loend, mis ilmuvad hiljem
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        public MatchingGame(string title)
        {
            CenterToScreen();
            timer1.Tick += Tick;
            Text = "Matching game";
            ClientSize = new Size(1200, 600);
            table = new TableLayoutPanel
            {
                BackColor = Color.Pink,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                RowCount = 4,
                ColumnCount = 4
            };

            this.Controls.Add(table);
            for (int i = 0; i < 4; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                for (int j = 0; j < 4; j++)
                {

                    Label lbl = new Label
                    {
                        BackColor = Color.Pink,
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Webdings", 48, FontStyle.Bold),
                    };


                    table.Controls.Add(lbl, i, j);
                };

            }
            foreach (Control control in table.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = rnd.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                }
                iconLabel.ForeColor = iconLabel.BackColor;
                iconLabel.Click += Click;
            }

        }


        private void Click(object sender, EventArgs e) //ikooni kuvamiseks
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                timer1.Start();
            }
        }
        private void Tick(object sender, EventArgs e) //taimeri funktsioon
        {

            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked.ForeColor = firstClicked.ForeColor;
                secondClicked.ForeColor = secondClicked.ForeColor;
            }
            else
            {
                firstClicked.ForeColor = firstClicked.BackColor;
                secondClicked.ForeColor = secondClicked.BackColor;
            }
            firstClicked = null;
            secondClicked = null;
            timer1.Stop();
            Kontroll();
        }
        private void Kontroll() //kontrolli funktsioon
        {
            foreach (Control control in table.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            using (var muusika = new SoundPlayer(@"..\..\end.wav"))
            {
                MessageBox.Show("Õnnitleme, olete kõik leidnud!");
                muusika.Stop();
                Close();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MatchingGame
            // 
            this.ClientSize = new System.Drawing.Size(282, 353);
            this.Name = "MatchingGame";
            this.Load += new System.EventHandler(this.MatchingGame_Load);
            this.ResumeLayout(false);

        }

        private void MatchingGame_Load(object sender, EventArgs e)
        {

        }
    }
}