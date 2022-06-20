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
using ProjectPCS.Fernando;

namespace ProjectPCS.Jonathan
{
    public partial class AdminForm : Form
    {
        int us_id;
        public AdminForm(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            loadSummary();
            lblTanggalNow.Text = DateTime.Now.ToString("dddd \n dd MMMM yyyy");
        }

        private void sepedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sepeda s = new Sepeda(us_id);
            this.Hide();
            s.ShowDialog();
            this.Close();
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aksesorisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aksesoris A = new Aksesoris(us_id);
            this.Hide();
            A.ShowDialog();
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

        private void jaminanToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Jaminan j = new Jaminan(us_id);
            this.Hide();
            j.ShowDialog();
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            crptTransaksiAdmin rep = new crptTransaksiAdmin();
            rep.SetDatabaseLogon(Koneksi.username, "", Koneksi.server, Koneksi.dbname);
            rep.SetParameterValue("from_date", dtpFromDate.Value);
            rep.SetParameterValue("to_date", dtpToDate.Value);
            crystalReportViewer1.ReportSource = rep;
            crystalReportViewer1.Zoom(1);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Transaksi t = new Transaksi(us_id);
            t.today();
            this.Hide();
            t.ShowDialog();
            this.Close();
        }

        private void loadSummary()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM htrans WHERE ht_date BETWEEN CURDATE() AND ADDDATE(CURDATE(), INTERVAL 1 DAY);");
            cmd.Connection = Koneksi.getConn();
            Koneksi.openConn();
            lblJumlahTransaksi.Text = cmd.ExecuteScalar().ToString();
            Koneksi.closeConn();

            cmd = new MySqlCommand("SELECT COUNT(*) FROM dtrans_sepeda JOIN htrans ON DTSP_HT_ID = HT_ID WHERE ht_date BETWEEN CURDATE() AND ADDDATE(CURDATE(), INTERVAL 1 DAY);");
            cmd.Connection = Koneksi.getConn();
            Koneksi.openConn();
            lblPeminjamaSepeda.Text = cmd.ExecuteScalar().ToString();
            Koneksi.closeConn();

            cmd = new MySqlCommand("SELECT COUNT(*) FROM dtrans_aksesoris JOIN htrans ON DTAK_HT_ID = HT_ID WHERE ht_date BETWEEN CURDATE() AND ADDDATE(CURDATE(), INTERVAL 1 DAY);");
            cmd.Connection = Koneksi.getConn();
            Koneksi.openConn();
            lblPeminjamanAksesoris.Text = cmd.ExecuteScalar().ToString();
            Koneksi.closeConn();

            cmd = new MySqlCommand("SELECT SUM(HT_TOTAL) FROM htrans WHERE ht_date BETWEEN CURDATE() AND ADDDATE(CURDATE(), INTERVAL 1 DAY);");
            cmd.Connection = Koneksi.getConn();
            Koneksi.openConn();
            lblTotalPendapatan.Text = "Rp. " +  cmd.ExecuteScalar().ToString();
            Koneksi.closeConn();
        }
    }
}
