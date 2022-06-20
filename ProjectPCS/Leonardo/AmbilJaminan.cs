using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProjectPCS.Fernando;

namespace ProjectPCS.Leonardo
{
    public partial class AmbilJaminan : Form
    {
        private string invoice, url_image, nopeng;

        public AmbilJaminan(string invoice)
        {
            InitializeComponent();
            this.invoice = invoice;
        }

        private void AmbilJaminan_Load(object sender, EventArgs e)
        {
            loadImageAndNopeng();
            loadReport();
        }

        private void loadImageAndNopeng()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT j_image, j_nopeng FROM jaminan JOIN htrans ON j_ht_id = ht_id WHERE ht_invoice_number = " + this.invoice);
            cmd.Connection = Koneksi.getConn();
            Koneksi.openConn();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                this.url_image = reader.GetString(0);
                this.nopeng = reader.GetString(1);
            }

            Koneksi.closeConn();

            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string output = appPath + @"\Jaminan\";
            this.url_image = output + this.url_image;
        }

        private void loadReport()
        {
            SuratJaminan rep = new SuratJaminan();
            rep.SetDatabaseLogon(Koneksi.username, "", Koneksi.server, Koneksi.dbname);
            rep.SetParameterValue("no_pengambilan", this.nopeng);
            rep.SetParameterValue("url_gambar", this.url_image);
            crystalReportViewer1.ReportSource = rep;
            crystalReportViewer1.Zoom(1);
        }
    }
}
