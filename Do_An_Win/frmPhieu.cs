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
    public partial class frmPhieu : Form
    {
        int x;
        public frmPhieu()
        {
            InitializeComponent();
            ListHoaDon();
            LoadDSPN();
            LoadDSPX();
            loadDSPK();
        }

        public void ListHoaDon()
        {
            DataTable dt = PhieuDAO.Instance.LoadDSHD();
            for(int i = 0; i<dt.Rows.Count; i++)
            {
                ListViewItem lv = lvDSHD.Items.Add(dt.Rows[i][0].ToString());
                lv.SubItems.Add(dt.Rows[i][1].ToString());
                lv.SubItems.Add(dt.Rows[i][2].ToString());
                lv.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }


        private void lvDSHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lvDSHD.SelectedIndices.Count > 0)
            {
                x = int.Parse(lvDSHD.SelectedItems[0].SubItems[0].Text);
                DataTable dt = PhieuDAO.Instance.LoadTT(x);
                txtBan.Text = dt.Rows[0][2].ToString();
                txtIDHoaDon.Text = x.ToString();
                txtNVPT.Text = dt.Rows[0][1].ToString();
                txtSDT_KH.Text = dt.Rows[0][0].ToString();
                txtTenKhachHang.Text = lvDSHD.SelectedItems[0].SubItems[3].Text;
                txtTongTien.Text = lvDSHD.SelectedItems[0].SubItems[2].Text;
                txtNgay.Text = lvDSHD.SelectedItems[0].SubItems[1].Text;
                DataTable ds = PhieuDAO.Instance.LoadCT_HD(x);
                lvCT_HD.Items.Clear();
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    ListViewItem liv = lvCT_HD.Items.Add(ds.Rows[i][0].ToString());
                    liv.SubItems.Add(ds.Rows[i][1].ToString());
                    liv.SubItems.Add(ds.Rows[i][2].ToString());
                    liv.SubItems.Add(ds.Rows[i][3].ToString());
                    liv.SubItems.Add(ds.Rows[i][4].ToString());
                }
            } 
        }
        void LoadDSPN()
        {
            DataTable dt = PhieuDAO.Instance.LoadDSPN();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lv = lvDSPN.Items.Add(dt.Rows[i][0].ToString());
                lv.SubItems.Add(dt.Rows[i][1].ToString());
                lv.SubItems.Add(dt.Rows[i][2].ToString());
                lv.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }
        void LoadDSPX()
        {
            DataTable dt = PhieuDAO.Instance.LoadDSPX();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lv = lvDSPX.Items.Add(dt.Rows[i][0].ToString());
                lv.SubItems.Add(dt.Rows[i][1].ToString());
                lv.SubItems.Add(dt.Rows[i][2].ToString());
                lv.SubItems.Add(dt.Rows[i][3].ToString());
            }
        }
        void loadDSPK()
        {
            DataTable dt = PhieuDAO.Instance.LoadDSPK();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lv = lvDSPK.Items.Add(dt.Rows[i][0].ToString());
                lv.SubItems.Add(dt.Rows[i][1].ToString());
                lv.SubItems.Add(dt.Rows[i][2].ToString());
            }
        }
        private void lvDSPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvDSPN.SelectedIndices.Count > 0)
            {
                x = int.Parse(lvDSPN.SelectedItems[0].SubItems[0].Text);
                txtIDPN.Text = lvDSPN.SelectedItems[0].SubItems[0].Text;
                txtNVPTPN.Text = lvDSPN.SelectedItems[0].SubItems[1].Text;
                txtNgayPN.Text = lvDSPN.SelectedItems[0].SubItems[2].Text;
                txtTongSL.Text = lvDSPN.SelectedItems[0].SubItems[3].Text;
                DataTable dt = PhieuDAO.Instance.LoadCT_PN(x);
                lvCT_PN.Items.Clear();
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lv = lvCT_PN.Items.Add(dt.Rows[i][0].ToString());
                    lv.SubItems.Add(dt.Rows[i][1].ToString());
                    lv.SubItems.Add(dt.Rows[i][2].ToString());
                    lv.SubItems.Add(dt.Rows[i][3].ToString());
                }
            }
        }

        private void lvDSPX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDSPX.SelectedIndices.Count > 0)
            {
                x = int.Parse(lvDSPX.SelectedItems[0].SubItems[0].Text);
                txtIDPX.Text = lvDSPX.SelectedItems[0].SubItems[0].Text;
                txtNVPTPX.Text = lvDSPX.SelectedItems[0].SubItems[1].Text;
                txtNgayPX.Text = lvDSPX.SelectedItems[0].SubItems[2].Text;
                txtTongSLXuat.Text = lvDSPX.SelectedItems[0].SubItems[3].Text;
                DataTable dt = PhieuDAO.Instance.LoadCT_PX(x);
                lvCT_PX.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lv = lvCT_PX.Items.Add(dt.Rows[i][0].ToString());
                    lv.SubItems.Add(dt.Rows[i][1].ToString());
                    lv.SubItems.Add(dt.Rows[i][2].ToString());
                    lv.SubItems.Add(dt.Rows[i][3].ToString());
                }
            }
        }

        private void lvDSPK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDSPK.SelectedIndices.Count > 0)
            {
                txtIDPK.Text = lvDSPK.SelectedItems[0].SubItems[0].Text;
                txtNVPTPK.Text = lvDSPK.SelectedItems[0].SubItems[1].Text;
                txtNgayPK.Text = lvDSPK.SelectedItems[0].SubItems[2].Text;
                DataTable dt = PhieuDAO.Instance.LoadCT_PK(int.Parse(lvDSPK.SelectedItems[0].SubItems[0].Text));
                lvCT_PK.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lv = lvCT_PK.Items.Add(dt.Rows[i][0].ToString());
                    lv.SubItems.Add(dt.Rows[i][1].ToString());
                    lv.SubItems.Add(dt.Rows[i][2].ToString());
                    lv.SubItems.Add(dt.Rows[i][3].ToString());
                }
            }

        }
    }
}
