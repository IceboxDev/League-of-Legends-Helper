using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Window : Form
    {
        public Window()
        {
         
            InitializeComponent();
            LoadChampions();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChampionsPanel.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

        private void Azyr_Click(object sender, EventArgs e)
        {
            panel4.BringToFront();
        }

        public void update_label1(string text)
        {
            label4.Text = text;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            CollectionButton.ForeColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(230)))), ((int)(((byte)(208)))));
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            CollectionButton.ForeColor = Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(170)))), ((int)(((byte)(113)))));
        }

        // Hovering a champion button
        private void Highlight(object sender, EventArgs e)
        {
            //Variables
            Button button   = (Button)sender;
            string name     = button.Name;

            //Change
            button.ImageList = this.ImageListSelected;
        }

        // Leavinig a champion button
        private void DeHighlight(object sender, EventArgs e)
        {
            //Variables
            Button button   = (Button)sender;
            string name     = button.Name;

            //Change
            button.ImageList = this.ImageList;
        }

        // Clicking a champion button
        private void Open(object sender, EventArgs e)
        {
            //Variables
            Button  button  = (Button)sender;
            string  name    = button.Name;
            int     index   = button.ImageIndex;

            // Open that panel
            ChampPanels[index].BringToFront();

        }
    }
}
