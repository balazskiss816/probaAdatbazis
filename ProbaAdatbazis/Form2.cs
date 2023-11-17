using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProbaAdatbazis
{
    public partial class Form2 : Form
    {
        public static MySqlConnection conn;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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
    }
}
