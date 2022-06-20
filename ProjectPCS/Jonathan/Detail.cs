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
    public partial class Detail : Form
    {
        string HT_ID;
        public Detail(string HT_ID)
        {
            InitializeComponent();
            this.HT_ID = HT_ID;
        }

        private void Detail_Load(object sender, EventArgs e)
        {

        }
    }
}
