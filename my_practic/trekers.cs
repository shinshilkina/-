using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace my_practic
{
    public partial class trekers : UserControl
    {
        public trekers()
        {
            InitializeComponent();
        }

       

        private void trekers_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader streamReader = new StreamReader(@"Трекер сна.txt");
                int X = 0;
                while (!streamReader.EndOfStream)
                {
                    int y = Convert.ToInt16(streamReader.ReadLine());
                    chart1.Series[0].Points.AddXY(X, y);
                    X++;
                }
                streamReader.Close();

                StreamReader streamReader2 = new StreamReader(@"Трекер сна.txt");
                string[] array = new string[7];
                int i = 0;
                while (!streamReader2.EndOfStream)
                {
                    array[i] = Convert.ToString(streamReader2.ReadLine());
                    i++;
                }
                streamReader2.Close();
                textBox1.Text = array[0];
                textBox2.Text = array[1];
                textBox3.Text = array[2];
                textBox4.Text = array[3];
                textBox5.Text = array[4];
                textBox6.Text = array[5];
                textBox7.Text = array[6];
            }
            catch
            {
                System.IO.File.Create(@"Трекер сна.txt");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            StreamWriter streamWriter = new StreamWriter(@"Трекер сна.txt");
            streamWriter.Write(textBox1.Text + "\r\n");
            streamWriter.Write(textBox2.Text + "\r\n");
            streamWriter.Write(textBox3.Text + "\r\n");
            streamWriter.Write(textBox4.Text + "\r\n");
            streamWriter.Write(textBox5.Text + "\r\n");
            streamWriter.Write(textBox6.Text + "\r\n");
            streamWriter.Write(textBox7.Text + "\r\n");
            streamWriter.Close();

            StreamReader streamReader = new StreamReader(@"Трекер сна.txt");
            int X = 0;
            while (!streamReader.EndOfStream)
            {
                int y = Convert.ToInt16(streamReader.ReadLine());
                chart1.Series[0].Points.AddXY(X, y);
                X++;
            }
            streamReader.Close();
        }

       
    }
}
