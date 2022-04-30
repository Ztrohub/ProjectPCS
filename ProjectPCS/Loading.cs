using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectPCS.Lukas;

namespace ProjectPCS
{
    public partial class Loading : Form
    {
        List<Tuple<Action, string>> mylist = new List<Tuple<Action, string>>();

        //      Masukkan Trigger, Proc, Function disini...

        public Loading()
        {
            InitializeComponent();

            // Buat sebuah method dibawah lalu add disini
            // Bentuknya mylist.Add(new Tuple<Action, string>(nama_method, pesan));
            mylist.Add(new Tuple<Action, string>(cobaConnect, "Try contacting database..."));
        }

        private async void Loading_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = mylist.Count;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            foreach (var list in mylist)
            {
                label2.Text = list.Item2;
                await Task.Delay(1000);
                list.Item1();
                progressBar1.Value += 1;
            }

            label2.Text = "Finishing...";
            await Task.Delay(2000);
            using (Login l = new Login())
            {
                this.Hide();
                l.ShowDialog();
                this.Close();
            }
        }

        // Disini untuk menambahkan method
        void cobaConnect()
        {
            Koneksi.tryOpen();
            if (!Koneksi.test) this.Close();
        }
    }
}
