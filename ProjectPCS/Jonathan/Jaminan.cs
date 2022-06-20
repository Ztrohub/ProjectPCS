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
using ProjectPCS.Leonardo;

namespace ProjectPCS.Jonathan
{
    public partial class Jaminan : Form
    {
        int us_id;
        public Jaminan(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }
        public void refresh()
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                string query = "SELECT jaminan.J_ID AS 'ID'," +
                " users.US_NAME AS 'User', " +
                " jaminan.J_TYPE as 'Tipe'," +
                " jaminan.J_NUMBER as 'Number'," +
                " jaminan.J_NOPENG as 'Nomor Pengambilan'," +
                " jaminan.j_DATE AS 'Tanggal Diserahkan'," +
                " jaminan.j_AMBIL as 'Tanggal Pengambilan'" +
                " from jaminan JOIN htrans ON j_ht_id = ht_id" +
                " JOIN users ON ht_us_id = us_id";

                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());
                da.Fill(dt);
                dgvjaminan.DataSource = dt;
                dgvjaminan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvjaminan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvjaminan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvjaminan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvjaminan.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvjaminan.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvjaminan.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public void getrefresh(string keyword)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                string query = "SELECT jaminan.J_ID AS 'ID'," +
                " users.US_NAME AS 'User', " +
                " jaminan.J_TYPE as 'Tipe'," +
                " jaminan.J_NUMBER as 'Number'," +
                " jaminan.J_NOPENG as 'Nomor Pengambilan'," +
                " jaminan.j_DATE AS 'Tanggal Diserahkan'," +
                " jaminan.j_AMBIL as 'Tanggal Pengambilan'" +
                  keyword +
                " from jaminan,users" +
                " where jaminan.J_ID = users.US_ID";

                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());
                da.Fill(dt);
                dgvjaminan.DataSource = dt;
                dgvjaminan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvjaminan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvjaminan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvjaminan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvjaminan.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvjaminan.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvjaminan.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void Jaminan_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AdminForm a = new AdminForm(us_id);
            this.Hide();
            a.ShowDialog();
            this.Close();
        }

        private void sepedaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Sepeda s = new Sepeda(us_id);
            this.Hide();
            s.ShowDialog();
            this.Close();
        }

        private void aksesorisToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Aksesoris a = new Aksesoris(us_id);
            this.Hide();
            a.ShowDialog();
            this.Close();
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Transaksi t = new Transaksi(us_id);
            this.Hide();
            t.ShowDialog();
            this.Close();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {

            User u = new User(us_id);
            this.Hide();
            u.ShowDialog();
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnclr_Click(object sender, EventArgs e)
        {
            txtsrc.Text = "";
            btnbelumambil.Checked = false;
            btnsudahambil.Checked = false;
        }

        private void usersearch(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            string query = "SELECT jaminan.J_ID AS 'ID'," +
            " users.US_NAME AS 'User', " +
            " jaminan.J_TYPE as 'Tipe'," +
            " jaminan.J_NUMBER as 'Number'," +
            " jaminan.J_NOPENG as 'Nomor Pengambilan'," +
            " jaminan.j_DATE AS 'Tanggal Diserahkan'," +
            " jaminan.j_AMBIL as 'Tanggal Pengambilan'" +
            " from jaminan,users" +
            " where jaminan.J_ID = users.US_ID and users.us_name like '%" + txtsrc.Text + "%'";

            MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());
            da.Fill(dt);
            dgvjaminan.DataSource = dt;
            dgvjaminan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvjaminan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvjaminan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvjaminan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvjaminan.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvjaminan.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvjaminan.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgvjaminan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int select = dgvjaminan.CurrentCell.RowIndex;
            string id = dgvjaminan.Rows[select].Cells[0].Value.ToString();
            
            MySqlCommand cmd = new MySqlCommand("SELECT HT_INVOICE_NUMBER FROM htrans JOIN jaminan ON J_HT_ID = HT_ID WHERE J_ID = " + id);
            cmd.Connection = Koneksi.getConn();
            Koneksi.openConn();
            string invoice = cmd.ExecuteScalar().ToString();
            Koneksi.closeConn();

            AmbilJaminan aj = new AmbilJaminan(invoice);
            aj.ShowDialog();
            aj.Dispose();
        }
    }
}
