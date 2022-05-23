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
            DialogResult dialogResult = MessageBox.Show("Are you sure want to logout?", "Log Out", MessageBoxButtons.YesNo);
            e.Cancel = (dialogResult == DialogResult.No);
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history c = new history(us_id);
            this.Hide();
            c.ShowDialog();
            this.Close();
        }
    }
}
