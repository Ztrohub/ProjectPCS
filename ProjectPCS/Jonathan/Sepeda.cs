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
    public partial class Sepeda : Form
    {
        int us_id;
        int idsepeda = -1;
        public Sepeda(int us_id)
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
                string query = "SELECT sepeda.SP_ID AS 'ID ' ," +
                " sepeda.SP_NAME AS 'Nama', " +
                " Brand.BR_NAME as 'Brand'," +
                " sepeda.SP_AMOUNT as 'Unit Tersedia'," +
                " IFNULL(SUM(dtrans_sepeda.DTSP_AMOUNT), 0) AS 'Unit Dipinjam'," +
                " sepeda.SP_PRICE_HOUR AS 'Harga Perjam'," +
                " sepeda.SP_PRICE_DAY AS 'Harga PerHari'," +
                " type.TY_NAME as 'Tipe'" +
                " FROM sepeda" +
                " JOIN TYPE ON SP_TY_ID = TY_ID" +
                " JOIN brand ON SP_BR_ID = BR_ID" +
                " LEFT JOIN dtrans_sepeda ON DTSP_SP_ID = SP_ID" +
                " LEFT JOIN htrans ON DTSP_HT_ID = HT_ID AND HT_STATUS <> 3" +
                " GROUP BY SP_ID;";

                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());
                da.Fill(dt);
                dgvsepeda.DataSource = dt;
                dgvsepeda.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvsepeda.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvsepeda.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvsepeda.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvsepeda.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvsepeda.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvsepeda.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
                string query = "SELECT sepeda.SP_ID AS 'ID '," +
                " sepeda.SP_NAME AS 'Nama', " +
                " Brand.BR_NAME as 'Brand'," +
                " sepeda.SP_AMOUNT as 'Unit Tersedia'," +
                " IFNULL(SUM(dtrans_sepeda.DTSP_AMOUNT), 0) AS 'Unit Dipinjam'," +
                " sepeda.SP_PRICE_HOUR AS 'Harga Perjam'," +
                " sepeda.SP_PRICE_DAY AS 'Harga PerHari'," +
                " type.TY_NAME as 'Tipe'" +
                " FROM sepeda" +
                " JOIN TYPE ON SP_TY_ID = TY_ID" +
                " JOIN brand ON SP_BR_ID = BR_ID" +
                " LEFT JOIN dtrans_sepeda ON DTSP_SP_ID = SP_ID" +
                " LEFT JOIN htrans ON DTSP_HT_ID = HT_ID AND HT_STATUS <> 3" +
                  keyword+
                " GROUP BY SP_ID;";

                MySqlDataAdapter da = new MySqlDataAdapter(query, Koneksi.getConn());
                da.Fill(dt);
                dgvsepeda.DataSource = dt;
                dgvsepeda.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvsepeda.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvsepeda.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvsepeda.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvsepeda.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvsepeda.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvsepeda.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        private void checkstate()
        {
            if(Koneksi.getConn().State == ConnectionState.Open)
            {
                Koneksi.closeConn();
            }
        }

        void loadcmbtipe()
        {
            checkstate();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = "SELECT TY_NAME,TY_ID from type"+" where ty_for = 0 ";
            Koneksi.openConn();
            MySqlDataReader reader = cmd.ExecuteReader();

            //Setting untuk value dan display dari combobox
            cmbtipe.DisplayMember = "Text";
            cmbtipe.ValueMember = "Value";
            cmbtipe.Items.Add(new { Text = "All", Value = 0 });
            //Setelah dia executeReader, masukkan Items yang didapat ke dalam combobox
            while (reader.Read())
            {
                cmbtipe.Items.Add(new { Text = reader.GetString(0), Value = reader.GetString(1) });

            }
            reader.Close();
            //Ubah selected index jadi 0
            cmbtipe.SelectedIndex = 0;
            Koneksi.closeConn();
        }
        void loadcmbtipeinput()
        {
            checkstate();
            cmbtipeinput.DataSource = null;

            Koneksi.openConn();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from type where ty_for = 0", Koneksi.getConn());
            da.Fill(dt);
            cmbtipeinput.DisplayMember = "TY_NAME";
            cmbtipeinput.ValueMember = "TY_ID";
            cmbtipeinput.DataSource = dt;
            Koneksi.closeConn();
        }



        void loadcmbbrand()
        {
            checkstate();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = "SELECT BR_NAME,BR_ID from brand";
            Koneksi.openConn();
            MySqlDataReader reader = cmd.ExecuteReader();

            //Setting untuk value dan display dari combobox
            cmbbrand.DisplayMember = "Text";
            cmbbrand.ValueMember = "Value";
            cmbbrand.Items.Add(new { Text = "All", Value = 0 });
            //Setelah dia executeReader, masukkan Items yang didapat ke dalam combobox
            while (reader.Read())
            {
                cmbbrand.Items.Add(new { Text = reader.GetString(0), Value = reader.GetString(1) });

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


        private void Form1_Load(object sender, EventArgs e)
        {
            loadcmbtipe();
            loadcmbbrand();
            refresh();
            loadcmbtipeinput();
            loadcmbmerk();
            BtnUpdate.Enabled = false;
            BtnDelete.Enabled = false;



        }

        private void sepedaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AdminForm a = new AdminForm(us_id);
            this.Hide();
            a.ShowDialog();
            this.Close();
        }

        private void aksesorisToolStripMenuItem_Click(object sender, EventArgs e)
        {

           Aksesoris ak = new Aksesoris(us_id);
            this.Hide();
            ak.ShowDialog();
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

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            txtsrc.Text = "";
            cmbtipe.Text = "All";
            cmbbrand.Text = "All";
            


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
        private void dgvsepeda_DoubleClick(object sender, EventArgs e)
        {
            int idx = dgvsepeda.CurrentCell.RowIndex; ;
            idsepeda = Convert.ToInt32(dgvsepeda.Rows[idx].Cells[0].Value.ToString());
            txtid.Text = dgvsepeda.Rows[idx].Cells[0].Value.ToString();
            if (dgvsepeda.Rows[idx].Cells[2].Value.ToString() == "-")
            {
                cmbmerk.SelectedIndex = 0;
            }
            else
            {
                cmbmerk.SelectedValue = getidmerk(dgvsepeda.Rows[idx].Cells[2].Value.ToString());
            }
            txtunit.Text = dgvsepeda.Rows[idx].Cells[3].Value.ToString();
            txtname.Text = dgvsepeda.Rows[idx].Cells[1].Value.ToString();
            txtperjam.Text = dgvsepeda.Rows[idx].Cells[5].Value.ToString();
            txtperhari.Text = dgvsepeda.Rows[idx].Cells[6].Value.ToString();
            if (dgvsepeda.Rows[idx].Cells[7].Value.ToString() == "-")
            {
                cmbtipeinput.SelectedIndex = 0;
            }
            else
            {
                cmbtipeinput.SelectedValue = getidtipe(dgvsepeda.Rows[idx].Cells[7].Value.ToString());
            }

            BtnInsert.Enabled = false; BtnUpdate.Enabled = true;
            BtnDelete.Enabled = true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Koneksi.openConn();
            try
            {
                if (MessageBox.Show("Yakin hapus ? ", "tanya", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
            
                    //command + query untuk insert, lalu di execute seperti biasa
                    MySqlCommand cmdins = new MySqlCommand("delete from sepeda " +
                        " where SP_ID=@id", Koneksi.getConn());


                    cmdins.Parameters.Add(new MySqlParameter("@id",Convert.ToInt32(txtid.Text)));

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

        public int generate_id()
        {
            checkstate();
            MySqlCommand cmd = new MySqlCommand(
                "select max(SP_ID) from sepeda; ", Koneksi.getConn());
            Koneksi.openConn();
            int idbarang = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            Koneksi.closeConn();
            return ++idbarang;
        }

        public int getidtipesepeda(string namatipe)
        {
            checkstate();
            MySqlCommand cmd = new MySqlCommand(
                "select max(TY_ID) from type where LOWER(TY_NAME) = @namatipe; ", Koneksi.getConn());
            cmd.Parameters.AddWithValue("@namatipe", namatipe);
            Koneksi.openConn();
            int idbarang = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            Koneksi.closeConn();
            return idbarang;
        }

        public int getidbrand(string namabrand)
        {
            checkstate();
            MySqlCommand cmd = new MySqlCommand(
                "select max(BR_ID) from brand where LOWER(BR_NAME) = @nama; ", Koneksi.getConn());
            cmd.Parameters.AddWithValue("@nama", namabrand);
            Koneksi.openConn();
            int idbarang = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            Koneksi.closeConn();
            return idbarang;
        }


        private void BtnInsert_Click(object sender, EventArgs e)
        { 
            checkstate();
            if (dgvsepeda.Rows.Count >= 1)
            {
                
                Koneksi.openConn();
                MySqlTransaction tr = Koneksi.getConn().BeginTransaction();
                try
                {
                    MySqlCommand cmd = new MySqlCommand(
                        "insert into sepeda (SP_ID,SP_NAME,SP_AMOUNT,SP_PRICE_DAY,SP_PRICE_HOUR,SP_STATUS,SP_TY_ID,SP_BR_ID) values( @id,@name,@jumlah,@perhari,@perjam,@status,@type,@brand)");
                    cmd.Connection = Koneksi.getConn();
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
                    cmd.Parameters.AddWithValue("@name",txtname.Text);
                    cmd.Parameters.AddWithValue("@jumlah", Convert.ToInt32(txtunit.Text));
                    cmd.Parameters.AddWithValue("@perhari", Convert.ToInt32(txtperhari.Text));
                    cmd.Parameters.AddWithValue("@perjam", Convert.ToInt32(txtperjam.Text));
                        if (rbaktif.Checked)
                            {
                                cmd.Parameters.AddWithValue("@status",1);
                            }
                        else
                         {
                            cmd.Parameters.AddWithValue("@status",0);
                         }
                    cmd.Parameters.AddWithValue("@type", cmbtipeinput.SelectedValue);
                    cmd.Parameters.AddWithValue("@brand", cmbmerk.SelectedValue);
                    cmd.ExecuteNonQuery();
                    tr.Commit();
                    refresh();
                    BtnClear_Click(sender,e);
                    MessageBox.Show("Berhasil insert Sepeda");
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
                MessageBox.Show("Tidak ada sepeda yang di input");
            }   
        }

        private void usersearch(object sender, EventArgs e)
        {
            string where = "";
            if(txtsrc.Text !=" ")
            {
                where += " where LOWER(SP_NAME) Like LOWER('%"+txtsrc.Text+"%')";
            }
            if(cmbtipe.SelectedIndex !=-1 && cmbtipe.SelectedIndex != 0)
            {
                if(where =="")
                {
                    where += "where";
                }
                else
                {
                    where += " and";
                }
                where += " LOWER(TY_NAME) Like LOWER('%"+cmbtipe.Text +"%')";
            }
            if (cmbbrand.SelectedIndex != -1 && cmbbrand.SelectedIndex != 0)
            {
                if (where =="")
                {
                    where += "where";
                }
                else
                {
                    where += " and";
                }
                where += " LOWER(BR_NAME) Like LOWER('%"+cmbbrand.Text+"%')";
            }
            

            if(where !="")
            {
                getrefresh(where);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            BtnInsert.Enabled = true; BtnUpdate.Enabled = false;
            BtnDelete.Enabled = false;
            cmbmerk.SelectedIndex = 1;
            txtname.Text = "";
            txtperjam.Text = "";
            txtperhari.Text = "";
            txtunit.Text = "";
            cmbtipeinput.SelectedIndex = 1;
            txtid.Text = "";
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
                if (dgvsepeda.Rows.Count >= 1)
                {
                   
                    Koneksi.openConn();
                    MySqlTransaction tr = Koneksi.getConn().BeginTransaction();
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(
                            "update sepeda set SP_NAME = @name ,SP_AMOUNT=@jumlah ,SP_PRICE_DAY=@perhari,SP_PRICE_HOUR=@perjam,SP_STATUS=@status,SP_TY_ID=@type,SP_BR_ID=@brand where SP_ID=@id");
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

        private void gantiisi(object sender, EventArgs e)
        {
            if (BtnUpdate.Enabled || BtnDelete.Enabled)
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
    }
}
