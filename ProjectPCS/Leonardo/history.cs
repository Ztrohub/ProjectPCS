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
    public partial class history : Form
    {
        int us_id;
        MySqlCommand cmd;
        MySqlDataReader rd;
        DataSet ds;
        MySqlDataAdapter da;
        DataTable dt;
        bool exit = true;
        public history(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        private void history_Load(object sender, EventArgs e)
        {
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
                cmd.CommandText = @"SELECT 
                ifnull(ht_date, '-') AS 'Tanggal', 
                ht_invoice_number AS 'Invoice', 
                ht_total AS 'Total', 
                ht_hari AS 'Hari', 
                ht_jam AS 'Jam', 
                ifnull(ht_kembalian, '-') AS 'Tgl Kembali', 
                ifnull(ht_dikembalikan, '-') AS 'Tgl Dikembalikan'
                FROM htrans
                where HT_US_ID = @us_id";
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

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = false;
            UserForm b = new UserForm(us_id);
            this.Hide();
            b.ShowDialog();
            this.Close();
        }

        

        private void topUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = false;
            topup d = new topup(us_id);
            this.Hide();
            d.ShowDialog();
            this.Close();
        }

        private void onGoingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = false;
            ongoing f = new ongoing(us_id);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void history_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to logout?", "Log Out", MessageBoxButtons.YesNo);
                e.Cancel = (dialogResult == DialogResult.No);
            }
        }
    }
}
