using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLocker
{
    public partial class frmLogin : Form
    {
        public bool IsLogin { get; private set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            IsLogin = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == Account.Username && txtPassword.Text == Account.Password)
            {
                IsLogin = true;
                this.Close();
            }
        }
    }
}
