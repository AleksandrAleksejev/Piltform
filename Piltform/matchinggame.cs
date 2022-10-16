using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
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
        Label lblTimer;
        int counter = 1;
        Label firstClicked = null;
        Label secondClicked = null;
        Timer timer1 = new Timer { Interval = 750 };
        List<string> icons = new List<string>() 
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        public MatchingGame(string title)
        {
            CenterToScreen();
            timer1.Tick += Tick;
            Text = "Matching game";
            ClientSize = new Size(550, 550);
            table = new TableLayoutPanel
            {
                BackColor = Color.Pink,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                RowCount = 5,
                ColumnCount = 5
            };

            this.Controls.Add(table);
            for (int i = 0; i < 4; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                for (int j = 0; j < 4; j++)
                {

                    Label lbl = new Label
                    {
                        BackColor = Color.LightCyan,
                        Size = new Size(100, 100),
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
            lblTimer = new Label 
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Italic, GraphicsUnit.Point, 200),
                Name = "lblAnswer",
                Size = new Size(100, 35),
                TabIndex = 7,
                Text = "--:--:--",
            };
            table.Controls.Add(lblTimer, 0, 4);

        }


        private void Click(object sender, EventArgs e) 
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
            timer1.Start();
            if (counter > 0)
            {
                counter = counter + 1;
                lblTimer.Text = counter + " liigutada";
            }
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
        private void Kontroll() 
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

            using (var muusika = new SoundPlayer(@"..\..\Dollar.wav"))
            {
                MessageBox.Show("Õnnitleme, olete kõik leidnud!");
                muusika.Stop();
                Close();
            }
            var vastus = MessageBox.Show("tahad uuesti mangida!", "Lõpp", MessageBoxButtons.YesNo);
            if (vastus == DialogResult.Yes)
            {
                this.Close();
                MatchingGame el = new MatchingGame("Matching Game");
                el.ShowDialog();
            }
            else if (vastus == DialogResult.No)
            {
                MessageBox.Show("Ok, bye");
                Close();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
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
