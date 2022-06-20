using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPCS.Fernando;

namespace ProjectPCS.Leonardo
{
    public partial class Detail : Form
    {
        private string no_nota;

        public Detail(string no_nota)
        {
            InitializeComponent();
            this.no_nota = no_nota;
        }

        private void Detail_Load(object sender, EventArgs e)
        {
            crptNotaSewa rep = new crptNotaSewa();
            rep.SetDatabaseLogon(Koneksi.username, "", Koneksi.server, Koneksi.dbname);
            rep.SetParameterValue("no_nota", this.no_nota);
            crystalReportViewer1.ReportSource = rep;
            crystalReportViewer1.Zoom(1);
        }
    }
}
