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
    public partial class aksesoris : Form
    {
        int us_id;
        MySqlCommand cmd;
        MySqlDataReader rd;
        DataSet ds;
        MySqlDataAdapter da;
        DataTable dt;
        public aksesoris(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        private void aksesoris_Load(object sender, EventArgs e)
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
                cmd.CommandText = @"SELECT ak_name AS 'Aksesoris', ak_amount AS 'Unit Tersedia', ak_price_hour AS 'Harga/Jam', ak_price_day AS 'Harga/Hari' FROM aksesoris";

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
            UserForm b = new UserForm(us_id);
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

        private void aksesoris_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to logout?", "Log Out", MessageBoxButtons.YesNo);
            e.Cancel = (dialogResult == DialogResult.No);
        }
    }
}
