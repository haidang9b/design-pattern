using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem
{
    public partial class frmReportBill : Form
    {
        private int idBill;
        private string tenKHmua;
        private string tongtienMua;
        public frmReportBill(int id, string khmua, string ttmua)
        {

            idBill = id;
            tenKHmua = khmua;
            tongtienMua = ttmua;
            InitializeComponent();
        }
        private void frmReportBill_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter[] reportParameters = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("TenKHmua",tenKHmua),
                new Microsoft.Reporting.WinForms.ReportParameter("ttDaMua",string.Format("{0:#,0.####}",Int32.Parse(tongtienMua))),
                new Microsoft.Reporting.WinForms.ReportParameter("ngaybanhang",DateTime.Now.ToString())
            };
           
            reportViewerHoaDon.LocalReport.SetParameters(reportParameters);
            this.reportViewerHoaDon.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
