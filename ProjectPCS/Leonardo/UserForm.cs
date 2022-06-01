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
    public partial class UserForm : Form
    {

        MySqlCommand cmd;
        MySqlDataReader rd;
        DataSet ds;
        MySqlDataAdapter da;
        DataTable dt;
        int us_id;
        string tempnama;
        string tempsaldo;
        public UserForm(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = 0;

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

            dgbawahkanan();
            dgbawahkiri();
            
        }

        void loaddatagrid2()
        {
            //id - nama barang - jumlah - harga
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"SELECT ak_name AS 'Aksesoris',br_name AS 'Brand', ak_amount AS 'Unit Tersedia', ak_price_hour AS 'Harga/Jam', ak_price_day AS 'Harga/Hari' FROM aksesoris, brand WHERE ak_br_id = br_id";

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
            dataGridView1.ClearSelection();
        }

        void loaddatagrid1()
        {
            
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"SELECT sp_name AS 'Sepeda',br_name AS 'Brand', sp_amount AS 'Unit Tersedia', sp_price_hour AS 'Harga/Jam', sp_price_day AS 'Harga/Hari' FROM sepeda, brand WHERE sp_br_id = br_id";
                
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
            dataGridView1.ClearSelection();

        }

        void dgbawahkiri()
        {
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"SELECT sp_name AS 'Sepeda', sp_amount AS 'Jumlah', sp_price_hour AS 'Harga' FROM sepeda WHERE sp_id = -1;";

                Koneksi.openConn();
                cmd.ExecuteReader();
                Koneksi.closeConn();
                da.SelectCommand = cmd;
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        void dgbawahkanan()
        {
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"SELECT sp_name AS 'Aksesoris', sp_amount AS 'Jumlah', sp_price_hour AS 'Harga' FROM sepeda WHERE sp_id = -1;";

                Koneksi.openConn();
                cmd.ExecuteReader();
                Koneksi.closeConn();
                da.SelectCommand = cmd;
                da.Fill(ds);
                dataGridView3.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history c = new history(us_id);
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void topUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            topup d = new topup(us_id);
            this.Hide();
            d.ShowDialog();
            this.Close();
        }

        private void onGoingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ongoing f = new ongoing(us_id);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to logout?", "Log Out", MessageBoxButtons.YesNo);
            e.Cancel = (dialogResult == DialogResult.No);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Enabled == false)
            {
                return;
            }
            if (comboBox3.SelectedIndex == 0)
            {
                loaddatagrid1();
            }
            else
            {
                loaddatagrid2();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            waktu w = new waktu();
            w.ShowDialog();
            if (w.durasi == -1)
            {
                return;
            }
            loaddatagrid1();
            comboBox3.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            

            radioButton1.Checked = w.perjam;
            radioButton2.Checked = !w.perjam;

            numericUpDown1.Value = w.durasi;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = @"SELECT CONCAT(
             DATE_FORMAT(NOW(),'%y%m%d'), LPAD(hitung.jml, 3, '0')
            )
            FROM (
                SELECT COUNT(*)+1 AS jml
                FROM htrans
                WHERE SUBSTRING(ht_invoice_number, 1, 6) = DATE_FORMAT(NOW(),'%y%m%d')
            ) hitung";

            Koneksi.openConn();
            string invoice = cmd.ExecuteScalar().ToString();
            Koneksi.closeConn();

            textBox2.Text = invoice;

            textBox3.Text = DateTime.Now.ToString();
        }
    }
}
