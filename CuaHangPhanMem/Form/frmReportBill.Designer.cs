
namespace CuaHangPhanMem
{
    partial class frmReportBill
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewerHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerHoaDon
            // 
            this.reportViewerHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.reportViewerHoaDon.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerHoaDon.LocalReport.ReportEmbeddedResource = "CuaHangPhanMem.Report2.rdlc";
            this.reportViewerHoaDon.Location = new System.Drawing.Point(0, 0);
            this.reportViewerHoaDon.Name = "reportViewerHoaDon";
            this.reportViewerHoaDon.ServerReport.BearerToken = null;
            this.reportViewerHoaDon.Size = new System.Drawing.Size(800, 450);
            this.reportViewerHoaDon.TabIndex = 0;
            this.reportViewerHoaDon.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // frmReportBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerHoaDon);
            this.Name = "frmReportBill";
            this.Text = "frmReportBill";
            this.Load += new System.EventHandler(this.frmReportBill_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerHoaDon;
    }
}