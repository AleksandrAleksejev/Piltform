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
        Button close_btn;
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

            checkBox1 = new CheckBox {
            Text = "Venita",
            Dock = System.Windows.Forms.DockStyle.Fill,
            
            
            
            
            };
            tableLayoutPanel.Controls.Add(checkBox1,1,0);

            this.Controls.Add(tableLayoutPanel);

            close_btn = new Button
            {
                Text = "",
                Dock = System.Windows.Forms.DockStyle.Fill,
            };
            clear_btn = new Button
            {
                Text = "Kustuta",
                Dock = System.Windows.Forms.DockStyle.Fill,
            };
            show_btn = new Button
            {
                Text = "Naita",
                Dock = System.Windows.Forms.DockStyle.Fill,
            };
            Button[] buttons = { clear_btn, show_btn, close_btn };
            flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize= true,
                WrapContents = false,
                AutoScroll= true,
            };
            
            foreach (Button button in buttons)
            {
                flowLayoutPanel.Controls.Add(button);
            }
            tableLayoutPanel.Controls.Add(flowLayoutPanel, 1, 1);
            this.Controls.Add(tableLayoutPanel);


        }
       

        private void Pildid_Load(object sender, EventArgs e)
        {

        }
    }
}
