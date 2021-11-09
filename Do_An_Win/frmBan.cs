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
    public partial class frmBan : Form
    {
        int a = 0;
        public frmBan()
        {
            InitializeComponent();
            loadDSBan();
            setKhoa(false);
        }
        void setNull()
        {
            txtIDBan.Text = "";
            txtTenBan.Text = "";
        }
        void setKhoa(bool var)
        {
            txtIDBan.Enabled = var;
            txtTenBan.Enabled = var;
            cboTrangThaiBan.Enabled = var;
            btnHuy.Enabled = var;
            btnLuu.Enabled = var;
            btnThem.Enabled = !var;
            btnXoa.Enabled = !var;
            btnSua.Enabled = !var;
        }

        void loadDSBan()
        {
            DataTable dt = BanDAO.Instance.LoadBan();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lvBan.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
            }
            
        }
        private void lvBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvBan.SelectedIndices.Count > 0)
            {
                txtIDBan.Text = lvBan.SelectedItems[0].SubItems[0].Text;
                txtTenBan.Text = lvBan.SelectedItems[0].SubItems[1].Text;
                cboTrangThaiBan.Text = lvBan.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            a = 1;
            setKhoa(true);
            setNull();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtIDBan.Text == "")
            {
                MessageBox.Show("Chưa chọn bàn cần xóa");
            }
            else
            {
                BanDAO.Instance.deleteBan(int.Parse(txtIDBan.Text));
                MessageBox.Show("Xóa thành công");
                lvBan.Items.Clear();
                loadDSBan();
                setNull();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int k = 0;
            int x = 0;
            if (a == 1) 
            {
                if (cboTrangThaiBan.Text == "" || txtTenBan.Text == "")
                {
                    MessageBox.Show("Nhập thiếu thông tin");
                }
                else
                {
                    
                    if (cboTrangThaiBan.Text == "Hoạt động") k = 1;
                    BanDAO.Instance.insertBan(txtTenBan.Text, k);
                    MessageBox.Show("Bàn đã được thêm");
                    lvBan.Items.Clear();
                    loadDSBan();
                    setKhoa(false);
                    setNull();
                }
            }
            else
            {
                if(txtIDBan.Text == "" || txtTenBan.Text == "")
                {
                    MessageBox.Show("Nhập thiếu thông tin");
                }
                else
                {
                    for(int i = 0; i < lvBan.Items.Count; i++)
                    {
                        if(txtIDBan.Text == lvBan.Items[i].SubItems[0].Text)
                        {
                            x = 1;
                            break;
                        }
                    }
                    if (x == 1) 
                    {
                        BanDAO.Instance.updataBan(int.Parse(txtIDBan.Text), txtTenBan.Text, k);
                        lvBan.Items.Clear();
                        loadDSBan();
                        MessageBox.Show("Thông tin bàn đã được sửa");
                        setKhoa(false);
                        setNull();
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại bàn mang mã " + txtIDBan.Text);
                    }
                    
                }
            }
            

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setKhoa(false);
            setNull();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            a = 0;
            setKhoa(true);
        }
    }
}
