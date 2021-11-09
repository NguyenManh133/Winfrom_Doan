
namespace Do_An_Win
{
    partial class frmXuatHD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Do_AnDataSet = new Do_An_Win.Do_AnDataSet();
            this.HOADON_VIEWBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HOADON_VIEWTableAdapter = new Do_An_Win.Do_AnDataSetTableAdapters.HOADON_VIEWTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Do_AnDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOADON_VIEWBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.HOADON_VIEWBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Do_An_Win.Report.rptHoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1001, 558);
            this.reportViewer1.TabIndex = 0;
            // 
            // Do_AnDataSet
            // 
            this.Do_AnDataSet.DataSetName = "Do_AnDataSet";
            this.Do_AnDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // HOADON_VIEWBindingSource
            // 
            this.HOADON_VIEWBindingSource.DataMember = "HOADON_VIEW";
            this.HOADON_VIEWBindingSource.DataSource = this.Do_AnDataSet;
            // 
            // HOADON_VIEWTableAdapter
            // 
            this.HOADON_VIEWTableAdapter.ClearBeforeFill = true;
            // 
            // frmXuatHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmXuatHD";
            this.Text = "Xuất Hóa Đơn";
            this.Load += new System.EventHandler(this.frmXuatHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Do_AnDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOADON_VIEWBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource HOADON_VIEWBindingSource;
        private Do_AnDataSet Do_AnDataSet;
        private Do_AnDataSetTableAdapters.HOADON_VIEWTableAdapter HOADON_VIEWTableAdapter;
    }
}