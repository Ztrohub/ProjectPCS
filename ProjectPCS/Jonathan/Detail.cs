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
    public partial class Detail : Form
    {
        string HT_ID;

        public Detail(string HT_ID)
        {
            InitializeComponent();
            this.HT_ID = HT_ID;
        }

        private void Detail_Load(object sender, EventArgs e)
        {
            crptNotaSewa rep = new crptNotaSewa();
            rep.SetDatabaseLogon(Koneksi.username, "", Koneksi.server, Koneksi.dbname);
            rep.SetParameterValue("no_nota", getInvoice());
            crystalReportViewer1.ReportSource = rep;
            crystalReportViewer1.Zoom(1);
        }

        private string getInvoice()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT HT_INVOICE_NUMBER FROM htrans WHERE HT_ID = " + this.HT_ID);
            cmd.Connection = Koneksi.getConn();
            Koneksi.openConn();
            string invoice = cmd.ExecuteScalar().ToString();
            Koneksi.closeConn();

            return invoice;
        }
    }
}
