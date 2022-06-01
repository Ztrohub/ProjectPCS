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
                cmd.CommandText = @"SELECT sp_name AS 'Sepeda', sp_amount AS 'Unit Tersedia', 
                concat('Rp. ',sp_price_hour) AS 'Harga/Jam',
                concat('Rp. ',sp_price_day) AS 'Harga/Hari' FROM sepeda";
                
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

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aksesoris b = new aksesoris(us_id);
            this.Hide();
            b.ShowDialog();
            this.Close();
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

        
    }
}
