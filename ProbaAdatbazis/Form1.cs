using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProbaAdatbazis
{
    public partial class Form1 : Form
    {
        public static MySqlConnection conn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionStr = "server=localhost;database=proba;username=root;password=";
            conn = new MySqlConnection(connectionStr);

            conn.Open();

            string query = "SELECT * FROM tanulok";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string nev = reader["nev"].ToString();
                string osztaly = reader["osztaly"].ToString();
                comboBox1.Items.Add($"A név: {nev} és osztály: {osztaly}");
            }

            conn.Close();
        }

        private void Feltolt_Click(object sender, EventArgs e)
        {
            string connectionStr = "server=localhost;database=proba;username=root;password=";
            conn = new MySqlConnection(connectionStr);

            string nev = textBox1.Text;
            string osztaly = textBox2.Text;
            string id = textBox3.Text;

            conn.Open();

            string query = $"INSERT INTO tanulok (id, nev, osztaly) VALUES ('{id}','{nev}', '{osztaly}')";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";


            Form2 obj = new Form2();
            obj.Show();
        }

        private void Frissit_Click(object sender, EventArgs e)
        {
            string connectionStr = "server=localhost;database=proba;username=root;password=";
            conn = new MySqlConnection(connectionStr);

            string id = textBox3.Text;
            string nev = textBox1.Text;
            string osztaly = textBox2.Text;

            conn.Open();

            string query = $"UPDATE tanulok SET nev = '{nev}', osztaly = '{osztaly}'" +
                $" WHERE id = {id}";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            textBox1.Text = "";
            textBox2.Text = "";


            Form2 obj = new Form2();
            obj.Show();
        }

        private void Torol_Click(object sender, EventArgs e)
        {
            string connectionStr = "server=localhost;database=proba;username=root;password=";
            conn = new MySqlConnection(connectionStr);

            string nev = textBox1.Text;

            conn.Open();

            string query = $"DELETE FROM tanulok WHERE nev = '{nev}'";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            Form2 obj = new Form2();
            obj.Show();
        }
    }
}
