
namespace CuaHangPhanMem
{
    partial class frmReportDoanhthu
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
            this.QUANLYBANHANGDataSet = new CuaHangPhanMem.QUANLYBANHANGDataSet();
            this.PROC_GETDOANHTHUBYDATEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PROC_GETDOANHTHUBYDATETableAdapter = new CuaHangPhanMem.QUANLYBANHANGDataSetTableAdapters.PROC_GETDOANHTHUBYDATETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYBANHANGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PROC_GETDOANHTHUBYDATEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DatasetDoanhthu";
            reportDataSource1.Value = this.PROC_GETDOANHTHUBYDATEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CuaHangPhanMem.ReportDoanhthu.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // QUANLYBANHANGDataSet
            // 
            this.QUANLYBANHANGDataSet.DataSetName = "QUANLYBANHANGDataSet";
            this.QUANLYBANHANGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PROC_GETDOANHTHUBYDATEBindingSource
            // 
            this.PROC_GETDOANHTHUBYDATEBindingSource.DataMember = "PROC_GETDOANHTHUBYDATE";
            this.PROC_GETDOANHTHUBYDATEBindingSource.DataSource = this.QUANLYBANHANGDataSet;
            // 
            // PROC_GETDOANHTHUBYDATETableAdapter
            // 
            this.PROC_GETDOANHTHUBYDATETableAdapter.ClearBeforeFill = true;
            // 
            // frmReportDoanhthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportDoanhthu";
            this.Text = "frmReportDoanhthu";
            this.Load += new System.EventHandler(this.frmReportDoanhthu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYBANHANGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PROC_GETDOANHTHUBYDATEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PROC_GETDOANHTHUBYDATEBindingSource;
        private QUANLYBANHANGDataSet QUANLYBANHANGDataSet;
        private QUANLYBANHANGDataSetTableAdapters.PROC_GETDOANHTHUBYDATETableAdapter PROC_GETDOANHTHUBYDATETableAdapter;
    }
}