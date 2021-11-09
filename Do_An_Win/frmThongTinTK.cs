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
    public partial class frmThongTinTK : Form
    {
        string user;
        public frmThongTinTK()
        {
            InitializeComponent();
            
        }
        public frmThongTinTK(string user)
        {
            InitializeComponent();
            this.user = user;
            LoadTTTk();
            setKhoa(false);
        }

        void setKhoa(bool var)
        {
            txtCMND.Enabled = var;
            txtDiaChi.Enabled = var;
            txtHoTen.Enabled = var;
            txtNgaySinh.Enabled = var;
            txtSDT.Enabled = var; 
            btnHuy.Enabled = var;
            btnLuu.Enabled = var;
            btnCNTT.Enabled = !var;
        }
  
        void LoadTTTk()
        {
            DataTable dt = ThongTinDAO.Instance.LoadTTTK(user);
            txtUsername.Text = dt.Rows[0][0].ToString();
            txtPassword.Text = dt.Rows[0][1].ToString();
            txtMaNV.Text = dt.Rows[0][2].ToString();
            txtHoTen.Text = dt.Rows[0][3].ToString();
            txtNgaySinh.Text = dt.Rows[0][4].ToString();
            txtCMND.Text = dt.Rows[0][5].ToString();
            txtDiaChi.Text = dt.Rows[0][6].ToString();
            txtSDT.Text = dt.Rows[0][7].ToString();
        }
        void updateTT(string id, string HoTen, string CMND, string DiaChi, string NgaySinh, string SDT)
        {
            ThongTinDAO.Instance.updateTT(id, HoTen, CMND, DiaChi, NgaySinh, SDT);
        }

        private void btnCNTT_Click(object sender, EventArgs e)
        {
            setKhoa(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadTTTk();
            setKhoa(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string id = txtMaNV.Text;
            string HoTen = txtHoTen.Text;
            string CMND = txtCMND.Text;
            string DiaChi = txtDiaChi.Text;
            string NgaySinh = txtNgaySinh.Text;
            string SDT = txtSDT.Text;
            updateTT(id, HoTen, CMND, DiaChi, NgaySinh, SDT);
            MessageBox.Show("Cập nhật thông tin thành công");
            LoadTTTk();
            setKhoa(false);
        }
    }
}
