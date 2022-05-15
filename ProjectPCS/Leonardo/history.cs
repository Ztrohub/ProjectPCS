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
    public partial class history : Form
    {
        int us_id;
        public history(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        private void history_Load(object sender, EventArgs e)
        {

        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm b = new UserForm(us_id);
            this.Hide();
            b.ShowDialog();
            this.Close();
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aksesoris b = new aksesoris(us_id);
            this.Hide();
            b.ShowDialog();
            this.Close();
        }

        private void topUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            topup d = new topup(us_id);
            this.Hide();
            d.ShowDialog();
            this.Close();
        }

        private void onGoingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ongoing f = new ongoing(us_id);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void history_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to logout?", "Log Out", MessageBoxButtons.YesNo);
            e.Cancel = (dialogResult == DialogResult.No);
        }
    }
}
