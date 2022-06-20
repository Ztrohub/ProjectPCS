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

namespace ProjectPCS.Leonardo
{
    public partial class Denda : Form
    {
        private string no_nota, user_id;
        private string tempsaldo;
        public bool success = false;
        MySqlDataReader rd;

        public Denda(string no_nota, string user_id)
        {
            InitializeComponent();
            this.no_nota = no_nota;
            this.user_id = user_id;
        }

        private void Denda_Load(object sender, EventArgs e)
        {
            loadSaldo();
            loadReport();
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            int total_denda = getTotalDenda();

            if(total_denda > Convert.ToInt32(tempsaldo))
            {
                MessageBox.Show("Saldo tidak mencukupi!");
            } else {
                try {
                    MySqlCommand cmd = new MySqlCommand("insert into dompet values (0, 'Pembayaran Denda Transaksi #" + no_nota + "', " + (-total_denda) + ", " + user_id + ", now());");
                    cmd.Connection = Koneksi.getConn();
                    Koneksi.openConn();
                    cmd.ExecuteNonQuery();
                    Koneksi.closeConn();

                    cmd = new MySqlCommand("update users set us_saldo = us_saldo - " + total_denda + " where us_id = " + user_id);
                    cmd.Connection = Koneksi.getConn();
                    Koneksi.openConn();
                    cmd.ExecuteNonQuery();
                    Koneksi.closeConn();

                    cmd = new MySqlCommand("update htrans set ht_status = 3 where ht_invoice_number = " + no_nota);
                    cmd.Connection = Koneksi.getConn();
                    Koneksi.openConn();
                    cmd.ExecuteNonQuery();
                    Koneksi.closeConn();

                    this.success = true;
                    MessageBox.Show("Berhasil membayar denda! Silahkan mengambil jaminan Anda!");
                    this.Close();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void loadSaldo()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            Koneksi.openConn();
            cmd.CommandText = @"select us_saldo from users where us_id = '" + user_id + "'";
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                tempsaldo = rd.GetString(0);
            }
            Koneksi.closeConn();
            lblJumDenda.Text = "Rp. " + tempsaldo;
        }

        private void loadReport()
        {
            crptNotaDenda rep = new crptNotaDenda();
            rep.SetDatabaseLogon(Koneksi.username, "", Koneksi.server, Koneksi.dbname);
            rep.SetParameterValue("no_nota", this.no_nota);
            crystalReportViewer1.ReportSource = rep;
            crystalReportViewer1.Zoom(1);
        }

        private int getTotalDenda()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(d_price) FROM denda JOIN htrans ON d_ht_id = ht_id WHERE ht_invoice_number = '" + this.no_nota + "' GROUP BY ht_id;");
            cmd.Connection = Koneksi.getConn();
            Koneksi.openConn();
            int total_denda = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            Koneksi.closeConn();

            return total_denda;
        }
    }
}
