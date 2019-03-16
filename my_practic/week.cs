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
using System.Globalization; //dateTimePicker

namespace my_practic
{
    public partial class week : UserControl
    {
        public week()
        {
            InitializeComponent();
        }
        string day = "";
        DateTime date = new DateTime();
// чтение событий на этой на неделе
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
//добавление заметки на неделю
        private void button8_Click(object sender, EventArgs e)
        {
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection = new OleDbConnection(conn_param);
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from week_notice", connection);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "week_notice");
            ds.Tables[0].Rows[0]["notice"] = richTextBox1.Text;
            da.Update(ds, "week_notice");
            connection.Close();
        }
string str1 = "";
string str2 = "";

        
//открытие понедельника
        private void monday()
    {
        
        label2.Text = "Понедельник";
        richTextBox2.Clear();
        richTextBox3.Clear();

        string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
          System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
        OleDbConnection connection = new OleDbConnection(conn_param);
        OleDbCommand command1 = connection.CreateCommand();
        command1.CommandText = "select * from monday";
        connection.Open();
        OleDbDataReader reader1 = command1.ExecuteReader();
        while (reader1.Read())
        {
            str1 = reader1["plan"].ToString() + "\r\n"; // чтение дел
            richTextBox2.Text = str1;
            str2 = reader1["notice"].ToString() + "\r\n"; // чтение заметок
            richTextBox3.Text = str2;
        }
        reader1.Close();
        connection.Close();
    }
        
        private void button1_Click(object sender, EventArgs e)
        {
            week_change1.SendToBack(); 
            monday();
        }

//Вторник
        private void tuesday()
        {
            
            richTextBox2.Clear();
            richTextBox3.Clear();
            label2.Text = "Вторник";
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb"); 
            
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command1 = connection.CreateCommand();
            command1.CommandText = "select * from tuesday";
            connection.Open();
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                str1 = reader1["plan"].ToString() + "\r\n"; // чтение дел
                richTextBox2.Text = str1;
                str2 = reader1["notice"].ToString() + "\r\n"; // чтение заметок
                richTextBox3.Text = str2;
            }
            reader1.Close();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            week_change1.SendToBack(); 
            tuesday();
        }
//среда

        private void wednesday()
        {
            
            richTextBox2.Clear();
            richTextBox3.Clear();
            label2.Text = "Среда";
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb"); 
            
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command1 = connection.CreateCommand();
            command1.CommandText = "select * from wednesday";
            connection.Open();
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                str1 = reader1["plan"].ToString() + "\r\n"; // чтение дел
                richTextBox2.Text = str1;
                str2 = reader1["notice"].ToString() + "\r\n"; // чтение заметок
                richTextBox3.Text = str2;
            }
            reader1.Close();
            connection.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            week_change1.SendToBack(); 
            wednesday();
        }
//четверг
        private void thurday()
        {
            
            richTextBox2.Clear();
            richTextBox3.Clear();
            label2.Text = "Среда";
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb"); 
            
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command1 = connection.CreateCommand();
            command1.CommandText = "select * from thurday";
            connection.Open();
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                str1 = reader1["plan"].ToString() + "\r\n"; // чтение дел
                richTextBox2.Text = str1;
                str2 = reader1["notice"].ToString() + "\r\n"; // чтение заметок
                richTextBox3.Text = str2;
            }
            reader1.Close();
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            week_change1.SendToBack(); 
            thurday();
        }
//пятница
        private void friday()
        {
            
            richTextBox2.Clear();
            richTextBox3.Clear();
            label2.Text = "Пятница";
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb"); 
            
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command1 = connection.CreateCommand();
            command1.CommandText = "select * from friday";
            connection.Open();
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                str1 = reader1["plan"].ToString() + "\r\n"; // чтение дел
                richTextBox2.Text = str1;
                str2 = reader1["notice"].ToString() + "\r\n"; // чтение заметок
                richTextBox3.Text = str2;
            }
            reader1.Close();
            connection.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            week_change1.SendToBack(); 
            friday();
        }
//Суббота
        private void suturday()
        {
            
            richTextBox2.Clear();
            richTextBox3.Clear();
            label2.Text = "Суббота";
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb"); 
            
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command1 = connection.CreateCommand();
            command1.CommandText = "select * from suturday";
            connection.Open();
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                str1 = reader1["plan"].ToString() + "\r\n"; // чтение дел
                richTextBox2.Text = str1;
                str2 = reader1["notice"].ToString() + "\r\n"; // чтение заметок
                richTextBox3.Text = str2;
            }
            reader1.Close();
            connection.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            week_change1.SendToBack(); 
            suturday();
        }
