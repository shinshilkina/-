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
    public partial class month_change : UserControl
    {
        public month_change()
        {
            InitializeComponent();
        }

        string mecnum;
        string data;
        string eventt;
       
        string bdgoals;

        private void month_change_Load(object sender, EventArgs e)
        {
            month_dates();

            month_work();

            month_goals();
        
        }

//открытие событий
        private void month_dates()
        {
            //Вывод дел на месяц
            // ЭТО ВСЕ ЧТОБЫ ПОЛУЧИТЬ НОМЕР МЕСЯЦА В КАЛЕНДАРИКЕ    
            DateTime date = new DateTime();
            date = dateTimePicker1.Value;
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
                eventt = reader1["event"].ToString(); // чтение названия события
                //вывод строк в соотвествие текущему месяцу
                if (string.Equals(mecnum, mecnumselect))
                {
                    richTextBox1.Text += data + " - ";
                    richTextBox1.Text += eventt + ";" + "\r\n";
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

//открытие целей 
        private void month_goals()
        {
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection3 = new OleDbConnection(conn_param);
            OleDbCommand command3 = connection3.CreateCommand();
            command3.CommandText = "select * from month_goals";
            connection3.Open();
            OleDbDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                bdgoals = reader3["notice"].ToString() + "\r\n"; // чтение целей
                richTextBox5.Text = bdgoals;
            }
            reader3.Close();
            connection3.Close();
        }

//открытие дел 
        private void month_work()
        {
            richTextBox4.Clear();
            string notice; 
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection2 = new OleDbConnection(conn_param);
            OleDbCommand command2 = connection2.CreateCommand();
            command2.CommandText = "select * from month_notice";
            connection2.Open();
            OleDbDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                notice = reader2["affairs"].ToString() + "\r\n";
                richTextBox4.Text += notice;
            }
            reader2.Close();
            connection2.Close();
        }
//добавление новой даты
        private void button1_Click(object sender, EventArgs e)
        {
            
            int ID = 0;
            DateTime date = new DateTime();
            date = dateTimePicker1.Value;
            string data1 = Convert.ToString(date); //запись выбранной даты в календарике
            data = data1.Substring(0, data1.Length - (data1.Length - 10));
            eventt = richTextBox2.Text; // запись текста события (названия)
            string mecnumselect;//номер выбранного месяца
            mecnumselect = data1.Remove(0, 3);  //обрезка первых трех символов(день)
            mecnumselect = mecnumselect.Substring(0, mecnumselect.Length - (mecnumselect.Length - 2)); // обрезка хвоста (год)

            //чтение ID-шников --- вычисление последнего айдишника
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command1 = connection.CreateCommand();
            command1.CommandText = "select max(ID) from my_month";
            connection.Open();
            OleDbDataReader reader = command1.ExecuteReader();
            reader.Read();
            ID = Convert.ToInt32(reader[0]);
            ID++;
            reader.Close();

            //добавление строки в базу данных
            OleDbConnection myOleDbConnection = new OleDbConnection(conn_param);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            myOleDbCommand.CommandText = "INSERT INTO my_month" +
                "(ID, mecnum, data, event)" + "VALUES(" + ID + ',' + "'" + mecnumselect + "'" + ',' + "'" + data + "'" + ',' + "'" + eventt + "'" + ")";
            myOleDbConnection.Open();

            myOleDbCommand.ExecuteNonQuery();
            connection.Close();
            
            richTextBox1.Clear();

            month_dates();
        }
//добавление нового дела
        private void button2_Click(object sender, EventArgs e)
        {

            
            int ID = 0;
            string noticenew = richTextBox3.Text;

            //чтение ID-шников --- вычисление последнего айдишника
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            try
            {
                OleDbConnection connection = new OleDbConnection(conn_param);
                OleDbCommand command1 = connection.CreateCommand();
                command1.CommandText = "select max(ID) from month_notice";
                connection.Open();
                OleDbDataReader reader = command1.ExecuteReader();
                reader.Read();
                ID = Convert.ToInt32(reader[0]);
                ID++;
                reader.Close();
                connection.Close();
            }
            catch { ID = 1; }

            //добавление строки в базу данных
            OleDbConnection myOleDbConnection = new OleDbConnection(conn_param);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            myOleDbCommand.CommandText = "INSERT INTO month_notice" +
                "(ID, affairs)" + "VALUES(" + ID + ',' + "'" + noticenew + "'" + ")";
            myOleDbConnection.Open();

            myOleDbCommand.ExecuteNonQuery();
            myOleDbConnection.Close();

            

            month_work();
        }
//удаление дела из списка дел
        private void button3_Click(object sender, EventArgs e)
        {

            string notice; 
            bool result = false;
                int ID = 0;
                string id = "";
                string noticenew = richTextBox3.Text;

                //чтение ID-шников и заметок --- вычисление нужной строки
                string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
                OleDbConnection connection = new OleDbConnection(conn_param);
                OleDbCommand command1 = connection.CreateCommand();
                command1.CommandText = "select * from month_notice";
                connection.Open();
                OleDbDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    id = reader1["ID"].ToString(); // чтение номера ID
                    ID = Convert.ToInt32(id);
                    notice = reader1["affairs"].ToString(); // чтение заметки

                    //удаление нужной строки, когда встретится при чтении таблицы
                    if (string.Equals(notice, noticenew))
                    {
                        string query = string.Format("DELETE FROM month_notice WHERE ID = {0}", ID);// текст запроса
                        OleDbCommand commanddel = new OleDbCommand(query, connection);// создаем объект OleDbCommand для выполнения запроса к БД MS Access
                        commanddel.ExecuteNonQuery(); // выполняем запрос к MS Access
                        result = true;
                    }
                }
                reader1.Close();
                connection.Close();
                if (result == false)
                {
                    richTextBox3.Text = "Данные ведены неверно";
                }
                richTextBox4.Clear();

            month_work();
        }
