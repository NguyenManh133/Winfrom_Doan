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
    public partial class frmHangHoa : Form
    {
        int a = 0;
        string idNV;
        public frmHangHoa()
        {
            InitializeComponent();
            LoadHH();
            setnull();
            setKhoa(false);
            loadNCC();
        }

        void setnull()
        {
            cboDonVi.Text = "";
            txtHH.Text = "";
            txtIDHH.Text = "";
            cboNCC.Text = "";
            txtTonKho.Text = "";
        }
        void setKhoa(bool var)
        {
            cboDonVi.Enabled = var;
            txtHH.Enabled = var;
            txtIDHH.Enabled = var;
            cboNCC.Enabled = var;
            txtTonKho.Enabled = var;
            btnHuy.Enabled = var;
            btnLuu.Enabled = var;
            btnSua.Enabled = !var;
            btnThem.Enabled = !var;
            btnXoa.Enabled = !var;
        }
        public frmHangHoa(string user)
        {
            InitializeComponent();
            LoadHH();
            setnull();
            setKhoa(false);
            loadNCC();
            idNV = NghiepVuDAO.Instance.getIDNV(user);
        }
        void loadNCC()
        {
            DataTable dt = HangHoaDAO.Instance.LoadNCC();
            cboNCC.DataSource = dt;
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "id";
        }
        void LoadHH()
        {
            DataTable dt = HangHoaDAO.Instance.LoadHH();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lv = lvHH.Items.Add(dt.Rows[i][0].ToString());
                lv.SubItems.Add(dt.Rows[i][1].ToString());
                lv.SubItems.Add(dt.Rows[i][2].ToString());
                lv.SubItems.Add(dt.Rows[i][3].ToString());
                lv.SubItems.Add(dt.Rows[i][4].ToString());
            }
        }
        private void lvHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHH.SelectedIndices.Count > 0)
            {
                txtIDHH.Text = lvHH.SelectedItems[0].SubItems[0].Text;
                txtHH.Text= lvHH.SelectedItems[0].SubItems[1].Text;
                txtTonKho.Text = lvHH.SelectedItems[0].SubItems[2].Text;
                cboDonVi.Text = lvHH.SelectedItems[0].SubItems[3].Text;
                cboNCC.Text = lvHH.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            a = 1;
            setnull();
            setKhoa(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (a == 1)
            {
                if(txtHH.Text == "" || txtIDHH.Text == "" || txtTonKho.Text == "" || cboDonVi.Text == "" || cboNCC.Text == "")
                {
                    MessageBox.Show("Xin nhập đủ dữ liệu");
                }
                else
                {
                   for(int i = 0; i < lvHH.Items.Count; i++)
                    {
                        if (txtIDHH.Text == lvHH.Items[i].SubItems[0].Text)
                        {
                            k = 1;
                            break;
                        }
                    }
                    if (k != 1)
                    {
                        HangHoaDAO.Instance.InsertHH(txtIDHH.Text, txtHH.Text, cboNCC.SelectedValue.ToString(), int.Parse(txtTonKho.Text), cboDonVi.Text);
                        MessageBox.Show("Hàng hóa đã được cập nhật");
                        lvHH.Items.Clear();
                        LoadHH();
                    }
                    else
                    {
                        MessageBox.Show("Mã hàng hóa đã tồn tại");
                        k = 0;
                    }
                }
                
            }
            else
            {
                if (txtHH.Text == "" || txtIDHH.Text == "" || txtTonKho.Text == "" || cboDonVi.Text == "" || cboNCC.Text == "")
                {
                    MessageBox.Show("Xin nhập đủ dữ liệu");
                }
                else
                {
                    for (int i = 0; i < lvHH.Items.Count; i++)
                    {
                        if (txtIDHH.Text == lvHH.Items[i].SubItems[0].Text)
                        {
                            k = 1;
                            break;
                        }
                    }
                    if (k == 1)
                    {
                        updateHH(txtIDHH.Text, txtHH.Text, int.Parse(txtTonKho.Text), cboDonVi.Text);
                        lvHH.Items.Clear();
                        LoadHH();
                        k = 0;
                    }
                    else
                    {
                        MessageBox.Show("Mã hàng hóa Không tồn tại");
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (txtIDHH.Text == "")
            {
                MessageBox.Show("Nhập mã hoặc chọn hàng hóa cần xóa");
            }
            else
            {
                for(int i = 0; i < lvHH.Items.Count; i++)
                {
                    if(txtIDHH.Text == lvHH.Items[i].SubItems[0].Text)
                    {
                        HangHoaDAO.Instance.deleteHH(txtIDHH.Text);
                        k = 1;
                        MessageBox.Show("Xóa thành công");
                        lvHH.Items.Clear();
                        LoadHH();
                    }
                }
                if (k != 1) MessageBox.Show("hàng hóa có mã" + txtIDHH.Text + " không tồn tại");
            }
        }
        void updateHH(string id, string TenHH, int TonKho, string dvt)
        {
            HangHoaDAO.Instance.updateHH(id, TenHH, TonKho, dvt);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            setnull();
            setKhoa(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            a = 0;
            setnull();
            setKhoa(false);
        }

        private void btnPhieuKiem_Click(object sender, EventArgs e)
        {
            HangHoaDAO.Instance.insertPK(idNV);
            HangHoaDAO.Instance.insertCT_PK();
            frmXuatPK f = new frmXuatPK();
            f.Show();
        }
    }
}
