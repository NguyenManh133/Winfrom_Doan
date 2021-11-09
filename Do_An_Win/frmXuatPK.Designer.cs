
namespace Do_An_Win
{
    partial class frmXuatPK
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
            this.PHIEUKIEM_VIEWBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PHIEUKIEM_VIEWTableAdapter = new Do_An_Win.Do_AnDataSetTableAdapters.PHIEUKIEM_VIEWTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Do_AnDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHIEUKIEM_VIEWBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "PhieuKiem";
            reportDataSource1.Value = this.PHIEUKIEM_VIEWBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Do_An_Win.Report.rptPhieuKiem.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1001, 566);
            this.reportViewer1.TabIndex = 0;
            // 
            // Do_AnDataSet
            // 
            this.Do_AnDataSet.DataSetName = "Do_AnDataSet";
            this.Do_AnDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PHIEUKIEM_VIEWBindingSource
            // 
            this.PHIEUKIEM_VIEWBindingSource.DataMember = "PHIEUKIEM_VIEW";
            this.PHIEUKIEM_VIEWBindingSource.DataSource = this.Do_AnDataSet;
            // 
            // PHIEUKIEM_VIEWTableAdapter
            // 
            this.PHIEUKIEM_VIEWTableAdapter.ClearBeforeFill = true;
            // 
            // frmXuatPK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmXuatPK";
            this.Text = "frmXuatPK";
            this.Load += new System.EventHandler(this.frmXuatPK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Do_AnDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHIEUKIEM_VIEWBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PHIEUKIEM_VIEWBindingSource;
        private Do_AnDataSet Do_AnDataSet;
        private Do_AnDataSetTableAdapters.PHIEUKIEM_VIEWTableAdapter PHIEUKIEM_VIEWTableAdapter;
    }
}