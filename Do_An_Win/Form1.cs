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
    public partial class frmGiaoDien : Form
    {
        string user;
        private void Layuser(string user)
        {
            this.user = " ";
            this.user = user;
        }
        public frmGiaoDien()
        {
            InitializeComponent();
        }


        private void dăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.Show();
            f.instance = new frmLogin.LayUser(Layuser);
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(user != null)
            {
                frmSanPham f = new frmSanPham();
                f.ShowDialog();
            }
            else
            {
                frmLogin f = new frmLogin();
                f.Show();
                f.instance = new frmLogin.LayUser(Layuser);
            }
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(user != null) { 
            frmThongTinTK f = new frmThongTinTK(user);
            f.Show();
            }
            else
            {
                frmLogin f = new frmLogin();
                f.Show();
                f.instance = new frmLogin.LayUser(Layuser);
            }
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                frmHangHoa f = new frmHangHoa(user);
                f.Show();
            }
            else
            {
                frmLogin f = new frmLogin();
                f.Show();
                f.instance = new frmLogin.LayUser(Layuser);
            }
        }

        private void nghiệpVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                frmNghiepVu f = new frmNghiepVu(user);
                f.Show();
            }
            else
            {
                frmLogin f = new frmLogin();
                f.Show();
                f.instance = new frmLogin.LayUser(Layuser);
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user = null;
            frmLogin f = new frmLogin();
            f.Show();
            f.instance = new frmLogin.LayUser(Layuser);
        }

        private void bànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                frmBan f = new frmBan();
                f.ShowDialog();
            }
            else
            {
                frmLogin f = new frmLogin();
                f.Show();
                f.instance = new frmLogin.LayUser(Layuser);
            }
        }

        private void phiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                frmPhieu f = new frmPhieu();
                f.ShowDialog();
            }
            else
            {
                frmLogin f = new frmLogin();
                f.Show();
                f.instance = new frmLogin.LayUser(Layuser);
            }
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                frmNhacungcap f = new frmNhacungcap();
                f.ShowDialog();
            }
            else
            {
                frmLogin f = new frmLogin();
                f.Show();
                f.instance = new frmLogin.LayUser(Layuser);
            }
        }

        private void hỗTrợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                if (user == "admin")
                {
                    frmAdmin f = new frmAdmin();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("chức năng này chỉ danh cho admin");
                }
               
            }
            else
            {
                frmLogin f = new frmLogin();
                f.Show();
                f.instance = new frmLogin.LayUser(Layuser);
            }
        }


    }
}
