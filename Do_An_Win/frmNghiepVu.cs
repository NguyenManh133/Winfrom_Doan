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
    public partial class frmNghiepVu : Form
    {
        int dongia;
        int Tongtien;
        string idsp, idHH;
        string idNV;
 
        public frmNghiepVu()
        {
            InitializeComponent();
            ShowMenu();
            ShowHHPN();
            ShowHHPX();
            LoadBan();
        }
        public frmNghiepVu(string user)
        {
            InitializeComponent();
            ShowMenu();
            ShowHHPN();
            ShowHHPX();
            LoadBan();
            idNV = NghiepVuDAO.Instance.getIDNV(user);
        }
        #region HoaDon
        void LoadBan()
        {
            DataTable dt = NghiepVuDAO.Instance.LoadDSBan();
            cbbBan.DataSource = dt;
            cbbBan.DisplayMember = "Ten";
            cbbBan.ValueMember = "id";
        }
        void setnull()
        {
            txtSDT.Text = "";
            txtKH.Text = "";
            txtSP.Text = "";
            txtSLSP.Text = "";
            txtTongTien.Text = "";
        }
        void ShowMenu()
        {
            DataTable dt = SanPhamDAO.Instance.LoadSP();
            for(int  i = 0;i<dt.Rows.Count;i++)
            {
                ListViewItem lv = lvMenu.Items.Add(dt.Rows[i][0].ToString());
                lv.SubItems.Add(dt.Rows[i][1].ToString());
                lv.SubItems.Add(dt.Rows[i][2].ToString());
                lv.SubItems.Add(dt.Rows[i][3].ToString());
            }    
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMenu.SelectedIndices.Count > 0)
            {
                dongia = int.Parse(lvMenu.SelectedItems[0].SubItems[2].Text);
                txtSP.Text = lvMenu.SelectedItems[0].SubItems[1].Text;
                idsp = lvMenu.SelectedItems[0].SubItems[0].Text;
                txtSLSP.Text = "";
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            
            
            if (txtSLSP.Text == "")
            {
                MessageBox.Show("Nhập số lượng");
                txtSLSP.Focus();
            }
            else
            {
                bool k = false;
                for(int j = 0; j < lvCT_HD.Items.Count; j++)
                {
                    if(lvCT_HD.Items[j].SubItems[1].Text == txtSP.Text)
                    {
                        MessageBox.Show("sp nay da dc chon");
                        k = true;
                        break;
                    }
                }
                if (!k)
                {
                    string[] arr = new string[5];
                    Tongtien = 0;
                    int TT, SL;
                    SL = int.Parse(txtSLSP.Text);
                    TT = SL * dongia;
                    arr[0] = idsp.ToString();
                    arr[1] = txtSP.Text;
                    arr[2] = txtSLSP.Text;
                    arr[3] = dongia.ToString();
                    arr[4] = TT.ToString();
                    ListViewItem lv = lvCT_HD.Items.Add(arr[0].ToString());
                    lv.SubItems.Add(arr[1].ToString());
                    lv.SubItems.Add(arr[2].ToString());
                    lv.SubItems.Add(arr[3].ToString());
                    lv.SubItems.Add(arr[4].ToString());

                    for (int i = 0; i < lvCT_HD.Items.Count; i++)
                    {
                        Tongtien = Tongtien + int.Parse(lvCT_HD.Items[i].SubItems[4].Text);
                    }
                    txtTongTien.Text = Tongtien.ToString();
                }
                

            } 
        }

        void insertCT_HD(int MaHD, string MaSP, int SL, int Thanhtien)
        {
            NghiepVuDAO.Instance.insertCT_HD(MaHD, MaSP , SL, Thanhtien);
        }
        void insertHD(int Tongtien, string MaNV, int MaBan, int MaKH)
        {
             
            NghiepVuDAO.Instance.insertHD(Tongtien , MaNV , MaBan, MaKH );
        }
        void insertKH(string sdt, string hoten)
        {
            NghiepVuDAO.Instance.insertKH(sdt, hoten);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            int MaBan = int.Parse(cbbBan.SelectedValue.ToString());
            string sdt;
            string tenKH;
            int tongtien;
            if (txtKH.Text == "")  tenKH = " ";
            else tenKH = txtKH.Text;
            if (txtSDT.Text == "")   sdt = " ";
            else sdt = txtSDT.Text;
            if (lvCT_HD.Items.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào được chọn");
            }
            else
            {
                tongtien = int.Parse(txtTongTien.Text);
                insertKH(sdt, tenKH);
                int idKH = NghiepVuDAO.Instance.getIDKH();
                insertHD(tongtien, idNV, MaBan, idKH);
                int idHD = NghiepVuDAO.Instance.getIDHD();
                for (int i = 0; i < lvCT_HD.Items.Count; i++)
                {
                    insertCT_HD(idHD, lvCT_HD.Items[i].SubItems[0].Text, int.Parse(lvCT_HD.Items[i].SubItems[2].Text), int.Parse(lvCT_HD.Items[i].SubItems[4].Text));
                }
                setnull();
                MessageBox.Show("Đã lưu thành công");
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {

            txtKH.Text = "";
            txtSDT.Text = "";
        }

        #endregion

        #region PhieuNhap
        void ShowHHPN()
        {
            DataTable dt = NghiepVuDAO.Instance.LoadDSHH();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lv = lvHHPN.Items.Add(dt.Rows[i][0].ToString());
                lv.SubItems.Add(dt.Rows[i][1].ToString());
                lv.SubItems.Add(dt.Rows[i][2].ToString());
            }
        }
        private void lvHHPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHHPN.SelectedIndices.Count > 0)
            {
                txtHHPN.Text = lvHHPN.SelectedItems[0].SubItems[1].Text;
                idHH = lvHHPN.SelectedItems[0].SubItems[0].Text;
            }
        }
        void insertPN(string MaNV, int TongSL)
        {
            NghiepVuDAO.Instance.insertPN(MaNV, TongSL);
        }
        void insertCT_PN(string MaHH, int MaPN, int SL)
        {
            NghiepVuDAO.Instance.insertCT_PN(MaHH, MaPN, SL);
        }

        private void btnLuuPN_Click(object sender, EventArgs e)
        {
            insertPN(idNV, int.Parse(txtTongSL_PN.Text));
            int idPN = NghiepVuDAO.Instance.getIDPN();
            for (int i = 0; i < lvCTPN.Items.Count; i++)
            {
                for(int j = 0; j < lvHHPN.Items.Count; j++)
                {
                    if (lvHHPN.Items[j].SubItems[0].Text == lvCTPN.Items[i].SubItems[0].Text)
                    {
                        NghiepVuDAO.Instance.updateSLHH(lvCTPN.Items[i].SubItems[0].Text, int.Parse(lvHHPN.Items[j].SubItems[2].Text) + int.Parse(lvCTPN.Items[i].SubItems[2].Text));
                    }
                }
                
                insertCT_PN(lvCTPN.Items[i].SubItems[0].Text, idPN, int.Parse(lvCTPN.Items[i].SubItems[2].Text));
                lvHHPN.Items.Clear();
                lvCTPN.Items.Clear();
                ShowHHPN();
                MessageBox.Show("Lưu thành công");
            }
        }
        private void btnThemPN_Click(object sender, EventArgs e)
        {
            if (txtSLPN.Text == "")
            {
                MessageBox.Show("Nhập số lượng");
                txtSLPN.Focus();
            }
            else
            {
                string[] arr = new string[3];
                arr[0] = idHH.ToString();
                arr[1] = txtHHPN.Text;
                arr[2] = txtSLPN.Text;
                ListViewItem lv = lvCTPN.Items.Add(arr[0].ToString());
                lv.SubItems.Add(arr[1].ToString());
                lv.SubItems.Add(arr[2].ToString());
                int TongSL_PN = 0;
                for (int i = 0; i < lvCTPN.Items.Count; i++)
                {
                    TongSL_PN = TongSL_PN + int.Parse(lvCTPN.Items[i].SubItems[2].Text);
                }
                txtTongSL_PN.Text = TongSL_PN.ToString();
            }
        }
        #endregion

        #region PhieuXuat
        void ShowHHPX()
        {
            DataTable dt = NghiepVuDAO.Instance.LoadDSHH();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lv = lvHHPX.Items.Add(dt.Rows[i][0].ToString());
                lv.SubItems.Add(dt.Rows[i][1].ToString());
                lv.SubItems.Add(dt.Rows[i][2].ToString());
            }
        }







        #endregion


        private void btnThemPX_Click(object sender, EventArgs e)
        {
            if (txtSLPX.Text == "")
            {
                MessageBox.Show("Nhập số lượng");
                txtSLPX.Focus();
            }
            else
            {
                string[] arr = new string[3];
                arr[0] = idHH.ToString();
                arr[1] = txtHHPX.Text;
                arr[2] = txtSLPX.Text;
                ListViewItem lv = lvCTPX.Items.Add(arr[0].ToString());
                lv.SubItems.Add(arr[1].ToString());
                lv.SubItems.Add(arr[2].ToString());
                int TongSL_PX = 0;
                for (int i = 0; i < lvCTPX.Items.Count; i++)
                {
                    TongSL_PX = TongSL_PX + int.Parse(lvCTPX.Items[i].SubItems[2].Text);
                }
                txtTongSL_PX.Text = TongSL_PX.ToString();
            }
        }

        void insertPX(string MaNV, int TongSL)
        {
            NghiepVuDAO.Instance.insertPX(MaNV, TongSL);
        }
        void insertCT_PX(string MaHH, int MaPN, int SL)
        {
            NghiepVuDAO.Instance.insertCT_PX(MaHH, MaPN, SL);
        }
        private void btnLuuPx_Click(object sender, EventArgs e)
        {
            insertPX(idNV, int.Parse(txtTongSL_PX.Text));
            int idPX = NghiepVuDAO.Instance.getIDPX();
            for (int i = 0; i < lvCTPX.Items.Count; i++)
            {
                for (int j = 0; j < lvHHPX.Items.Count; j++)
                {
                    if (lvHHPX.Items[j].SubItems[0].Text == lvCTPX.Items[i].SubItems[0].Text)
                    {
                        NghiepVuDAO.Instance.updateSLHH(lvCTPX.Items[i].SubItems[0].Text, int.Parse(lvHHPX.Items[j].SubItems[2].Text) - int.Parse(lvCTPX.Items[i].SubItems[2].Text));
                    }
                }
                insertCT_PX(lvCTPX.Items[i].SubItems[0].Text, idPX, int.Parse(lvCTPX.Items[i].SubItems[2].Text));
                lvHHPX.Items.Clear();
                lvCTPX.Items.Clear();
                ShowHHPX();
                MessageBox.Show("Lưu thành công");
            }
        }

        private void lvCT_HD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCT_HD.SelectedIndices.Count > 0)
            {
                txtSP.Text = lvCT_HD.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Tongtien = 0;
            for (int i = 0; i < lvCT_HD.Items.Count; i++)
            {
                if(lvCT_HD.Items[i].SubItems[1].Text == txtSP.Text)
                {
                    lvCT_HD.Items[i].Remove();
                    txtSP.Text = "";
                    txtSLSP.Text = "";
                }
            }
            for (int i = 0; i < lvCT_HD.Items.Count; i++)
            {
                Tongtien = Tongtien + int.Parse(lvCT_HD.Items[i].SubItems[4].Text);
            }
            txtTongTien.Text = Tongtien.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Tongtien = 0;
            for (int i = 0; i < lvCT_HD.Items.Count; i++)
            {
                if (lvCT_HD.Items[i].SubItems[1].Text == txtSP.Text)
                {
                    lvCT_HD.Items[i].SubItems[2].Text = txtSLSP.Text;
                    txtSP.Text = "";
                    txtSLSP.Text = "";
                }
            }
            for (int i = 0; i < lvCT_HD.Items.Count; i++)
            {
                Tongtien = Tongtien + int.Parse(lvCT_HD.Items[i].SubItems[4].Text);
            }
            txtTongTien.Text = Tongtien.ToString();
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            frmXuatHD f = new frmXuatHD();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmXuatPN f = new frmXuatPN();
            f.Show();
        }

        private void btnXuatPX_Click(object sender, EventArgs e)
        {
            frmXuatPX f = new frmXuatPX();
            f.Show();
        }

        private void lvHHPX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHHPX.SelectedIndices.Count > 0)
            {
                txtHHPX.Text = lvHHPX.SelectedItems[0].SubItems[1].Text;
                idHH = lvHHPX.SelectedItems[0].SubItems[0].Text;
            }
        }

        
    }
}
