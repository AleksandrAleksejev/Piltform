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
        CheckBox checkBox ;
        Button close_btn, bgColor, clear, showPicture, rotate, slideshow, buttonSave, gray ;
        ColorDialog colordialog;
        OpenFileDialog openfiledialog;
        FlowLayoutPanel flowLayoutPanel, flowlayoutpanel1;
        MathQuiz mathQuiz;
        Bitmap _currentBitmap;
        FolderBrowserDialog slide;
        Timer timer;
        int imgNum = 1;


        public Pildid()
        {
            Text = "Minu oma vorm koos elementidega"; 
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
                Size = new Size(300, 300),
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

                gray = new Button //nuppu programmi sulgemiseks
                {
                    Text = "Muuda pildi Hall",
                    TabIndex = 1,
                };
                this.gray.Click += new System.EventHandler(this.Gray_Click);
                this.Controls.Add(gray);


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
                rotate = new Button 
                {
                    Text = "poorata",
                    TabIndex = 1,
                };
                this.rotate.Click += new System.EventHandler(this.Rotate);
                this.Controls.Add(rotate);

                buttonSave = new Button
                {
                    AutoSize = true,
                    Location = new System.Drawing.Point(84, 3),
                    Size = new System.Drawing.Size(121, 23),
                    TabIndex = 4,
                    Text = "Salvesta pilti",
                    UseVisualStyleBackColor = true,
                };
                tableLayoutPanel.Controls.Add(buttonSave);
                buttonSave.Click += ButtonSave_Click;
               

                slideshow = new Button
                {
                    AutoSize = true,
                    Location = new System.Drawing.Point(3, 3),
                    Size = new System.Drawing.Size(75, 23),
                    TabIndex = 5,
                    Text = "SlideShow",
                    UseVisualStyleBackColor = true,
                };
                tableLayoutPanel.Controls.Add(slideshow, 0, 3);
                slideshow.Click += SlideShowButton_Click;

                openfiledialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Title = "Browse Text Files",
                Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" + "s (*.*)|*.*",

            };
                Button[] buttons = { clear, showPicture, bgColor , rotate, slideshow, buttonSave,gray };
                flowLayoutPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.LeftToRight,
                };
                flowLayoutPanel.Controls.AddRange(buttons);
                tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 1);
                this.Controls.Add(tableLayoutPanel);

                CheckBox[] checkboxs = { checkBox, };
                flowLayoutPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.LeftToRight,
                };
                flowLayoutPanel.Controls.AddRange(checkboxs);
                tableLayoutPanel.Controls.Add(flowLayoutPanel, 1, 1);

                this.Controls.Add(tableLayoutPanel);
                timer = new Timer
                {
                    Interval = 1000,
                };
                timer.Tick += Timer_Tick;


            }
            else if (e.Node.Text == "MangQuiz")
            {
                MathQuiz nupp = new MathQuiz("Math Quiz");
                nupp.ShowDialog();
            }
            else if (e.Node.Text == "MatchingGame") 
            {
                MatchingGame el = new MatchingGame("Matching Game");
                el.ShowDialog();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            pictureBox.ImageLocation = string.Format(slide.SelectedPath + "\\pilt{0}.jpg", imgNum);
            imgNum++;
            if (imgNum == 5)
                imgNum = 1;
        }


        private void SlideShowButton_Click(object sender, EventArgs e)
        {
            slide = new FolderBrowserDialog();
            slide.ShowDialog();
            timer.Enabled = true;
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
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null) //kui pictureBoxis on pilt
            {
                //looge pildi salvestamiseks dialoogiboks "Salvesta kui...".
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Salvesta pilt";
                //kas kuvada hoiatust, kui kasutaja määrab juba olemasoleva faili nime
                savedialog.OverwritePrompt = true;
                //kas kuvada hoiatust, kui kasutaja määrab olematu tee
                savedialog.CheckPathExists = true;
                //väljal "Failitüüp" kuvatavate failivormingute loend
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                //on dialoogiboksis kuvatav nupp "Abi".
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) //kui dialoogiboksis vajutatakse nuppu "OK".
                {
                    try
                    {
                        pictureBox.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("pilti ei saa salvestada", "Viga",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

            private void bgColor_Click(object sender, EventArgs e)
        {
            if (colordialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.BackColor = colordialog.Color;
            }
        }
        private void Rotate(System.Object sender, System.EventArgs e) 
        {
            Bitmap pic = new Bitmap(pictureBox.Image);
            if (pic != null)
            {
                pic.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBox.Image = pic;
            }
        }
        private void Gray_Click(object sender, EventArgs e) //funktstioon mis inverteerib pilid teise värvideks
        {
            Bitmap pic = new Bitmap(pictureBox.Image);
            for (int y = 0; (y <= (pic.Height - 1)); y++)
            {
                for (int x = 0; (x <= (pic.Width - 1)); x++)
                {
                    Color inv = pic.GetPixel(x, y);
                    inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    pic.SetPixel(x, y, inv);
                    pictureBox.Image = pic;
                }
            }
        }





    }
}

