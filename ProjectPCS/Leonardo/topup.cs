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

namespace ProjectPCS.Leonardo
{
    public partial class topup : Form
    {
        int us_id;
        MySqlCommand cmd;
        MySqlDataReader rd;
        DataSet ds;
        MySqlDataAdapter da;
        DataTable dt;
        string tempnama;
        string tempsaldo;
        bool exit = true;

        public topup(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        private void topup_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                Koneksi.openConn();
                cmd.CommandText = @"select us_name from users where us_id = '" + us_id + "'";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    tempnama = rd.GetString(0);
                }
                Koneksi.closeConn();
                label1.Text = "Welcome, " + tempnama;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                Koneksi.openConn();
                cmd.CommandText = @"select us_saldo from users where us_id = '" + us_id + "'";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    tempsaldo = rd.GetString(0);
                }
                Koneksi.closeConn();
                label2.Text = "Rp." + tempsaldo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            loaddatagrid1();
        }

        void loaddatagrid1()
        {
            dataGridView1.ClearSelection();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"SELECT dm_name AS 'Kegiatan', CONCAT('Rp. ',dm_amount) AS 'Jumlah', dm_date AS 'Tanggal' FROM dompet
                where dm_us_id = @us_id order by dm_id desc;";
                cmd.Parameters.AddWithValue("@us_id", us_id);

                Koneksi.openConn();
                cmd.ExecuteReader();
                Koneksi.closeConn();
                da.SelectCommand = cmd;
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void sepedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = false;
            UserForm b = new UserForm(us_id);
            this.Hide();
            b.ShowDialog();
            this.Close();
        }

        

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = false;
            history c = new history(us_id);
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void topup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to logout?", "Log Out", MessageBoxButtons.YesNo);
                e.Cancel = (dialogResult == DialogResult.No);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Nilai top-up harus lebih besar dari 0!");
                return;
            }

            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"Insert into dompet
                values(0, 'Berhasil Top-Up', @amount, @us_id, now());
            
                update users
                set us_saldo = us_saldo + @amount
                where us_id = @us_id;

                select us_saldo
                from users where us_id = @us_id";

                cmd.Parameters.AddWithValue("@us_id", us_id);
                cmd.Parameters.AddWithValue("@amount", numericUpDown1.Value);

                Koneksi.openConn();
                tempsaldo = cmd.ExecuteScalar().ToString();
                Koneksi.closeConn();
                label2.Text = "Rp." + tempsaldo;

                loaddatagrid1();
                MessageBox.Show("Berhasil Top-Up!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
