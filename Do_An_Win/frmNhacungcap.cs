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
    public partial class frmNhacungcap : Form
    {
        int a = 0;
        public frmNhacungcap()
        {
            InitializeComponent();
            loadNCC();
            setNull();
            setKhoa(false);
        }
        void setNull()
        {
            txtDiaChi.Text = "";
            txtIDNCC.Text = "";
            txtSDT.Text = "";
            txtTenNCC.Text = "";
        }
        void setKhoa(bool var)
        {
            btnHuy.Enabled = var;
            btnLuu.Enabled = var;
            btnSua.Enabled = !var;
            btnThem.Enabled = !var;
            btnXoa.Enabled = !var;
            txtDiaChi.Enabled = var;
            txtIDNCC.Enabled = var;
            txtSDT.Enabled = var;
            txtTenNCC.Enabled = var;
        }
        void loadNCC()
        {
            DataTable dt = NhaCungCapDAO.Instance.loadNCC();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lvNCC.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            a = 1;
            setNull();
            setKhoa(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            setKhoa(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            a = 0;
            setNull();
            setKhoa(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (a == 1)
            {
                if (txtTenNCC.Text == "" || txtSDT.Text == "" || txtIDNCC.Text == "" || txtDiaChi.Text == "")
                {
                    MessageBox.Show("Xin nhập đủ thông tin");
                }
                else
                {
                    NhaCungCapDAO.Instance.insertNCC(txtIDNCC.Text, txtTenNCC.Text, txtSDT.Text, txtDiaChi.Text);
                    MessageBox.Show("Thêm thành công");
                    lvNCC.Items.Clear();
                    loadNCC();
                    setNull();
                    setKhoa(false);
                }
            }
            else
            {
                if (txtIDNCC.Text == "")
                {
                    MessageBox.Show("Nhập id hoặc chọn nhà cung cấp cần sửa thông tin");
                }
                else
                {
                    for(int i = 0; i < lvNCC.Items.Count; i++)
                    {
                        if(txtIDNCC.Text == lvNCC.Items[i].SubItems[0].Text)
                        {
                            k = 1;
                            break;
                        }
                    }
                    if (k == 1)
                    {
                        NhaCungCapDAO.Instance.updateNCC(txtIDNCC.Text, txtTenNCC.Text, txtSDT.Text,txtDiaChi.Text) ;
                        MessageBox.Show("Cập nhật thông tin nhà cung cấp " + txtIDNCC.Text + " thành công");
                        lvNCC.Items.Clear();
                        loadNCC();
                        setNull();
                        setKhoa(false);
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại nhà cung cấp mang id " + txtIDNCC.Text);
                    }
                }
                
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtIDNCC.Text == "")
            {
                MessageBox.Show("Hãy chọn nhà cung cấp cần sóa");
            }
            else
            {
                NhaCungCapDAO.Instance.deleteNCC(txtIDNCC.Text);
                MessageBox.Show("Xóa thành công");
                lvNCC.Items.Clear();
                loadNCC();
                setNull();
            }
        }

        private void lvNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNCC.SelectedIndices.Count > 0)
            {
                txtTenNCC.Text = lvNCC.SelectedItems[0].SubItems[1].Text;
                txtIDNCC.Text = lvNCC.SelectedItems[0].SubItems[0].Text;
                txtSDT.Text= lvNCC.SelectedItems[0].SubItems[2].Text;
                txtDiaChi.Text = lvNCC.SelectedItems[0].SubItems[3].Text;
            }
        }
    }
}
