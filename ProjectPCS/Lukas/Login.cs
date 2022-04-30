using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPCS.Jonathan;
using ProjectPCS.Leonardo;
using MySql.Data.MySqlClient;

namespace ProjectPCS.Lukas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = @"select count(*)
            from users
            where us_username = @username";
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            Koneksi.openConn();
            int temp = int.Parse(cmd.ExecuteScalar().ToString());
            Koneksi.closeConn();

            if (temp == 0)
            {
                MessageBox.Show("Gagal Login! Akun tidak ditemukan!");
                return;
            }

            cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = @"select us_password
            from users
            where us_username = @username";
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            Koneksi.openConn();
            string pw = cmd.ExecuteScalar().ToString();
            Koneksi.closeConn();

            if (textBox2.Text != pw)
            {
                MessageBox.Show("Gagal Login! Akun tidak ditemukan!");
                return;
            }

            cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = @"select us_pr
            from users
            where us_username = @username";
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            Koneksi.openConn();
            int pr = int.Parse(cmd.ExecuteScalar().ToString());
            Koneksi.closeConn();

            cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = @"select us_id
            from users
            where us_username = @username";
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            Koneksi.openConn();
            int id = int.Parse(cmd.ExecuteScalar().ToString());
            Koneksi.closeConn();

            this.Hide();
            if (pr == 1)
            {
                using (AdminForm af = new AdminForm(id))
                {
                    af.ShowDialog();
                }
            }
            else
            {
                using (UserForm uf = new UserForm(id))
                {
                    uf.ShowDialog();
                }
            }
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Register rg = new Register())
            {
                this.Hide();
                rg.ShowDialog();
                this.Show();
            }
        }
    }
}
