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
    public partial class ongoing : Form
    {
        int us_id;
        bool exit = true;
        public ongoing(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        private void ongoing_Load(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ongoing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to logout?", "Log Out", MessageBoxButtons.YesNo);
                e.Cancel = (dialogResult == DialogResult.No);
            }
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = false;
            UserForm b = new UserForm(us_id);
            this.Hide();
            b.ShowDialog();
            this.Close();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = false;
            history c = new history(us_id);
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void topUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = false;
            topup d = new topup(us_id);
            this.Hide();
            d.ShowDialog();
            this.Close();
        }
    }
}
