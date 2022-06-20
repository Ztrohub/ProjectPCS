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


namespace ProjectPCS.Leonardo
{
    public partial class history : Form
    {
        int us_id;
        MySqlCommand cmd;
        MySqlDataReader rd;
        DataSet ds;
        MySqlDataAdapter da;
        DataTable dt;
        bool exit = true;
        string filter_status = "";
        string tempnama;
        string tempsaldo;
        public history(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        private void history_Load(object sender, EventArgs e)
        {
            loaddatagrid1();
            comboBox1.SelectedIndex = 0;
            

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                Koneksi.openConn();
                cmd.CommandText = @"select us_name from users where us_id = '" + us_id + "'";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    tempnama = rd.GetString(0);
                }
                Koneksi.closeConn();
                label3.Text = "Welcome, " + tempnama;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                Koneksi.openConn();
                cmd.CommandText = @"select us_saldo from users where us_id = '" + us_id + "'";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    tempsaldo = rd.GetString(0);
                }
                Koneksi.closeConn();
                label2.Text = "Rp." + tempsaldo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void loaddatagrid1()
        {
            dataGridView1.ClearSelection();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"SELECT 
                ifnull(date(ht_date), '-') AS 'Tanggal', 
                ht_invoice_number AS 'Invoice', 
                ht_total AS 'Total', 
                IF (ht_hari is null, 'Jam', 'Hari') AS 'Tipe', 
                IF (ht_hari is null, ht_jam, ht_hari) AS 'Durasi'
                FROM htrans
                where HT_US_ID = @us_id " + filter_status + "order by ht_id desc";
                cmd.Parameters.AddWithValue("@us_id", us_id);

                Koneksi.openConn();
                cmd.ExecuteReader();
                Koneksi.closeConn();
                da.SelectCommand = cmd;
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            dataGridView1.ClearSelection();


        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = false;
            UserForm b = new UserForm(us_id);
            this.Hide();
            b.ShowDialog();
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

        private void onGoingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = false;
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
            if (exit)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to logout?", "Log Out", MessageBoxButtons.YesNo);
                e.Cancel = (dialogResult == DialogResult.No);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                filter_status = "";
            }

            if (comboBox1.SelectedIndex == 1)
            {
                filter_status = " AND HT_STATUS <> 3";
            }

            if (comboBox1.SelectedIndex == 2)
            {
                filter_status = " AND HT_STATUS = 3";
            }

            loaddatagrid1();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label22.Text = DateTime.Now.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected_index = dataGridView1.CurrentCell.RowIndex;

            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            string invoice = dataGridView1.Rows[selected_index].Cells[1].Value.ToString();
            string tanggal = dataGridView1.Rows[selected_index].Cells[0].Value.ToString();
            string total = dataGridView1.Rows[selected_index].Cells[2].Value.ToString();
            string tipe = dataGridView1.Rows[selected_index].Cells[3].Value.ToString();
            string durasi = dataGridView1.Rows[selected_index].Cells[4].Value.ToString();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            Koneksi.openConn();
            cmd.CommandText = @"select case
                    when ht_date is null then 'Menunggu Konfirmasi'
                    when ht_status = 0 then 'Sedang Dipinjam'
                    when ht_status = 1 then 'Menunggu Penerimaan'
                    when ht_status = 2 then 'Menunggu Pembayaran Denda'
                    else 'Transaksi Selesai'
                    end,
                    ifnull(ht_kembalian, '-'),
                    ifnull(ht_dikembalikan, '-')
                    from htrans where ht_invoice_number = " + invoice + "";
            rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                label12.Text = invoice;
                label13.Text = tanggal;
                label14.Text = total;
                label15.Text = tipe;
                label18.Text = durasi;
                label19.Text = rd.GetString(0);
                label20.Text = rd.GetString(1);
                label21.Text = rd.GetString(2);

            }
            else MessageBox.Show("error");

            Koneksi.closeConn();

            button5.Enabled = true;

            if (label19.Text == "Sedang Dipinjam") button2.Enabled = true;
            if (label19.Text == "Menunggu Pembayaran Denda") button3.Enabled = true;
            if (label19.Text == "Transaksi Selesai") button4.Enabled = true;

            if (label20.Text != "-")
            {
                cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                Koneksi.openConn();
                cmd.CommandText = @"SELECT 
	            IF (HT_HARI IS NULL, CEILING(TIMESTAMPDIFF(MINUTE, HT_KEMBALIAN, IFNULL(HT_DIKEMBALIKAN, NOW()))/60)*50000,
	            CEILING(TIMESTAMPDIFF(HOUR, HT_KEMBALIAN, IFNULL(HT_DIKEMBALIKAN, NOW()))/24)*1000000
	            )
                FROM htrans
                WHERE ht_invoice_number = " + invoice;

                int denda = int.Parse(cmd.ExecuteScalar().ToString());

                if (denda < 0) denda = 0;

                label23.Text = denda.ToString();
                Koneksi.closeConn();
            } else
            {
                label23.Text = "-";
            }
            
        }
    }
}
