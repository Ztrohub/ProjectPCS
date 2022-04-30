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
        int us_id;
        public UserForm(int us_id)
        {
            InitializeComponent();
            this.us_id = us_id;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
