using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        string connectionString = "Server=localhost; Port=5432; Database=rgr; User Id = postgres; Password=43898362Dd+-;";
        public Form2()
        {
            InitializeComponent();

            SqlConnectionReader();
        }
        public void SqlConnectionReader()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString);
            sqlConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT * FROM gbo_inspection_records";

            NpgsqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                DataTable data = new DataTable();
                data.Load(dataReader);
                dataGridView1.DataSource = data;
            }

            command.Dispose();
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString);
            sqlConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = String.Format("INSERT INTO gbo_inspection_records(car_id,owner_name,inspection_date,passed,paid_amount,inspector,comments) VALUES ('{0}', '{1}', '{2}','{3}', '{4}', '{5}', '{6}')", textBox1.Text, (textBox2.Text), textBox3.Text, Convert.ToBoolean(textBox4.Text), textBox5.Text, textBox6.Text, textBox7.Text);

            NpgsqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                DataTable data = new DataTable();
                data.Load(dataReader);
                dataGridView1.DataSource = data;
            }

            command.Dispose();
            sqlConnection.Close();
            SqlConnectionReader();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString);
            sqlConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = String.Format("UPDATE gbo_inspection_records SET car_id = '{0}',owner_name = '{1}',inspection_date = '{2}',passed = '{3}',paid_amount = '{4}',inspector = '{5}',comments = '{6}' WHERE record_id = '{7}'" , textBox15.Text, textBox14.Text, textBox13.Text, Convert.ToBoolean(textBox12.Text), textBox11.Text, textBox10.Text, textBox9.Text, Convert.ToInt32(textBox8.Text));

            NpgsqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                DataTable data = new DataTable();
                data.Load(dataReader);
                dataGridView1.DataSource = data;
            }

            command.Dispose();
            sqlConnection.Close();
            SqlConnectionReader();
        }
    }
}
