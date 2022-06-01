﻿using System;
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
    public partial class topup : Form
    {
        int us_id;
        MySqlCommand cmd;
        MySqlDataReader rd;
        DataSet ds;
        MySqlDataAdapter da;
        DataTable dt;
        public topup(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        private void topup_Load(object sender, EventArgs e)
        {
            loaddatagrid1();
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
                cmd.CommandText = @"SELECT dm_name AS 'Kegiatan', CONCAT('Rp. ',dm_amount) AS 'Jumlah', dm_date AS 'Tanggal' FROM dompet;";

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
        }

        private void sepedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm b = new UserForm(us_id);
            this.Hide();
            b.ShowDialog();
            this.Close();
        }

        private void aksesorisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aksesoris b = new aksesoris(us_id);
            this.Hide();
            b.ShowDialog();
            this.Close();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history c = new history(us_id);
            this.Hide();
            c.ShowDialog();
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

        private void topup_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to logout?", "Log Out", MessageBoxButtons.YesNo);
            e.Cancel = (dialogResult == DialogResult.No);
        }
    }
}