//удалить дату события
        private void button4_Click(object sender, EventArgs e)
        {
            
            bool result = false;

            string notice; 
            int ID = 0;
                string id = "";
                string noticenew = richTextBox2.Text;

                //чтение ID-шников и заметок --- вычисление нужной строки
                string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
                OleDbConnection connection = new OleDbConnection(conn_param);
                OleDbCommand command1 = connection.CreateCommand();
                command1.CommandText = "select * from my_month";
                connection.Open();
                OleDbDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    id = reader1["ID"].ToString(); // чтение номера ID
                    ID = Convert.ToInt32(id);
                    notice = reader1["data"].ToString(); // чтение заметки

                    //удаление нужной строки, когда встретится при чтении таблицы
                    if (string.Equals(notice, noticenew))
                    {
                        string query = string.Format("DELETE FROM my_month WHERE ID = {0}", ID);// текст запроса
                        OleDbCommand commanddel = new OleDbCommand(query, connection);// создаем объект OleDbCommand для выполнения запроса к БД MS Access
                        commanddel.ExecuteNonQuery(); // выполняем запрос к MS Access
                        result = true;
                    }
                }
                reader1.Close();
                connection.Close();
            if (result==false)
            {
                richTextBox2.Text = "Данные ведены неверно"; 
            }
            richTextBox1.Clear();

            month_dates();
        }
// добавление новой цели
        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox5.Clear();
            int ID = 0;
            string noticenew = richTextBox6.Text;

            //чтение ID-шников --- вычисление последнего айдишника
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection = new OleDbConnection(conn_param);
            OleDbCommand command1 = connection.CreateCommand();
            command1.CommandText = "select max(ID) from month_goals";
            connection.Open();
            OleDbDataReader reader = command1.ExecuteReader();
            reader.Read();
            ID = Convert.ToInt32(reader[0]);
            ID++;
            reader.Close();

            //добавление строки в базу данных
            OleDbConnection myOleDbConnection = new OleDbConnection(conn_param);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            myOleDbCommand.CommandText = "INSERT INTO month_goals" +
                "(ID, notice)" + "VALUES(" + ID + ',' + "'" + noticenew + "'" + ")";
            myOleDbConnection.Open();

            myOleDbCommand.ExecuteNonQuery();
            connection.Close();

            month_goals();
        }
//удаление цели
        private void button6_Click(object sender, EventArgs e)
        {

            string notice;
            bool result = false;
                int ID = 0;
                string id = "";
                string noticenew = richTextBox6.Text;

                //чтение ID-шников и заметок --- вычисление нужной строки
                string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
                OleDbConnection connection = new OleDbConnection(conn_param);
                OleDbCommand command1 = connection.CreateCommand();
                command1.CommandText = "select * from month_goals";
                connection.Open();
                OleDbDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    id = reader1["ID"].ToString(); // чтение номера ID
                    ID = Convert.ToInt32(id);
                    notice = reader1["notice"].ToString(); // чтение заметки

                    //удаление нужной строки, когда встретится при чтении таблицы
                    if (string.Equals(notice, noticenew))
                    {
                        string query = string.Format("DELETE FROM month_goals WHERE ID = {0}", ID);// текст запроса
                        OleDbCommand commanddel = new OleDbCommand(query, connection);// создаем объект OleDbCommand для выполнения запроса к БД MS Access
                        commanddel.ExecuteNonQuery(); // выполняем запрос к MS Access
                        result = true;
                    }
                }
                reader1.Close();
                connection.Close();
                if (result == false)
                {
                    richTextBox6.Text = "Данные ведены неверно";
                }
                richTextBox5.Clear();

            month_goals();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            DateTime date = dateTimePicker1.Value;
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

        private void button7_Click(object sender, EventArgs e)
        {
            month_dates();
        }
    }
}
