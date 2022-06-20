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
    public partial class User : Form
    {
        int us_id;
        public User(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        public void refresh()
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                string query = "select users.us_username as 'Username' ," +
                " users.us_name as 'Name'," +
                " users.us_saldo as 'Saldo'" +
                " from users ";
                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());
                da.Fill(dt);
                dgvuser.DataSource = dt;
                dgvuser.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvuser.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvuser.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void User_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void aksesorisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aksesoris a = new Aksesoris(us_id);
            this.Hide();
            a.ShowDialog();
            this.Close();
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm a = new AdminForm(us_id);
            this.Hide();
            a.ShowDialog();
            this.Close();
        }

        private void sepedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sepeda s = new Sepeda(us_id);
            this.Hide();
            s.ShowDialog();
            this.Close();
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaksi t = new Transaksi(us_id);
            this.Hide();
            t.ShowDialog();
            this.Close();
        }

        private void jaminanToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Jaminan j = new Jaminan(us_id);
            this.Hide();
            j.ShowDialog();
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnsrc_Click(object sender, EventArgs e)
        {
            if (txtsrc.Text == "")
            {
                MessageBox.Show("Search tidak boleh kosong");
            }
            else
            {

            }
        }

        private void usersearch(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter da;
            if (txtsrc.Text != " ")
            {
                string query = "select users.us_username as 'Username' ," +
                " users.us_name as 'Name'," +
                " users.us_saldo as 'Saldo'" +
                " from users where US_NAME like '%"+txtsrc.Text+"%'";
                
                da = new MySqlDataAdapter(query, Koneksi.getConn());
                da.Fill(dt);
                dgvuser.DataSource = dt;
                dgvuser.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvuser.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvuser.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }
    }
}
