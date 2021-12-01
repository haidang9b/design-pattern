using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem
{
    public partial class frmReportSanpham : Form
    {
        string start;
        string end;
        public frmReportSanpham(string start, string end)
        {
            this.start = start;
            this.end = end;
            InitializeComponent();
        }

        private void frmReportSanpham_Load(object sender, EventArgs e)
        {

                DateTime dateStart = DateTime.ParseExact(start, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                 DateTime dateEnd = DateTime.ParseExact(end, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            string timexuat = DateTime.Now.ToString();
                // TODO: This line of code loads data into the 'QUANLYBANHANGDataSet3.PROC_GETSANPHAMBYDATE' table. You can move, or remove it, as needed.
                this.PROC_GETSANPHAMBYDATETableAdapter.Fill(this.QUANLYBANHANGDataSet3.PROC_GETSANPHAMBYDATE, dateStart, dateEnd);
                Microsoft.Reporting.WinForms.ReportParameter[] reportParameters = new Microsoft.Reporting.WinForms.ReportParameter[]
               {
                new Microsoft.Reporting.WinForms.ReportParameter("tgStart",start),
                new Microsoft.Reporting.WinForms.ReportParameter("tgEnd",end),
                new Microsoft.Reporting.WinForms.ReportParameter("ngayXuat",DateTime.Now.ToString())
               };
                reportViewer1.LocalReport.SetParameters(reportParameters);
                this.reportViewer1.RefreshReport();
        }
    }
}
