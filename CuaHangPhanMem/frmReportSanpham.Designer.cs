
namespace CuaHangPhanMem
{
    partial class frmReportSanpham
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
            this.QUANLYBANHANGDataSet3 = new CuaHangPhanMem.QUANLYBANHANGDataSet3();
            this.PROC_GETSANPHAMBYDATEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PROC_GETSANPHAMBYDATETableAdapter = new CuaHangPhanMem.QUANLYBANHANGDataSet3TableAdapters.PROC_GETSANPHAMBYDATETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYBANHANGDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PROC_GETSANPHAMBYDATEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetSP";
            reportDataSource1.Value = this.PROC_GETSANPHAMBYDATEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CuaHangPhanMem.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // QUANLYBANHANGDataSet3
            // 
            this.QUANLYBANHANGDataSet3.DataSetName = "QUANLYBANHANGDataSet3";
            this.QUANLYBANHANGDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PROC_GETSANPHAMBYDATEBindingSource
            // 
            this.PROC_GETSANPHAMBYDATEBindingSource.DataMember = "PROC_GETSANPHAMBYDATE";
            this.PROC_GETSANPHAMBYDATEBindingSource.DataSource = this.QUANLYBANHANGDataSet3;
            // 
            // PROC_GETSANPHAMBYDATETableAdapter
            // 
            this.PROC_GETSANPHAMBYDATETableAdapter.ClearBeforeFill = true;
            // 
            // frmReportSanpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportSanpham";
            this.Text = "frmReportSanpham";
            this.Load += new System.EventHandler(this.frmReportSanpham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYBANHANGDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PROC_GETSANPHAMBYDATEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PROC_GETSANPHAMBYDATEBindingSource;
        private QUANLYBANHANGDataSet3 QUANLYBANHANGDataSet3;
        private QUANLYBANHANGDataSet3TableAdapters.PROC_GETSANPHAMBYDATETableAdapter PROC_GETSANPHAMBYDATETableAdapter;
    }
}