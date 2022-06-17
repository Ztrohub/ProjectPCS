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
    public partial class Aksesoris : Form
    {
        int us_id;
        int idaksesoris = -1;
        public Aksesoris(int us_id)
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
                string query = "SELECT aksesoris.AK_ID AS 'ID ' ," +
                " aksesoris.AK_NAME AS 'Nama', " +
                " Brand.BR_NAME as 'Brand'," +
                " aksesoris.AK_AMOUNT as 'Unit Tersedia'," +
                " IFNULL(SUM(dtrans_aksesoris.DTAK_AMOUNT), 0) AS 'Unit Dipinjam'," +
                " aksesoris.AK_PRICE_HOUR AS 'Harga Perjam'," +
                " aksesoris.AK_PRICE_DAY AS 'Harga PerHari'," +
                " type.TY_NAME as 'Tipe'" +
                " FROM aksesoris" +
                " JOIN TYPE ON AK_TY_ID = TY_ID" +
                " JOIN brand ON AK_BR_ID = BR_ID" +
                " LEFT JOIN dtrans_aksesoris ON DTAK_AK_ID = AK_ID" +
                " LEFT JOIN htrans ON DTAK_HT_ID = HT_ID AND HT_STATUS <> 3" +
                " GROUP BY AK_ID;";

                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());
                da.Fill(dt);
                dgvaksesoris.DataSource = dt;
                dgvaksesoris.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvaksesoris.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvaksesoris.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvaksesoris.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvaksesoris.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvaksesoris.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvaksesoris.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvaksesoris.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public void getrefresh(string keyword)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                string query = "SELECT aksesoris.AK_ID AS 'ID ' ," +
                " aksesoris.AK_NAME AS 'Nama', " +
                " Brand.BR_NAME as 'Brand'," +
                " aksesoris.AK_AMOUNT as 'Unit Tersedia'," +
                " IFNULL(SUM(dtrans_aksesoris.DTAK_AMOUNT), 0) AS 'Unit Dipinjam'," +
                " aksesoris.AK_PRICE_HOUR AS 'Harga Perjam'," +
                " aksesoris.AK_PRICE_DAY AS 'Harga PerHari'," +
                " type.TY_NAME as 'Tipe'" +
                " FROM aksesoris" +
                " JOIN TYPE ON AK_TY_ID = TY_ID" +
                " JOIN brand ON AK_BR_ID = BR_ID" +
                " LEFT JOIN dtrans_aksesoris ON DTAK_AK_ID = AK_ID" +
                " LEFT JOIN htrans ON DTAK_HT_ID = HT_ID AND HT_STATUS <> 3" +
                keyword +
                " GROUP BY AK_ID;";

                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());
                da.Fill(dt);
                dgvaksesoris.DataSource = dt;
                dgvaksesoris.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvaksesoris.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvaksesoris.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvaksesoris.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvaksesoris.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvaksesoris.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvaksesoris.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void checkstate()
        {
            if (Koneksi.getConn().State == ConnectionState.Open)
            {
                Koneksi.closeConn();
            }
        }
        void loadcmbtipe()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = "SELECT TY_NAME from type" + " where ty_for = 1 ";
            Koneksi.openConn();
            MySqlDataReader reader = cmd.ExecuteReader();

            //Setting untuk value dan display dari combobox
            cmbtipe.DisplayMember = "Text";
            cmbtipe.ValueMember = "Value";
            cmbtipe.Items.Add(new { Text = "All", Value = 0 });
            //Setelah dia executeReader, masukkan Items yang didapat ke dalam combobox
            while (reader.Read())
            {
                cmbtipe.Items.Add(new { Text = reader.GetString(0), Value = reader.GetString(0) });

            }
            reader.Close();
            //Ubah selected index jadi 0
            cmbtipe.SelectedIndex = 0;
            Koneksi.closeConn();
        }

        void loadcmbbrand()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = "SELECT BR_NAME from brand";
            Koneksi.openConn();
            MySqlDataReader reader = cmd.ExecuteReader();

            //Setting untuk value dan display dari combobox
            cmbbrand.DisplayMember = "Text";
            cmbbrand.ValueMember = "Value";
            cmbbrand.Items.Add(new { Text = "All", Value = 0 });
            //Setelah dia executeReader, masukkan Items yang didapat ke dalam combobox
            while (reader.Read())
            {
                cmbbrand.Items.Add(new { Text = reader.GetString(0), Value = reader.GetString(0) });

            }
            reader.Close();
            //Ubah selected index jadi 0
            cmbbrand.SelectedIndex = 0;
            Koneksi.closeConn();
        }
        void loadcmbmerk()
        {
            checkstate();
            cmbmerk.DataSource = null;

            Koneksi.openConn();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from brand", Koneksi.getConn());
            da.Fill(dt);
            cmbmerk.DisplayMember = "BR_NAME";
            cmbmerk.ValueMember = "BR_ID";
            cmbmerk.DataSource = dt;
            Koneksi.closeConn();
        }
        private void Aksesoris_Load(object sender, EventArgs e)
        {
            loadcmbbrand();
            loadcmbtipe();
            refresh();
            loadcmbmerk();
            loadcmbtipeinput();
            BtnUpdate.Enabled = false;
            btndelete.Enabled = false;
        }
        void loadcmbtipeinput()
        {
            checkstate();
            cmbtipeinput.DataSource = null;

            Koneksi.openConn();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from type where ty_for = 1", Koneksi.getConn());
            da.Fill(dt);
            cmbtipeinput.DisplayMember = "TY_NAME";
            cmbtipeinput.ValueMember = "TY_ID";
            cmbtipeinput.DataSource = dt;
            Koneksi.closeConn();
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

        public int getidmerk(string merk)
        {
            checkstate();
            MySqlCommand cmd = new MySqlCommand("SELECT BR_ID from brand  where LOWER(BR_NAME) = LOWER(@merk) ;");
            cmd.Connection = Koneksi.getConn();
            cmd.Parameters.AddWithValue("@merk", merk);

            Koneksi.openConn();
            int idtipe = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            Koneksi.closeConn();

            return idtipe;
        }
        public int getidtipe(string type)
        {
            checkstate();
            MySqlCommand cmd = new MySqlCommand("SELECT TY_ID from type where LOWER(TY_NAME) = LOWER(@tipe) ;");
            cmd.Connection = Koneksi.getConn();
            cmd.Parameters.AddWithValue("@tipe", type);

            Koneksi.openConn();
            int idtipe = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            Koneksi.closeConn();

            return idtipe;
        }
        private void dgvaksesoris_DoubleClick(object sender, EventArgs e)
        {
            int idx = dgvaksesoris.CurrentCell.RowIndex; ;
            idaksesoris = Convert.ToInt32(dgvaksesoris.Rows[idx].Cells[0].Value.ToString());
            txtid.Text = dgvaksesoris.Rows[idx].Cells[0].Value.ToString();
            if (dgvaksesoris.Rows[idx].Cells[2].Value.ToString() == "-")
            {
                cmbmerk.SelectedIndex = 0;
            }
            else
            {
                cmbmerk.SelectedValue = getidmerk(dgvaksesoris.Rows[idx].Cells[2].Value.ToString());
            }
            txtunit.Text = dgvaksesoris.Rows[idx].Cells[3].Value.ToString();
            txtname.Text = dgvaksesoris.Rows[idx].Cells[1].Value.ToString();
            txtperjam.Text = dgvaksesoris.Rows[idx].Cells[5].Value.ToString();
            txtperhari.Text = dgvaksesoris.Rows[idx].Cells[6].Value.ToString();
            if (dgvaksesoris.Rows[idx].Cells[7].Value.ToString() == "-")
            {
                cmbtipeinput.SelectedIndex = 0;
            }
            else
            {
                cmbtipeinput.SelectedValue = getidtipe(dgvaksesoris.Rows[idx].Cells[7].Value.ToString());
            }

            Btninsert.Enabled = false; BtnUpdate.Enabled = true;
            btndelete.Enabled = true;
        }


        private void btndelete_Click(object sender, EventArgs e)
        {
            Koneksi.openConn();
            try
            {
                if (MessageBox.Show("Yakin hapus ? ", "tanya", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    //command + query untuk insert, lalu di execute seperti biasa
                    MySqlCommand cmdins = new MySqlCommand("delete from aksesoris " +
                        " where AK_ID=@id", Koneksi.getConn());


                    cmdins.Parameters.Add(new MySqlParameter("@id", Convert.ToInt32(txtid.Text)));

                    cmdins.ExecuteNonQuery();
                    MessageBox.Show("Berhasil delete");
                    refresh();
                    BtnClear_Click(sender, e);
                }
            }

            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            Koneksi.closeConn();
        }

        private void usersearch(object sender, EventArgs e)
        {
            string where = "";
            if (txtsrc.Text != " ")
            {
                where += " where LOWER(AK_NAME) Like LOWER('%" + txtsrc.Text + "%')";
            }
            if (cmbtipe.SelectedIndex != -1 && cmbtipe.SelectedIndex != 0)
            {
                if (where == "")
                {
                    where += "where";
                }
                else
                {
                    where += " and";
                }
                where += " LOWER(TY_NAME) Like LOWER('%" + cmbtipe.Text + "%')";
            }
            if (cmbbrand.SelectedIndex != -1 && cmbbrand.SelectedIndex != 0)
            {
                if (where == "")
                {
                    where += "where";
                }
                else
                {
                    where += " and";
                }
                where += " LOWER(BR_NAME) Like LOWER('%" + cmbbrand.Text + "%')";
            }
            

            if (where != "")
            {
                getrefresh(where);
            }
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            txtsrc.Text = "";
            cmbtipe.Text = "All";
            cmbbrand.Text = "All";
           

        }

        private void Btninsert_Click(object sender, EventArgs e)
        {
            checkstate();
            if (dgvaksesoris.Rows.Count >= 1)
            {

                Koneksi.openConn();
                MySqlTransaction tr = Koneksi.getConn().BeginTransaction();
                try
                {
                    MySqlCommand cmd = new MySqlCommand(
                        "insert into aksesoris (AK_ID,AK_NAME,AK_BR_ID,AK_AMOUNT,AK_PRICE_DAY,AK_PRICE_HOUR,AK_STATUS,AK_TY_ID) values( @id,@name,@brand,@jumlah,@perhari,@perjam,@status,@type)");
                    cmd.Connection = Koneksi.getConn();
                    cmd.Parameters.AddWithValue("@id","");
                    cmd.Parameters.AddWithValue("@name", txtname.Text);
                    cmd.Parameters.AddWithValue("@jumlah", Convert.ToInt32(txtunit.Text));
                    cmd.Parameters.AddWithValue("@perhari", Convert.ToInt32(txtperhari.Text));
                    cmd.Parameters.AddWithValue("@perjam", Convert.ToInt32(txtperjam.Text));
                    if (rbaktif.Checked)
                    {
                        cmd.Parameters.AddWithValue("@status", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@status", 0);
                    }
                    cmd.Parameters.AddWithValue("@type", cmbtipeinput.SelectedValue);
                    cmd.Parameters.AddWithValue("@brand", cmbmerk.SelectedValue);
                    cmd.ExecuteNonQuery();
                    tr.Commit();
                    refresh();
                    BtnClear_Click(sender, e);
                    MessageBox.Show("Berhasil insert Aksesoris");
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Gagal simpan " + ex.Message);
                }
                Koneksi.closeConn();
            }
            else
            {
                MessageBox.Show("Tidak ada Aksesoris yang di input");
            }
        }

        public int generate_id()
        {
            checkstate();
            MySqlCommand cmd = new MySqlCommand(
                "select max(AK_ID) from aksesoris; ", Koneksi.getConn());
            Koneksi.openConn();
            int idbarang = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            Koneksi.closeConn();
            return ++idbarang;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Btninsert.Enabled = true; BtnUpdate.Enabled = false;
            btndelete.Enabled = false;
            cmbmerk.SelectedIndex = 1;
            txtname.Text = "";
            txtperjam.Text = "";
            txtperhari.Text = "";
            txtunit.Text = "";
            cmbtipeinput.SelectedIndex = 1;
            txtid.Text = "";
        }

        private void gantiisi(object sender, EventArgs e)
        {
            if (BtnUpdate.Enabled || btndelete.Enabled)
            {
                return;
            }
            else
            {
                if (cmbmerk.SelectedIndex == -1 && txtunit.Text == "" && txtname.Text == "" && txtperjam.Text == "" && txtperhari.Text == "" && cmbtipeinput.SelectedIndex == -1)
                {
                    txtid.Text = "";
                }
                else if (txtid.Text == "")
                {
                    txtid.Text = generate_id().ToString();
                }

            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbmerk.SelectedIndex == -1 && txtunit.Text == "" && txtname.Text == "" && txtperjam.Text == "" && txtperhari.Text == "" && cmbtipeinput.SelectedIndex == -1)
            {
                MessageBox.Show("field harus di isi");
            }
            else
            {
                checkstate();
                if (dgvaksesoris.Rows.Count >= 1)
                {

                    Koneksi.openConn();
                    MySqlTransaction tr = Koneksi.getConn().BeginTransaction();
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(
                            "update aksesoris set AK_NAME = @name ,AK_AMOUNT=@jumlah ,AK_PRICE_DAY=@perhari,AK_PRICE_HOUR=@perjam,AK_STATUS=@status,AK_TY_ID=@type,AK_BR_ID=@brand where AK_ID=@id");
                        cmd.Connection = Koneksi.getConn();
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
                        cmd.Parameters.AddWithValue("@name", txtname.Text);
                        cmd.Parameters.AddWithValue("@jumlah", Convert.ToInt32(txtunit.Text));
                        cmd.Parameters.AddWithValue("@perhari", Convert.ToInt32(txtperhari.Text));
                        cmd.Parameters.AddWithValue("@perjam", Convert.ToInt32(txtperjam.Text));
                        if (rbaktif.Checked)
                        {
                            cmd.Parameters.AddWithValue("@status", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@status", 0);
                        }
                        cmd.Parameters.AddWithValue("@type", cmbtipeinput.SelectedValue);
                        cmd.Parameters.AddWithValue("@brand", cmbmerk.SelectedValue);
                        cmd.ExecuteNonQuery();
                        tr.Commit();
                        refresh();
                        BtnClear_Click(sender, e);
                        MessageBox.Show("Berhasil Update");
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        MessageBox.Show("Gagal Update " + ex.Message);
                    }
                    Koneksi.closeConn();
                }
                else
                {
                    MessageBox.Show("Tidak ada sepeda yang di pilih");
                }
            }
        }
    }
}
