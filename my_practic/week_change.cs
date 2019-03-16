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
    public partial class week_change : UserControl
    {
        public week_change()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string day = richTextBox1.Text;

            switch (day)
            {
                case "Понедельник": monday(); break;
                case "Вторник": tuesday(); break;
                case "Среда": wednesday(); break;
                case "Четверг": thurday(); break;
                case "Пятница": friday(); break;
                case "Суббота": suturday(); break;
                case "Воскресенье": sunday(); break;
                default: richTextBox1.Text = "Неверно введено!"; break;
            }
        }
        private void monday()
        {
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection1 = new OleDbConnection(conn_param);
            connection1.Open(); 
            OleDbDataAdapter da = new OleDbDataAdapter("select * from monday", connection1);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "monday");
            ds.Tables[0].Rows[0]["plan"] = richTextBox2.Text;
            ds.Tables[0].Rows[0]["notice"] = richTextBox3.Text;

            da.Update(ds, "monday");
            connection1.Close();
        }
        private void tuesday()
        {
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
          System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection1 = new OleDbConnection(conn_param);
            connection1.Open(); 
            OleDbDataAdapter da = new OleDbDataAdapter("select * from tuesday", connection1);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "tuesday");
            ds.Tables[0].Rows[0]["plan"] = richTextBox2.Text;
            ds.Tables[0].Rows[0]["notice"] = richTextBox3.Text;

            da.Update(ds, "tuesday");
            connection1.Close();
        }
        private void wednesday()
        {
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection1 = new OleDbConnection(conn_param);
            connection1.Open(); 
            OleDbDataAdapter da = new OleDbDataAdapter("select * from wednesday", connection1);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "wednesday");
            ds.Tables[0].Rows[0]["plan"] = richTextBox2.Text;
            ds.Tables[0].Rows[0]["notice"] = richTextBox3.Text;

            da.Update(ds, "wednesday");
            connection1.Close();
        }
        private void thurday()
        {
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection1 = new OleDbConnection(conn_param);
            connection1.Open(); 
            OleDbDataAdapter da = new OleDbDataAdapter("select * from thurday", connection1);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "thurday");
            ds.Tables[0].Rows[0]["plan"] = richTextBox2.Text;
            ds.Tables[0].Rows[0]["notice"] = richTextBox3.Text;

            da.Update(ds, "thurday");
            connection1.Close();
        }
        private void friday()
        {
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
          System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection1 = new OleDbConnection(conn_param);
            connection1.Open(); 
            OleDbDataAdapter da = new OleDbDataAdapter("select * from friday", connection1);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "friday");
            ds.Tables[0].Rows[0]["plan"] = richTextBox2.Text;
            ds.Tables[0].Rows[0]["notice"] = richTextBox3.Text;

            da.Update(ds, "friday");
            connection1.Close();
        }
        private void suturday()
        {
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
         System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection1 = new OleDbConnection(conn_param);
            connection1.Open(); 
            OleDbDataAdapter da = new OleDbDataAdapter("select * from suturday", connection1);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "suturday");
            ds.Tables[0].Rows[0]["plan"] = richTextBox2.Text;
            ds.Tables[0].Rows[0]["notice"] = richTextBox3.Text;

            da.Update(ds, "suturday");
            connection1.Close();
        }
        private void sunday()
        {
            label6.Text="";
            string conn_param = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " +
          System.IO.Path.Combine(Application.StartupPath, "daily.mdb");
            OleDbConnection connection1 = new OleDbConnection(conn_param);
            connection1.Open(); 
            OleDbDataAdapter da = new OleDbDataAdapter("select * from sunday", connection1);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "sunday");
            ds.Tables[0].Rows[0]["plan"] = richTextBox2.Text;
            ds.Tables[0].Rows[0]["notice"] = richTextBox3.Text;

            da.Update(ds, "sunday");
            connection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            richTextBox3.Clear(); 
            string vspom = richTextBox1.Text;
            switch (vspom)
            {
                case "Понедельник": monday_view(); break;
                case "Вторник": tuesday_view(); break;
                case "Среда": wednesday_view(); break;
                case "Четверг": thurday_view(); break;
                case "Пятница": friday_view(); break;
                case "Суббота": suturday_view(); break;
                case "Воскресенье": sunday_view(); break;
                default: label6.Text = "Введено неверно!"; break;
            }
        }
string str1 = "";
string str2 = "";
        //открытие понедельника
        private void monday_view()
        {

            label6.Text = "Понедельник";

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

        //Вторник
        private void tuesday_view()
        {

            label6.Text = "Вторник";
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

        //среда

        private void wednesday_view()
        {
            label6.Text = "Среда";
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
        
        //четверг
        private void thurday_view()
        {
            label6.Text = "Среда";
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

       
        //пятница
        private void friday_view()
        {
            label6.Text = "Пятница";
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
       
        //Суббота
        private void suturday_view()
        {
            label6.Text = "Суббота";
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
       
        //Воскресенье
        private void sunday_view()
        {
            label6.Text = "Воскресенье";
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

        private void week_change_Load(object sender, EventArgs e)
        {

        }
    }
}
