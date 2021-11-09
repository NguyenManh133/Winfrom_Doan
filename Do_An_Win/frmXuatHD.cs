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
    public partial class frmXuatHD : Form
    {
        public frmXuatHD()
        {
            InitializeComponent();
        }

        private void frmXuatHD_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Do_AnDataSet.PHIEUKIEM_VIEW' table. You can move, or remove it, as needed.
            this.PHIEUKIEM_VIEWTableAdapter.Fill(this.Do_AnDataSet.PHIEUKIEM_VIEW);
            // TODO: This line of code loads data into the 'Do_AnDataSet1.HOADON_VIEW' table. You can move, or remove it, as needed.

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
