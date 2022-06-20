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


namespace ProjectPCS.Fernando
{
    public partial class DetailUserViewer : Form
    {
        private string us_id;

        public DetailUserViewer(string us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        private void DetailUserViewer_Load(object sender, EventArgs e)
        {
            crptDetailUser rep = new crptDetailUser();
            rep.SetDatabaseLogon(Koneksi.username, "", Koneksi.server, Koneksi.dbname);
            rep.SetParameterValue("username", getUsername());
            crystalReportViewer1.ReportSource = rep;
            crystalReportViewer1.Zoom(1);
        }

        private string getUsername()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT US_USERNAME FROM users WHERE US_ID = " + this.us_id);
            cmd.Connection = Koneksi.getConn();
            Koneksi.openConn();
            string username = cmd.ExecuteScalar().ToString();
            Koneksi.closeConn();

            return username;
        }
    }
}
