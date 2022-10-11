using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;

namespace Piltform
{
    public partial class Pildid : Form
    {
        TreeView puu;
        TableLayoutPanel tableLayoutPanel;
        PictureBox pictureBox;
        CheckBox checkBox;
        Button close_btn, bgColor, clear, showPicture, gray;
        ColorDialog colordialog;
        OpenFileDialog openfiledialog;
        FlowLayoutPanel flowLayoutPanel;
        MathQuiz mathQuiz;
        Bitmap _currentBitmap;


        public Pildid()
        {
            Text = "Minu oma vorm koos elementidega"; //название формы
            puu = new TreeView();
            puu.Dock = DockStyle.Right;
            puu.Location = new Point(0, 0);
            TreeNode oksad = new TreeNode("Mangud");
            oksad.Nodes.Add(new TreeNode("Pildid"));
            oksad.Nodes.Add(new TreeNode("MangQuiz"));
            oksad.Nodes.Add(new TreeNode("MatchingGame"));


            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            this.Controls.Add(puu);


        }


        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Pildid")
            {
                Text = "Pilti vaatamine";
                this.Size = new System.Drawing.Size(1280, 500);
                tableLayoutPanel = new TableLayoutPanel
                {
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 2,
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(900, 500),
                TabIndex = 0,
                BackColor = System.Drawing.Color.White,
            };
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
                (System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle
               (System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.RowStyle
               (System.Windows.Forms.SizeType.Percent, 90F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.RowStyle
               (System.Windows.Forms.SizeType.Percent, 5F));
            tableLayoutPanel.ResumeLayout(false);

            this.Controls.Add(tableLayoutPanel);

            pictureBox = new System.Windows.Forms.PictureBox
            {
                BorderStyle = BorderStyle.Fixed3D,
                Dock = DockStyle.Fill,
                Location = new Point(3, 3),
                Name = "PictureBox",
                Size = new Size(562, 428),
                TabIndex = 0,
                TabStop = false,
            };
            tableLayoutPanel.Controls.Add(pictureBox,0,0);
            tableLayoutPanel.SetCellPosition(pictureBox,new TableLayoutPanelCellPosition(0,0));
            tableLayoutPanel.SetColumnSpan(pictureBox,2);

            checkBox = new CheckBox
            {
                AutoSize = true,
                Location = new System.Drawing.Point(150, 278),
                TabIndex = 1,
                UseVisualStyleBackColor = true,
                Text = "Venita",
                Dock = System.Windows.Forms.DockStyle.Fill,

            };

                checkBox.CheckedChanged += new System.EventHandler(CheckBox_CheckedChanged);
            tableLayoutPanel.Controls.Add(checkBox);

            close_btn = new Button
            {
                Text = "Suleda",
                TabIndex = 1,
                Dock = System.Windows.Forms.DockStyle.Fill,
            };
            colordialog = new ColorDialog
            {
                AllowFullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = Color.Red,
            };

            bgColor = new Button
            {
                AutoSize = true,
                TabIndex = 1,
                Text = "Valida tausta värvi",
                UseVisualStyleBackColor = true,

            };
            tableLayoutPanel.Controls.Add(bgColor);
            this.bgColor.Click += new System.EventHandler(this.bgColor_Click);

                gray = new Button
                {
                    AutoSize = true,
                    Location = new Point(373, 3),
                    Size = new Size(75, 23),
                    TabIndex = 5,
                    Text = "Change photo color to Gray",
                    UseVisualStyleBackColor = true,
                };
                gray.Click += new EventHandler(Gray_Click);


                clear = new Button
            {
                AutoSize = true,
                TabIndex = 2,
                Text = "Kustuta",
                UseVisualStyleBackColor = true,
            };
            tableLayoutPanel.Controls.Add(clear);
            this.clear.Click += new System.EventHandler(this.clear_Click);

            showPicture = new Button
            {
                AutoSize = true,
                TabIndex = 3,
                Text = "Näita pilti",
                UseVisualStyleBackColor = true,

            };
            tableLayoutPanel.Controls.Add(showPicture);
            this.showPicture.Click += new System.EventHandler(this.showPicture_Click);

            //Paint = new Button
            //{
            //    AutoSize = true,
            //    TabIndex = 3,
            //    Text = "Näita pilti",
            //    UseVisualStyleBackColor = true,

            //};
            //    tableLayoutPanel.Controls.Add(showPicture);
            //    this.showPicture.Click += new System.EventHandler(this.showPicture_Click);

                openfiledialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Title = "Browse Text Files",
                Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" + "s (*.*)|*.*",

            };
                Button[] buttons = { clear, showPicture, bgColor , gray };
                flowLayoutPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.LeftToRight,
                };
                flowLayoutPanel.Controls.AddRange(buttons);
                tableLayoutPanel.Controls.Add(flowLayoutPanel, 1, 1);
                this.Controls.Add(tableLayoutPanel);
            }
            else if (e.Node.Text == "MangQuiz")
            {
                MathQuiz nupp = new MathQuiz("Math Quiz");
                nupp.ShowDialog();
            }
            else if (e.Node.Text == "MatchingGame") //matemaatikaviktoriini mängu käivitamine eraldi aknas
            {
                MatchingGame el = new MatchingGame("Matching Game");
                el.ShowDialog();
            }
        }


        private void showPicture_Click(object sender, EventArgs e)
        {
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Load(openfiledialog.FileName);
            }
        }

        private void MinuVorm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void clear_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else { pictureBox.SizeMode = PictureBoxSizeMode.Normal; }
        }

        private void bgColor_Click(object sender, EventArgs e)
        {
            if (colordialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.BackColor = colordialog.Color;
            }
        }
            private void Gray_Click(object sender, EventArgs e)
            {
                Bitmap copyBitmap = new Bitmap((Bitmap)picturebox.Image);
                ProcessImage(copyBitmap);
                picturebox.Image = copyBitmap;
            }

        public bool ProcessImage(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color bmpColor = bmp.GetPixel(i, j);
                    int red = bmpColor.R;
                    int green = bmpColor.G;
                    int blue = bmpColor.B;
                    int gray = (byte)(.299 * red + .587 * green + .114 * blue);
                    red = gray;
                    green = gray;
                    blue = gray;
                    bmp.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }
            return true;
        

        }
    }
}

