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
    }
}
