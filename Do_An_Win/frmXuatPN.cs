﻿using System;
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
    public partial class frmXuatPN : Form
    {
        public frmXuatPN()
        {
            InitializeComponent();
        }

        private void frmXuatPN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Do_AnDataSet.PHIEUNHAP_VIEW' table. You can move, or remove it, as needed.
            this.PHIEUNHAP_VIEWTableAdapter.Fill(this.Do_AnDataSet.PHIEUNHAP_VIEW);

            this.reportViewer1.RefreshReport();
        }
    }
}
