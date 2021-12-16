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
    public partial class frmReportDoanhthu : Form
    {
        string start;
        string end;
        string tongtien;
        public frmReportDoanhthu(string start, string end, string tongtien)
        {
            
            this.start = start;
            this.end = end;
            this.tongtien = tongtien;
            InitializeComponent();
        }

        private void frmReportDoanhthu_Load(object sender, EventArgs e)
        {
            Console.WriteLine(start, end);
            DateTime dateStart = DateTime.ParseExact(start, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime dateEnd = DateTime.ParseExact(end, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            // TODO: This line of code loads data into the 'QUANLYBANHANGDataSet.PROC_GETDOANHTHUBYDATE' table. You can move, or remove it, as needed.
            this.PROC_GETDOANHTHUBYDATETableAdapter.Fill(this.QUANLYBANHANGDataSet.PROC_GETDOANHTHUBYDATE,dateStart,dateEnd);
            Microsoft.Reporting.WinForms.ReportParameter[] reportParameters = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("tongdoanhthu",string.Format("{0:#,0.####}",Int32.Parse(tongtien))),
                new Microsoft.Reporting.WinForms.ReportParameter("tgStart",start),
                new Microsoft.Reporting.WinForms.ReportParameter("tgEnd",end),
                new Microsoft.Reporting.WinForms.ReportParameter("ngayXuat",DateTime.Now.ToString())
            };
            reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
