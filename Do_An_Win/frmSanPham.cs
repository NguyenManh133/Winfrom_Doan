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
    public partial class frmSanPham : Form
    {
        int x = 0;
        public frmSanPham()
        {
            InitializeComponent();
            LoadSP();
            setNull();
            setKhoa(false);
            setButton(true);
        }
        void setNull()
        {
            txtDonGia.Text = "";
            txtIDSP.Text = "";
            txtLoai.Text = "";
            txtSP.Text = "";
        }
        void setKhoa(bool var)
        {
            txtDonGia.Enabled = var;
            txtIDSP.Enabled = var;
            txtLoai.Enabled = var;
            txtSP.Enabled = var;
        }
        void setButton(bool var)
        {
            btnHuy.Enabled = !var;
            btnLuu.Enabled = !var;
            btnThem.Enabled = var;
            btnXoa.Enabled = var;
            btnSua.Enabled = var;
        }
        void LoadSP()
        {
            DataTable dt = SanPhamDAO.Instance.LoadSP();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lv = lvSP.Items.Add(dt.Rows[i][0].ToString());
                lv.SubItems.Add(dt.Rows[i][1].ToString());
                lv.SubItems.Add(dt.Rows[i][2].ToString());
                lv.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }

        private void lvSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvSP.SelectedIndices.Count > 0)
            {
                txtIDSP.Text = lvSP.SelectedItems[0].SubItems[0].Text;
                txtSP.Text = lvSP.SelectedItems[0].SubItems[1].Text;
                txtDonGia.Text = lvSP.SelectedItems[0].SubItems[2].Text;
                txtLoai.Text = lvSP.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            x = 1;
            setKhoa(true);
            setButton(false);
        }
        bool CheckID(string id)
        {
            DataTable dt = SanPhamDAO.Instance.LoadSP();
            for(int i = 0;i<dt.Rows.Count;i++)
            {
                if(id == dt.Rows[i][0].ToString())
                {
                    return false;
                }
            }
            return true;
        }
        void ThemSP(string id, string Ten, int DonGia, string Loai)
        {
            if (CheckID(id) )
            {
                if (checkTT(id, Ten, DonGia, Loai))
                {
                    lvSP.Items.Clear();
                    SanPhamDAO.Instance.insertSP(id, Ten, DonGia, Loai);
                    LoadSP();
                    MessageBox.Show("Thêm sản phẩm thành công");
                }
                else
                {
                    MessageBox.Show("Nhập đầy đủ thông tin");
                }
            }
            else
            {
                MessageBox.Show("ID sản phẩm đã tồn tại");
            }
        }
        void SuaSP(string id, string Ten, int DonGia, string Loai)
        {
            if (!CheckID(id))
            {
                if (checkTT(id, Ten, DonGia, Loai))
                {
                    lvSP.Items.Clear();
                    SanPhamDAO.Instance.updateSP(id, Ten, DonGia, Loai);
                    LoadSP();
                    MessageBox.Show("Sửa thông tin sản phẩm thành công");
                }
                else
                {
                    MessageBox.Show("Nhập đầy đủ thông tin");
                }

            }
            else
            {
                MessageBox.Show("ID sản phẩm Không tồn tại");
            }
        }
        void XoaSP(string id)
        {   
                if (!CheckID(id))
                {
                    lvSP.Items.Clear();
                    SanPhamDAO.Instance.deleteSP(id);
                    LoadSP();
                    MessageBox.Show("Xóa sản phẩm thành công");
                }
                else
                {
                    MessageBox.Show("sản phẩm không tồn tại");
                }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string id = txtIDSP.Text;
            string Ten = txtSP.Text;
            int DonGia = int.Parse(txtDonGia.Text);
            string Loai = txtLoai.Text;
            switch (x)
            {
                case 1: ThemSP(id, Ten, DonGia, Loai); break;
                case 2: XoaSP(id); break;
                case 3: SuaSP(id, Ten, DonGia, Loai); break;

            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            x = 2;
            setKhoa(true);
            setButton(false);
            
        }
        bool checkTT(string id, string Ten, int DonGia, string Loai)
        {
            if (id == "" || Ten == "" || DonGia == 0 || Loai == "") return false;
            return true;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            x = 3;
            setKhoa(true);
            setButton(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setKhoa(false);
            setButton(true);
        }
    }
}
