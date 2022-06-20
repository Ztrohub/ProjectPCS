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
    public partial class UserForm : Form
    {

        MySqlCommand cmd;
        MySqlDataReader rd;
        DataSet ds;
        MySqlDataAdapter da;
        DataTable dtKiri;
        DataTable dtKanan;
        int us_id;
        string tempnama;
        string tempsaldo;
        bool exit = true;
        bool ordering = false;

        string jnopeng = null;
        string image = null;
        int type = -1;
        string number = null;
        string where = "";


        public UserForm(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = 0;
            loadComboboxTipe();
            loadComboboxBrand();

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
                label1.Text = "Welcome, " + tempnama;
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

            dgbawahkanan();
            dgbawahkiri();
            
        }

        void loaddatagrid2()
        {
            //id - nama barang - jumlah - harga
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"SELECT ak_id AS 'ID', ak_name AS 'Aksesoris',br_name AS 'Brand', ak_amount AS 'Unit Tersedia', ak_price_hour AS 'Harga/Jam', ak_price_day AS 'Harga/Hari' FROM aksesoris, brand WHERE ak_br_id = br_id " + this.where;

                Koneksi.openConn();
                cmd.ExecuteReader();
                Koneksi.closeConn();
                da.SelectCommand = cmd;
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        void loaddatagrid1()
        {
            
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"SELECT sp_id AS 'ID', sp_name AS 'Sepeda',br_name AS 'Brand', sp_amount AS 'Unit Tersedia', sp_price_hour AS 'Harga/Jam', sp_price_day AS 'Harga/Hari' FROM sepeda, brand WHERE sp_br_id = br_id " + this.where;
                
                Koneksi.openConn();
                cmd.ExecuteReader();
                Koneksi.closeConn();
                da.SelectCommand = cmd;
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        void dgbawahkiri()
        {
            try
            {
                dtKiri = new DataTable();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"SELECT sp_id AS 'ID', sp_name AS 'Sepeda', sp_amount AS 'Jumlah', sp_price_hour AS 'Subtotal' FROM sepeda WHERE sp_id = -1;";

                Koneksi.openConn();
                cmd.ExecuteReader();
                Koneksi.closeConn();
                da.SelectCommand = cmd;
                da.Fill(dtKiri);
                dataGridView2.DataSource = dtKiri;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        void dgbawahkanan()
        {
            try
            {
                dtKanan = new DataTable();
                cmd = new MySqlCommand();
                da = new MySqlDataAdapter();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"SELECT sp_id AS 'ID', sp_name AS 'Aksesoris', sp_amount AS 'Jumlah', sp_price_hour AS 'Subtotal' FROM sepeda WHERE sp_id = -1;";

                Koneksi.openConn();
                cmd.ExecuteReader();
                Koneksi.closeConn();
                da.SelectCommand = cmd;
                da.Fill(dtKanan);
                dataGridView3.DataSource = dtKanan;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dataGridView1.ClearSelection();
        }

        private void loadComboboxTipe()
        {
            string query = "SELECT ty_id AS 'id', ty_name AS 'nama' FROM TYPE";
            comboBox2.Items.Clear();

            if (comboBox3.SelectedIndex == 0) {
                query += " WHERE ty_for = 0;";
            } else {
                query += " WHERE ty_for = 1;";
            }

            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Connection = Koneksi.getConn();
            Koneksi.openConn();
            MySqlDataReader reader = cmd.ExecuteReader();
            comboBox2.Items.Add(new {Text = "All", Value = "0"});

            while (reader.Read())
            {
                comboBox2.Items.Add(new { Text = reader.GetString(1), Value = reader.GetString(0) });
            }

            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";
            Koneksi.closeConn();
            comboBox2.SelectedIndex = 0;
        }

        private void loadComboboxBrand()
        {
            comboBox1.Items.Clear();

            MySqlCommand cmd = new MySqlCommand("SELECT br_id AS 'id', br_name AS 'nama' FROM brand;");
            cmd.Connection = Koneksi.getConn();
            Koneksi.openConn();
            MySqlDataReader reader = cmd.ExecuteReader();
            comboBox1.Items.Add(new { Text = "All", Value = "0" });

            while (reader.Read())
            {
                comboBox1.Items.Add(new { Text = reader.GetString(1), Value = reader.GetString(0) });
            }

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            Koneksi.closeConn();
            comboBox1.SelectedIndex = 0;
        }

        private void removeCart(string id, string amount, bool aksesoris = false)
        {
            string table = "SEPEDA";
            string idne = "SP_ID";
            string amountne = "SP_AMOUNT";

            if (aksesoris)
            {
                table = "AKSESORIS";
                idne = "AK_ID";
                amountne = "AK_AMOUNT";
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();

            cmd.CommandText = "UPDATE " + table + " SET " + amountne + " = (" + amountne + " + " + amount + ") WHERE " + idne + " = " + id;

            Koneksi.openConn();
            cmd.ExecuteNonQuery();
            Koneksi.closeConn();
        }

        private void loadDatagridUtama()
        {
            if (comboBox3.SelectedIndex == 0) loaddatagrid1();
            else loaddatagrid2();

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void cancel()
        {
            for (int i = dtKiri.Rows.Count-1; i >= 0; i--)
            {
                DataRow dr = dtKiri.Rows[i];
                removeCart(dr[0].ToString(), dr[2].ToString());
                dr.Delete();
            }
            dtKiri.AcceptChanges();

            for (int i = dtKanan.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtKanan.Rows[i];
                removeCart(dr[0].ToString(), dr[2].ToString(), true);
                dr.Delete();
            }
            dtKanan.AcceptChanges();

            loadDatagridUtama();

            comboBox3.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            dataGridView1.Enabled = false;
            dataGridView2.Enabled = false;
            dataGridView3.Enabled = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            button4.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

            numericUpDown1.Value = 0;

            textBox2.Text = "";

            textBox3.Text = "";

            textBox4.Text = "0";

            textBox5.Text = "Rp 0";

            label15.Text = "- Belum ada data";
            label15.ForeColor = Color.Red;

            jnopeng = null;
            image = null;
            type = -1;
            number = null;

            ordering = false;

        }

        private bool closeOrdering()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to cancel order?", "Cancel Order", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return false;

            cancel();

            return true;
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordering && !closeOrdering())
            {
                return;
            }

            exit = false;
            history c = new history(us_id);
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void topUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordering && !closeOrdering())
            {
                return;
            }

            exit = false;
            topup d = new topup(us_id);
            this.Hide();
            d.ShowDialog();
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordering && !closeOrdering())
            {
                return;
            }

            this.Close();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ordering && !closeOrdering())
            {
                return;
            }

            if (exit)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to logout?", "Log Out", MessageBoxButtons.YesNo);
                e.Cancel = (dialogResult == DialogResult.No);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Enabled == false)
            {
                return;
            }

            textBox1.Text = "";
            loadDatagridUtama();
            loadComboboxTipe();
            loadComboboxBrand();
        }
        
        private int cariRow(int id)
        {
            int hasil = -1;
            DataTable dgv = comboBox3.SelectedIndex == 0 ? dtKiri : dtKanan;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (int.Parse(dgv.Rows[i][0].ToString()) == id)
                {
                    hasil = i;
                    break;
                }
            }

            return hasil;
        }

        private void addData()
        {
            DataTable dtv = comboBox3.SelectedIndex == 0 ? dtKiri : dtKanan;
            DataGridView dgv = comboBox3.SelectedIndex == 0 ? dataGridView2 : dataGridView3;

            int selectedIndex = dataGridView1.CurrentCell.RowIndex;

            string nama = dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString();
            int stock = int.Parse(dataGridView1.Rows[selectedIndex].Cells[3].Value.ToString());
            int id = int.Parse(dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString());
            int harga = radioButton1.Checked ?
                int.Parse(dataGridView1.Rows[selectedIndex].Cells[4].Value.ToString()) :
                int.Parse(dataGridView1.Rows[selectedIndex].Cells[5].Value.ToString());

            TambahItem tb = new TambahItem(nama, stock);
            tb.ShowDialog();

            if (tb.amount == 0) return;

            int cari = cariRow(int.Parse(dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString()));

            if (cari == -1)
            {
                dtv.Rows.Add(id, nama, tb.amount, harga * tb.amount * numericUpDown1.Value);
            } else
            {
                int old = int.Parse(dtv.Rows[cari][2].ToString());

                dtv.Rows[cari][2] = old + tb.amount;
                dtv.Rows[cari][3] = (old + tb.amount) * harga * numericUpDown1.Value;
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();

            string table = comboBox3.SelectedIndex == 0 ? "SEPEDA" : "AKSESORIS";
            string atr = comboBox3.SelectedIndex == 0 ? "SP_AMOUNT" : "AK_AMOUNT";
            string idtr = comboBox3.SelectedIndex == 0 ? "SP_ID" : "AK_ID";


            cmd.CommandText = "UPDATE " + table + " SET " + atr + " = (" + atr + " - " + tb.amount + ") WHERE " + idtr + " = " + id;

            Koneksi.openConn();
            cmd.ExecuteNonQuery();
            Koneksi.closeConn();
            
            loadDatagridUtama();
            hitung();

            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = @"select count(*) from htrans where ht_us_id = @us_id and ht_status <> 3";
            cmd.Parameters.AddWithValue("@us_id", us_id);

            Koneksi.openConn();
            int belum_selese = int.Parse(cmd.ExecuteScalar().ToString());
            Koneksi.closeConn();

            if (belum_selese > 0)
            {
                MessageBox.Show("Selesaikan pesanan terlebih dahulu!");
                return;
            }

            waktu w = new waktu();
            w.ShowDialog();
            if (w.durasi == -1)
            {
                return;
            }
            loadDatagridUtama();
            comboBox3.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            dataGridView1.Enabled = true;
            dataGridView2.Enabled = true;
            dataGridView3.Enabled = true;
            button4.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;

            radioButton1.Checked = w.perjam;
            radioButton2.Checked = !w.perjam;

            numericUpDown1.Value = w.durasi;

            cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = @"SELECT CONCAT(
             DATE_FORMAT(NOW(),'%y%m%d'), LPAD(hitung.jml, 3, '0')
            )
            FROM (
                SELECT COUNT(*)+1 AS jml
                FROM htrans
                WHERE SUBSTRING(ht_invoice_number, 1, 6) = DATE_FORMAT(NOW(),'%y%m%d')
            ) hitung";

            Koneksi.openConn();
            string invoice = cmd.ExecuteScalar().ToString();
            Koneksi.closeConn();

            textBox2.Text = invoice;

            textBox3.Text = DateTime.Now.ToString();

            ordering = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ordering && !closeOrdering())
            {
                return;
            }
        }

        private void hitung()
        {
            int count = 0;
            int subtotal = 0;

            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                count += int.Parse(item.Cells[2].Value.ToString());
                subtotal += int.Parse(item.Cells[3].Value.ToString());
            }

            foreach (DataGridViewRow item in dataGridView3.Rows)
            {
                count += int.Parse(item.Cells[2].Value.ToString());
                subtotal += int.Parse(item.Cells[3].Value.ToString());
            }

            textBox4.Text = count.ToString();
            textBox5.Text = "Rp " + subtotal;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addData();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridView2.CurrentCell.RowIndex;

            DataRow dr = dtKiri.Rows[selectedIndex];
            removeCart(dr[0].ToString(), dr[2].ToString());
            dr.Delete();

            loadDatagridUtama();
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridView3.CurrentCell.RowIndex;

            DataRow dr = dtKanan.Rows[selectedIndex];
            removeCart(dr[0].ToString(), dr[2].ToString(), true);
            dr.Delete();

            loadDatagridUtama();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount == 0 && dataGridView3.RowCount == 0)
            {
                MessageBox.Show("Minimal penyewaan 1 item sebelum order!");
                return;
            }

            if (jnopeng == null)
            {
                MessageBox.Show("Jaminan wajib diinput!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure want to make order?", "Make Order", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            int saldo = int.Parse(tempsaldo);
            int total = int.Parse(textBox5.Text.Substring(3));

            if (saldo < total)
            {
                MessageBox.Show("Maaf saldo anda tidak mencukupi! Silakan top-up.");
                return;
            }

            Koneksi.openConn();
            MySqlTransaction trans = Koneksi.conn.BeginTransaction();

            try
            {
                // DOMPET + SALDO
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"
                set autocommit = 0;
                INSERT INTO dompet
                VALUES (0, @nama, @amount, @us_id, now());
            
                UPDATE users
                SET US_SALDO = US_SALDO - @amounta
                WHERE US_ID = @us_id;

                SELECT US_SALDO
                FROM USERS
                WHERE US_ID = @us_id;
            ";
                cmd.Parameters.AddWithValue("@nama", "Pembayaran Transaksi #" + textBox2.Text);
                cmd.Parameters.AddWithValue("@amount", -total);
                cmd.Parameters.AddWithValue("@amounta", total);
                cmd.Parameters.AddWithValue("@us_id", us_id);

                tempsaldo = cmd.ExecuteScalar().ToString();

                label2.Text = "Rp." + tempsaldo;

                // HTRANS
                cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"
            INSERT INTO htrans
            VALUES (0, null, @invoice, @us_id, @total, 0, null, @hari, @jam, null, null, null);
            
            SELECT HT_ID FROM HTRANS WHERE HT_INVOICE_NUMBER = @invoice;
            ";
                cmd.Parameters.AddWithValue("@invoice", textBox2.Text);
                cmd.Parameters.AddWithValue("@us_id", us_id);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@hari", radioButton1.Checked ? null : numericUpDown1.Value.ToString());
                cmd.Parameters.AddWithValue("@jam", radioButton1.Checked ? numericUpDown1.Value.ToString() : null);

                string ht_id = cmd.ExecuteScalar().ToString();

                // DTRANS
                todtrans(ht_id);

                // JAMINAN
                cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"
            INSERT INTO jaminan
            VALUES (0, @jtype, @jimage, @j_number, @j_ht_id, @jnopeng, now(), null);
            
            ";
                cmd.Parameters.AddWithValue("@jtype", type);
                cmd.Parameters.AddWithValue("@jimage", image);
                cmd.Parameters.AddWithValue("@j_number", number);
                cmd.Parameters.AddWithValue("@j_ht_id", ht_id);
                cmd.Parameters.AddWithValue("@jnopeng", jnopeng);

                cmd.ExecuteNonQuery();

                trans.Commit();

                MessageBox.Show("Order transaksi #" + textBox2.Text + " berhasil dibuat! Silahkan cek di menu on-going!");

                Detail detail = new Detail(textBox2.Text);
                detail.ShowDialog();
                detail.Dispose();

                cancel();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();

            }
            finally
            {
                Koneksi.openConn();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Koneksi.getConn();
                cmd.CommandText = @"
                set autocommit = 1;
            ";

                cmd.ExecuteNonQuery();
                Koneksi.closeConn();
            }
        }

        private void insertCart(string id, string amount, string subtotal, string ht_id, bool aksesoris = false)
        {
            string table = "dtrans_sepeda";

            if (aksesoris)
            {
                table = "dtrans_aksesoris";
            }

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();

            cmd.CommandText = "INSERT INTO " + table + " VALUES (0, " + ht_id + ", " + id + ", " + amount + ", " + subtotal + ");";

            cmd.ExecuteNonQuery();
        }

        private void todtrans(string ht_id)
        {
            for (int i = dtKiri.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtKiri.Rows[i];
                insertCart(dr[0].ToString(), dr[2].ToString(), dr[3].ToString(), ht_id);
                dr.Delete();
            }
            dtKiri.AcceptChanges();

            for (int i = dtKanan.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtKanan.Rows[i];
                insertCart(dr[0].ToString(), dr[2].ToString(), dr[3].ToString(), ht_id, true);
                dr.Delete();
            }
            dtKanan.AcceptChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Jaminan jm = new Jaminan();
            jm.ShowDialog();

            if (!jm.save) return;

            label15.Text = "- Data tersimpan!";
            label15.ForeColor = Color.Green;

            jnopeng = jm.jnopeng;
            image = jm.image;
            type = jm.type;
            number = jm.number;

        }

    // FILTER SECTION
        private void filter(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                return;
            }

            this.where = "";

            if (comboBox3.SelectedIndex == 0) { // SEPEDA

                // SEPEDA BY NAME
                if (textBox1.Text != "")
                {
                    this.where += $"AND LOWER(SP_NAME) LIKE LOWER('%{textBox1.Text}%') ";
                }

                // SEPEDA BY TIPE
                if(comboBox2.SelectedIndex > 0)
                {
                    this.where += $"AND SP_TY_ID = {(comboBox2.SelectedItem as dynamic).Value} ";
                }

                // SEPEDA BY BRAND
                if (comboBox1.SelectedIndex > 0)
                {
                    this.where += $"AND SP_BR_ID = {(comboBox1.SelectedItem as dynamic).Value} ";
                }
            } else { // AKSESORIS

                // AKSESORIS BY NAME
                if (textBox1.Text != "")
                {
                    this.where += $"AND LOWER(AK_NAME) LIKE LOWER('%{textBox1.Text}%') ";
                }

                // AKSESORIS BY TIPE
                if (comboBox2.SelectedIndex > 0)
                {
                    this.where += $"AND AK_TY_ID = {(comboBox2.SelectedItem as dynamic).Value} ";
                }

                // AKSESORIS BY BRAND
                if (comboBox1.SelectedIndex > 0)
                {
                    this.where += $"AND AK_BR_ID = {(comboBox1.SelectedItem as dynamic).Value} ";
                }
            }

            loadDatagridUtama();
        }
    }
}
