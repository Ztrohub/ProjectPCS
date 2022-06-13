using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjectPCS.Leonardo
{
    public partial class Jaminan : Form
    {
        public string jnopeng = null;
        public string image = null;
        public int type = -1;
        public string number = null;
        public bool save = false;

        public Jaminan()
        {
            InitializeComponent();
        }

        private void Jaminan_Load(object sender, EventArgs e)
        {

        }

        private bool cekKosong()
        {
            if (textBox1.Text == "") return false;

            if (image == null) return false;

            return true;
        }

        private void Jaminan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!save)
            {
                DialogResult dialogResult = MessageBox.Show("Data belum tersimpan yakin ingin keluar?", "Cancel Input", MessageBoxButtons.YesNo);
                e.Cancel = (dialogResult == DialogResult.No);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!cekKosong())
            {
                MessageBox.Show("Data belum lengkap!");
                return;
            }

            type = radioButton1.Checked ? 1 : radioButton2.Checked ? 2 : 3;
            number = textBox1.Text;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Koneksi.getConn();
            cmd.CommandText = @"SELECT count(*)+1 from jaminan where date(J_date) = curdate()";

            Koneksi.openConn();
            int counter = int.Parse(cmd.ExecuteScalar().ToString());
            Koneksi.closeConn();

            int no = 1000000000 - int.Parse(DateTime.Now.ToString("yyMMdd") + counter.ToString().PadLeft(3, '0'));
            jnopeng = "JM" + no;

            save = true;

            this.Close();
        }

        private string Truncate(string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select a Image";

            string appPath = Path.GetDirectoryName(Application.ExecutablePath);

            string output = appPath + @"\Jaminan\";

            if (Directory.Exists(output) == false)                                              
            {                                                                                    
                Directory.CreateDirectory(output);                                             
            }

            openFileDialog1.InitialDirectory = appPath;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = Koneksi.getConn();
                    cmd.CommandText = @"SELECT ifnull(j_id, 0)+1 from jaminan order by j_id desc limit 1";

                    Koneksi.openConn();
                    string iName = cmd.ExecuteScalar() + ".jpg";
                    Koneksi.closeConn();

                    string filepath = openFileDialog1.FileName;
                    File.Copy(filepath, output + iName, true);

                    label5.Text = "- " + Truncate(openFileDialog1.SafeFileName, 25);
                    label5.ForeColor = Color.Green;
                    image = iName;
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Unable to open file " + exp.Message);
                }
            }
            else
            {
                openFileDialog1.Dispose();
            }

        }
    }
}
