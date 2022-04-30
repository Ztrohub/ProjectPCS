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

namespace ProjectPCS.Lukas
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Input harus diisi!");
                return;
            }

            int pr = 1;
            if (radioButton2.Checked) pr = 2;

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"insert into users values 
                (0, @username, @password, @name, @pr, 1, 0)";
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.Parameters.AddWithValue("@name", textBox3.Text);
                cmd.Parameters.AddWithValue("@pr", pr.ToString());

                Koneksi.openConn();
                cmd.ExecuteNonQuery();
                Koneksi.closeConn();

                MessageBox.Show("Berhasil Register!");
            }
            catch (MySqlException er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
