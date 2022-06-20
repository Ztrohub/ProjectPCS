using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPCS.Leonardo
{
    public partial class waktu : Form
    {
        public bool perjam;
        public int durasi = -1;
        public waktu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!cekwaktu())
            {
                return;
            }

            perjam = radioButton1.Checked;
            durasi = int.Parse(numericUpDown1.Value.ToString());
            this.Close();
        }

        bool cekwaktu()
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Jenis pinjaman wajib dipilih!");
                return false;
            }
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Durasi pinjaman harus lebih dari 0!");
                return false;
            }
            return true;
        }
    }
}
