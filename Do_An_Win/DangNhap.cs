using Do_An_Win.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Win
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public delegate void LayUser(string text);
        public LayUser instance;

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassWord.Text;
            
            if (DangNhap.Instance.Logind(username,password))
            {      
                if (txtUserName.Text.Length > 0)
                {
                    if (instance != null)
                    {
                        Close();
                        instance(username);
                    }
                }
            }
            else
            {
                MessageBox.Show("Tai khoan hoac mat khau khong chinh xac");
            }
        }
    }
}
