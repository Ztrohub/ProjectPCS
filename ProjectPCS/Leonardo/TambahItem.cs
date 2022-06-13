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
    public partial class TambahItem : Form
    {
        private int max;
        public int amount;
        public TambahItem(string namaItem, int max)
        {
            InitializeComponent();
            label2.Text = namaItem;
            this.max = max;
            label6.Text = max.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 0)
            {
                MessageBox.Show("Amount harus >= 0!");
                return;
            }

            if (numericUpDown1.Value > max)
            {
                MessageBox.Show("Amount harus <= Max!");
                return;
            }

            amount = int.Parse(numericUpDown1.Value.ToString());
            this.Close();
        }

        private void TambahItem_Load(object sender, EventArgs e)
        {

        }
    }
}
