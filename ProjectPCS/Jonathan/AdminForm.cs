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
    public partial class AdminForm : Form
    {
        int us_id;
        public AdminForm(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
