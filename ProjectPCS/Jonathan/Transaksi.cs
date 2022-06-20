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

namespace ProjectPCS.Jonathan
{
    public partial class Transaksi : Form
    {
        int us_id;
        public Transaksi(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
            refresh();
            combostatus.SelectedIndex = 0;
        }

        public void refresh()
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                string query = "SELECT htrans.HT_ID AS 'ID'," +
                " htrans.HT_INVOICE_NUMBER AS 'Invoice'," +
                " htrans.HT_DATE as 'Date'," +
                " users.US_NAME AS 'User'," +
                " htrans.HT_TOTAL as 'Total'," +
                " (case when htrans.HT_STATUS = 0 and htrans.HT_DATE is null then ' Belum di Acc'" +
                " WHEN htrans.HT_STATUS = 0 then 'Belum kembali' " +
                " WHEN htrans.HT_STATUS = 1 then ' Sudah kembali' " +
                " WHEN htrans.HT_STATUS = 2 THEN ' Di Acc dan ada denda'" +
                " else ' Tidak ada denda/sudah bayar denda' end) as 'status'" +
                " from htrans,users " +
                " WHERE htrans.ht_us_id = us_id ";
                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());
                da.Fill(dt);
                dgvtrans.DataSource = dt;
                dgvtrans.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvtrans.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvtrans.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvtrans.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvtrans.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvtrans.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Transaksi_Load(object sender, EventArgs e)
        {
            
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

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {

            User u = new User(us_id);
            this.Hide();
            u.ShowDialog();
            this.Close();
        }

        private void jaminanToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Jaminan j = new Jaminan(us_id);
            this.Hide();
            j.ShowDialog();
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            today();
        }

        public void today()
        {
            try
            {
                Koneksi.openConn();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                string query = "SELECT htrans.HT_ID AS 'ID'," +
                " htrans.HT_INVOICE_NUMBER AS 'Invoice'," +
                " htrans.HT_DATE as 'Date'," +
                " users.US_NAME AS 'User'," +
                " htrans.HT_TOTAL as 'Total'," +
                " (case when htrans.HT_STATUS = 0 then ' Belum Kembali'" +
                " WHEN htrans.HT_STATUS = 1 then ' sudah kembali' " +
                " WHEN htrans.HT_STATUS = 2 THEN ' diacc dan ada denda'" +
                " else ' tidak ada denda/sudah bayar denda' end) as 'status'" +
                " from htrans, users" +
                " WHERE htrans.ht_us_id = us_id" +
                (combostatus.SelectedIndex == 0 || combostatus.SelectedIndex == 1 ? "" : (" and htrans.HT_STATUS = " + (combostatus.SelectedIndex - 2))) +
                (combostatus.SelectedIndex == 1 ? "and htrans.HT_DATE IS NULL " : "") +
                " and htrans.HT_DATE between '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());
                da.Fill(dt);
                dgvtrans.DataSource = dt;
                dgvtrans.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvtrans.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvtrans.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvtrans.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvtrans.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvtrans.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            combostatus.Text = "";
        }

        private void dgvtrans_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dgvtrans.CurrentCell.RowIndex;

            string id = dgvtrans.Rows[selectedIndex].Cells[0].Value.ToString();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = @"select ifnull(HT_DATE, -1) from htrans where HT_ID = @HT_ID ";
            cmd.Parameters.AddWithValue("@HT_ID", id);

            Koneksi.openConn();
            string HT_DATE = cmd.ExecuteScalar().ToString();
            Koneksi.closeConn();
            
            cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = @"select HT_STATUS from htrans where HT_ID = @HT_ID ";
            cmd.Parameters.AddWithValue("@HT_ID", id);

            Koneksi.openConn();
            string HT_STATUS = cmd.ExecuteScalar().ToString();
            Koneksi.closeConn();
            
            if (HT_DATE == "-1")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to accept order ?","Accept Order", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) return;

                cmd = new MySqlCommand(
                            "update htrans set HT_DATE = now() ,HT_US_ACC=@us_id where HT_ID=@id");
                cmd.Parameters.AddWithValue("@us_id", us_id);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = Koneksi.getConn();
                Koneksi.openConn();
                cmd.ExecuteNonQuery();
                Koneksi.closeConn();
                cmd = new MySqlCommand(
                            @"UPDATE htrans
                                SET ht_kembalian = CASE
                                WHEN HT_HARI IS NULL THEN DATE_ADD(NOW(), INTERVAL HT_JAM HOUR)
                                ELSE CAST(DATE_ADD(CURRENT_DATE(), INTERVAL HT_HARI + 1 DAY) AS DATETIME)
                                END
                                WHERE HT_ID = @ht_id; ");
                cmd.Parameters.AddWithValue("@ht_id", id);
                cmd.Connection = Koneksi.getConn();
                Koneksi.openConn();
                cmd.ExecuteNonQuery();
                Koneksi.closeConn();
                MessageBox.Show("Berhasil Accept order");
                refresh();
                return;
            }
            if (HT_STATUS == "1")
            {
                Denda d = new Denda(id,us_id.ToString());
                d.ShowDialog();
                refresh();
                return;
            }
            if(HT_STATUS =="0" || HT_STATUS == "2" || HT_STATUS =="3")
            {
                Detail d = new Detail(id);
                d.ShowDialog();
                return;
            }
        }
    }
}