//Воскресенье
        private void sunday()
        {
            
            richTextBox2.Clear();
            richTextBox3.Clear();
            label2.Text = "Воскресенье";
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb"); 
            
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command1 = connection.CreateCommand();
            command1.CommandText = "select * from sunday";
            connection.Open();
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                str1 = reader1["plan"].ToString() + "\r\n"; // чтение дел
                richTextBox2.Text = str1;
                str2 = reader1["notice"].ToString() + "\r\n"; // чтение заметок
                richTextBox3.Text = str2;
            }
            reader1.Close();
            connection.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            week_change1.SendToBack(); 
            sunday();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            week_change1.BringToFront();
        }

        private void week_Load(object sender, EventArgs e)
        {
            week_change1.SendToBack();
            //определение дня недели
            date = dateTimePicker1.Value;
            day = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(date.ToString("dddd", CultureInfo.GetCultureInfo("ru-ru")));
            
            string mondate = "";
            switch (day)
            {
                case "Понедельник": mondate = Convert.ToString(date.AddDays(0)); break;
                case "Вторник": mondate = Convert.ToString(date.AddDays(-1)); break;
                case "Среда": mondate = Convert.ToString(date.AddDays(-2)); break;
                case "Четверг": mondate = Convert.ToString(date.AddDays(-3)); break;
                case "Пятница": mondate = Convert.ToString(date.AddDays(-4)); break;
                case "Суббота": mondate = Convert.ToString(date.AddDays(-5)); break;
                case "Воскресенье": mondate = Convert.ToString(date.AddDays(-6)); break;
            }
            mondate = mondate.Substring(0, mondate.Length - (mondate.Length - 10)); // вывод только даты
            string vt = Convert.ToString(date.AddDays(+1));
            vt = vt.Substring(0, vt.Length - (vt.Length - 10));
            string sr = Convert.ToString(date.AddDays(+2));
            sr = sr.Substring(0, sr.Length - (sr.Length - 10));
            string cht = Convert.ToString(date.AddDays(+3));
            cht = cht.Substring(0, cht.Length - (cht.Length - 10));
            string pt = Convert.ToString(date.AddDays(+4));
            pt = pt.Substring(0, pt.Length - (pt.Length - 10));
            string sb = Convert.ToString(date.AddDays(+5));
            sb = sb.Substring(0, sb.Length - (sb.Length - 10));
            string vskr = Convert.ToString(date.AddDays(+6));
            vskr = vskr.Substring(0, vskr.Length - (vskr.Length - 10));
            
            label2.Text = day;
            switch (day)
            {
                case "Понедельник": monday(); break;
                case "Вторник": tuesday(); break;
                case "Среда": wednesday(); break;
                case "Четверг": thurday(); break;
                case "Пятница": friday(); break;
                case "Суббота": suturday(); break;
                case "Воскресенье": sunday(); break;
            }
  
   // чтение заметок на неделю
            int ID = 0;
            string data;
            string eventt;

            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection2 = new OleDbConnection(conn_param);
            OleDbCommand command2 = connection2.CreateCommand();
            command2.CommandText = "select * from my_month";
            connection2.Open();
            OleDbDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read()) //вычисление максимального айдишника (количества строк)
            {
                ID++;
            }
            reader2.Close();
            connection2.Close();
            ID++;

            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command1 = connection.CreateCommand();
            command1.CommandText = "select * from my_month";
            connection.Open();
            OleDbDataReader reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                data = reader1["data"].ToString(); // чтение даты
                eventt = reader1["event"].ToString(); // чтение названия события

                if ((string.Equals(data, mondate)) || (string.Equals(data, vt)) || (string.Equals(data, sr)) || (string.Equals(data, cht)) || (string.Equals(data, pt)) || (string.Equals(data, sb)) || (string.Equals(data, vskr)))
                {
                    richTextBox1.Text += data+ " - ";
                    richTextBox1.Text += eventt + "\r\n";
                }
            }
            reader1.Close();
            connection.Close();
            // сортировка записей в сtроках (по возрастанию)
            int q = 0;
            //чтение исх текста из бокса , сохраняя строки
            List<string> dayInText = new List<string>();
            foreach (string i in richTextBox1.Lines)
            { dayInText.Add(i); }
            // чтение из бокса, для дальнейшей сортировки и редактировании строк в числа
            List<string> mas = new List<string>();
            foreach (string i in richTextBox1.Lines)
            { mas.Add(i); q++; }
            //вырезание числа из массива строк текстбокса
            string[] dayOfMonth = new string[q];
            string nomDenString = "";
            int[] dayOfMonthInt = new int[q];
            for (int i = 0; i < q; i++)
            {

                nomDenString = mas[i];
                if (nomDenString.Length > 3)
                {
                    dayOfMonth[i] = nomDenString.Substring(0, nomDenString.Length - (nomDenString.Length - 2));
                    dayOfMonthInt[i] = Convert.ToInt32(dayOfMonth[i]);
                }
            }
            // сортировка
            richTextBox1.Clear();
            string vspom;
            for (int i = 0; i < q; i++)
            {
                for (int j = i + 1; j < q; j++)
                {
                    if (dayOfMonthInt[i] > dayOfMonthInt[j])
                    {
                        vspom = dayInText[i];
                        dayInText[i] = dayInText[j];
                        dayInText[j] = vspom;
                    }
                }
            }
            //запись в бокс отсортированных строк
            for (int i = 1; i < q; i++)
            {
                richTextBox1.Text += dayInText[i] + "\r\n";
            }
  
        }

        private void week_change1_Load(object sender, EventArgs e)
        {

        }
    }
}
