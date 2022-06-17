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
    public partial class Denda : Form
    {
        string HT_ID;
        string us_id;
        DataTable dt;
        MySqlDataAdapter da;
        public Denda(string HT_ID,string us_id)
        {
            InitializeComponent();
            this.HT_ID = HT_ID;
            this.us_id = us_id;
        }

        private void Denda_Load(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"SELECT d_name as 'Nama' , d_price as 'Harga' from denda where d_ht_id = @ht_id;";
                cmd.Parameters.AddWithValue("@ht_id",HT_ID);
                Koneksi.openConn();
                cmd.ExecuteReader();
                Koneksi.closeConn();
                da.SelectCommand = cmd;
                da.Fill(dt);
                dgvdenda.DataSource = dt;

                cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"SELECT CONCAT('Terlambat Kembali ', 
                    IF(HT_HARI IS NULL, CONCAT(CEILING(TIMESTAMPDIFF(MINUTE, HT_KEMBALIAN, HT_DIKEMBALIKAN) / 60),' Jam @50.000'),
                    CONCAT(CEILING(TIMESTAMPDIFF(HOUR, HT_KEMBALIAN, HT_DIKEMBALIKAN) / 24), ' Hari @1.000.000')
                    )
                    )
                    FROM htrans
                    WHERE ht_id = @ht_id; ";
                cmd.Parameters.AddWithValue("@ht_id",HT_ID);
                Koneksi.openConn();
                string nama = cmd.ExecuteScalar().ToString();
                Koneksi.closeConn();
                cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"SELECT IF (HT_HARI IS NULL, CEILING(TIMESTAMPDIFF(MINUTE, HT_KEMBALIAN, HT_DIKEMBALIKAN)/60) * 50000,
	                                CEILING(TIMESTAMPDIFF(HOUR, HT_KEMBALIAN, HT_DIKEMBALIKAN)/24) * 1000000
	                                )
                                FROM htrans
                                WHERE ht_id = @ht_id;";
                cmd.Parameters.AddWithValue("@ht_id", HT_ID);
                Koneksi.openConn();
                int jumlah = int.Parse(cmd.ExecuteScalar().ToString());
                Koneksi.closeConn();
                if(jumlah >0)
                {
                    dt.Rows.Add(nama, jumlah);
                }
                dgvdenda.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvdenda.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dgvdenda.ClearSelection();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Nama Denda Harus di isi");
                return;
            }
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Jumlah Denda Harus lebih dari 0");
                return;
            }
            dt.Rows.Add(textBox1.Text, numericUpDown1.Value);
            textBox1.Text = "";
            numericUpDown1.Value = 0;
            dgvdenda.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvdenda.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        int select = -1;
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (select == -1)
            {
                MessageBox.Show("Denda Wajib di pilih dahulu");
                return;
            }
            dt.Rows[select].Delete();
        }

        private void dgvdenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            select = dgvdenda.CurrentCell.RowIndex;
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to submit ?", "Submit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;
            MySqlCommand cmd = new MySqlCommand();
            for (int i = dt.Rows.Count - 1; i >=0;i--)
            {
                DataRow dr = dt.Rows[i];
                cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = "insert into denda values {0,@name,@price,@ht_id}";
                cmd.Parameters.AddWithValue("@name",dr[0].ToString());
                cmd.Parameters.AddWithValue("@price", dr[1].ToString());
                cmd.Parameters.AddWithValue("@ht_id", HT_ID);

                Koneksi.openConn();
                cmd.ExecuteNonQuery();
                Koneksi.closeConn();
            }
            cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = "update htrans set ht_status =@status ,ht_us_penerima =@us where ht_id =@ht_id";
            cmd.Parameters.AddWithValue("@status",dgvdenda.Rows.Count >0? 2:3);
            cmd.Parameters.AddWithValue("@us",us_id);
            cmd.Parameters.AddWithValue("@ht_id", HT_ID);

            Koneksi.openConn();
            cmd.ExecuteNonQuery();
            Koneksi.closeConn();
            MessageBox.Show("Berhasil Input Denda");
            this.Close();
        }
    }
}
