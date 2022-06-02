using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPCS.Fernando
{
    public partial class ShowTransactionForm : Form
    {
        public ShowTransactionForm()
        {
            InitializeComponent();
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            if (dtpTanggalAwal.Text == "" || dtpTanggalAkhir.Text == "")
            {
                MessageBox.Show("Input tidak boleh kosong!");
            }
            else
            {
                DateTime from_date = Convert.ToDateTime(dtpTanggalAwal.Text);
                DateTime to_date = Convert.ToDateTime(dtpTanggalAkhir.Text);

                if (from_date > to_date)
                {
                    MessageBox.Show("Tanggal awal tidak boleh lebih besar dari tanggal akhir!");
                }
                else
                {
                    crptTransaksiAdmin rep = new crptTransaksiAdmin();
                    rep.SetParameterValue("from_date", from_date);
                    rep.SetParameterValue("to_date", to_date);
                    crystalReportViewer1.ReportSource = rep;
                }
            }
        }
    }
}
