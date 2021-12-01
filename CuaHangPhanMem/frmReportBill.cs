using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            
            // TODO: This line of code loads data into the 'QUANLYBANHANGDataSet1.PROC_GETBILLINFO' table. You can move, or remove it, as needed.
            this.PROC_GETBILLINFOTableAdapter.Fill(this.QUANLYBANHANGDataSet1.PROC_GETBILLINFO,idBill);
            Microsoft.Reporting.WinForms.ReportParameter[] reportParameters = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("TenKHmua",tenKHmua),
                new Microsoft.Reporting.WinForms.ReportParameter("maHDmua",idBill.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("ttDaMua",string.Format("{0:#,0.####}",Int32.Parse(tongtienMua))),
                new Microsoft.Reporting.WinForms.ReportParameter("ngaybanhang",DateTime.Now.ToString())


            };
            reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
