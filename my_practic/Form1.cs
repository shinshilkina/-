using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_practic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel3.Height = button1.Height;
            panel3.Top = button1.Top;
            homePage1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Height = button1.Height;
            panel3.Top = button2.Top; 
            month1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Height = button1.Height;
            panel3.Top = button3.Top; 
            week1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Height = button1.Height;
            panel3.Top = button5.Top; 
            my_dairy1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Height = button1.Height;
            panel3.Top = button4.Top; 
            trekers1.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Height = button1.Height;
            panel3.Top = button1.Top;
            homePage1.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Закрыть", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
              Application.Exit();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
