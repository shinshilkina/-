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
    public partial class month : UserControl
    {
        public month()
        {
            InitializeComponent();
        }
        string mecnum;
        string data;
        string eventt;
        string bdcurrent = ""; // важные дела
        string bdgoals = ""; // цели

        private void month_Load(object sender, EventArgs e)
        {
            month_dates();
            
            month_work();
            month_goals();

        }
// дела на месяц
        private void month_dates()
        {
            // ЭТО ВСЕ ЧТОБЫ ПОЛУЧИТЬ НОМЕР МЕСЯЦА В КАЛЕНДАРИКЕ    
            DateTime date = new DateTime();
            date = dateTimePicker1.Value;
            data = Convert.ToString(date);
            string mecnumselect;//номер выбранного месяца
            mecnumselect = data.Remove(0, 3);  //обрезка первых трех символов(день)
            mecnumselect = mecnumselect.Substring(0, mecnumselect.Length - (mecnumselect.Length - 2)); // обрезка хвоста (год)


            //вывод дат событий в соответсвии текущему месяцу
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
          System.IO.Path.Combine(Application.StartupPath, "daily.mdb"); 
            OleDbConnection connection = new OleDbConnection(conn_param);

            OleDbCommand command1 = connection.CreateCommand();
            command1.CommandText = "select * from my_month";
            connection.Open();
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                mecnum = reader1["mecnum"].ToString(); // чтение номера месяца
                data = reader1["data"].ToString(); // чтение даты
                eventt = reader1["event"].ToString(); // чтение названия события



                //вывод строк в соотвествие текущему месяцу
                if (string.Equals(mecnum, mecnumselect))
                {
                    richTextBox1.Text += data + " - ";
                    richTextBox1.Text += eventt  + "\r\n";
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
            int vspomInt;
            for (int i = 0; i < q; i++)
            {
                for (int j = i + 1; j < q; j++)
                {
                    if (dayOfMonthInt[i] > dayOfMonthInt[j])
                    {
                        vspom = dayInText[i];
                        dayInText[i] = dayInText[j];
                        dayInText[j] = vspom;
                        vspomInt = dayOfMonthInt[i];
                        dayOfMonthInt[i] = dayOfMonthInt[j];
                        dayOfMonthInt[j] = vspomInt;
                    }
                }
            }
            //запись в бокс отсортированных строк
            for (int i = 1; i < q; i++)
            {
                richTextBox1.Text += dayInText[i] + "\r\n";
            }
        }
//вывод дел на месяц
        private void month_work()
        {
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb"); 
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command2 = connection.CreateCommand();
            command2.CommandText = "select * from month_notice";
            connection.Open();
            OleDbDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                bdcurrent = reader2["affairs"].ToString() + "\r\n"; // чтение мероприятия
                richTextBox2.Text = bdcurrent;
            }
            reader2.Close();
            connection.Close();
        }
//вывод целей на месяц
        private void month_goals()
        {
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb"); 
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command3 = connection.CreateCommand();
            command3.CommandText = "select * from month_goals";
            connection.Open();
            OleDbDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                bdgoals = reader3["notice"].ToString() + "\r\n"; // чтение целей
                richTextBox3.Text = bdgoals;
            }
            reader3.Close();
            connection.Close();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            richTextBox1.Clear();
            DateTime date = monthCalendar1.SelectionStart;
            data = Convert.ToString(date);
            string mecnumselect;//номер выбранного месяца
            mecnumselect = data.Remove(0, 3);  //обрезка первых трех символов(день)
            mecnumselect = mecnumselect.Substring(0, mecnumselect.Length - (mecnumselect.Length - 2)); // обрезка хвоста (год)
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection = new OleDbConnection(conn_param);

            OleDbCommand command1 = connection.CreateCommand();
            command1.CommandText = "select * from my_month";
            connection.Open();
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                mecnum = reader1["mecnum"].ToString(); // чтение номера месяца
                data = reader1["data"].ToString(); // чтение даты
                eventt = reader1["event"].ToString(); // чтение даты

                //вывод строк в соотвествие текущему месяцу
                if (string.Equals(mecnum, mecnumselect))
                {
                    richTextBox1.Text += data + " - ";
                    richTextBox1.Text += eventt + "\r\n";
                }
            }
            reader1.Close();
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
            int vspomInt;
            for (int i = 0; i < q; i++)
            {
                for (int j = i + 1; j < q; j++)
                {
                    if (dayOfMonthInt[i] > dayOfMonthInt[j])
                    {
                        vspom = dayInText[i];
                        dayInText[i] = dayInText[j];
                        dayInText[j] = vspom;
                        vspomInt = dayOfMonthInt[i];
                        dayOfMonthInt[i] = dayOfMonthInt[j];
                        dayOfMonthInt[j] = vspomInt;
                    }
                }
            }
            //запись в бокс отсортированных строк
            for (int i = 1; i < q; i++)
            {
                richTextBox1.Text += dayInText[i] + "\r\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            month_change1.BringToFront();
            button2.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            month_change1.SendToBack();
            button1.BringToFront();
            month_dates();
            month_work();
            month_goals();
        }

        
    }
}
