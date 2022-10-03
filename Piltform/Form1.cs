using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piltform
{
    public partial class Pildid : Form
    {
        TableLayoutPanel tableLayoutPanel;
        PictureBox pictureBox;
        CheckBox checkBox;
        Button close_btn, bgColor, clear, showPicture;
        ColorDialog colordialog;
        OpenFileDialog openfiledialog;
        Button clear_btn;
        Button show_btn;
        FlowLayoutPanel flowLayoutPanel;



        public Pildid()
        {
            this.Size = new System.Drawing.Size(900, 500);
            this.Text = "Pildid";
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

            openfiledialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Title = "Browse Text Files",
                Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" + "s (*.*)|*.*",

            };




        }
       

        private void Pildid_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void bgColor_Click(object sender, EventArgs e)
        {
            if (colordialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.BackColor = colordialog.Color;
            }
        }
        private void clear_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
        }
        private void showPicture_Click(object sender, EventArgs e)
        {
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Load(openfiledialog.FileName);
            }
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else { pictureBox.SizeMode = PictureBoxSizeMode.Normal; }
        }
    }
}
