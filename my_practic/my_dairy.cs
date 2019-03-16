using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace my_practic
{
    public partial class my_dairy : UserControl
    {
        public my_dairy()
        {
            InitializeComponent();
        }
        
        string data;
        string eventt;

//отображение имеющихся записей на сегодня
        private void my_dairy_Load(object sender, EventArgs e)
        {
            writer();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            writer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           int ID = 0;
           DateTime date = new DateTime();
           date = dateTimePicker1.Value;
           data = Convert.ToString(date);
           string mecnumselect; //номер выбранной даты
           mecnumselect = data.Substring(0, data.Length - (data.Length - 10)); // обрезка хвоста (время)
           eventt = richTextBox1.Text; // запись текста события (названия)
           
           //чтение ID-шников --- вычисление последнего айдишника
           string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
           OleDbConnection connection = new OleDbConnection(conn_param);
           OleDbCommand command1 = connection.CreateCommand();
           command1.CommandText = "select max(ID) from my_dairy";
           connection.Open();
           OleDbDataReader reader = command1.ExecuteReader();
           reader.Read();
           ID = Convert.ToInt32(reader[0]);
           ID++;
           reader.Close();

           //добавление строки в базу данных
           OleDbConnection myOleDbConnection = new OleDbConnection(conn_param);
           OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
           myOleDbCommand.CommandText = "INSERT INTO my_dairy" +
               "(ID, data, notice)" + "VALUES(" + ID + ','  + "'" + data + "'" + ',' + "'" + eventt + "'" + ")";
           myOleDbConnection.Open();

           myOleDbCommand.ExecuteNonQuery();
           connection.Close(); 
        }

        private void writer()
        {
            DateTime date = new DateTime();
            date = dateTimePicker1.Value;
            data = Convert.ToString(date);
            string mecnumselect; //номер выбранной даты
            mecnumselect = data.Substring(0, data.Length - (data.Length - 10)); // обрезка хвоста (время)

            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command1 = connection.CreateCommand();
            command1.CommandText = "select * from my_dairy";
            connection.Open();
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                data = reader1["data"].ToString(); // чтение даты
                eventt = reader1["notice"].ToString(); // чтение записи
                //вывод строк в соотвествие текущей дате
                if (string.Equals(data, mecnumselect))
                {
                    richTextBox1.Text = eventt;
                }
            }
            reader1.Close();
            connection.Close();
            if (richTextBox1.TextLength == 0)
            {
                richTextBox1.Text = "Записи пока что нет...";
            }
        }
    }
}
