using CuaHangPhanMem.DAO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem
{
    public partial class FormReportBill : Form
    {
        private int idBill;
        private string tenKHmua;
        private string tongtienMua;
        public FormReportBill(int id, string khmua, string ttmua)
        {
            idBill = id;
            tenKHmua = khmua;
            tongtienMua = ttmua;
            InitializeComponent();
        }

        private void FormReportBill_Load(object sender, EventArgs e)
        {
            string exeFolder = Application.StartupPath;
            string reportPath = Path.Combine(exeFolder, @"D:\Java\Design Pattern\CuoiKi\new\design-pattern\CuaHangPhanMem\Reports\Report1.rdlc");
            reportViewer1.LocalReport.ReportPath = @"D:\Java\Design Pattern\CuoiKi\new\design-pattern\CuaHangPhanMem\Reports\ReportBill.rdlc";
            string query = "SELECT TENSP as 'TenSP', SANPHAM.MASP as 'MaSP', SL as 'SoLuong', DONGIA 'DonGia' , (DONGIA*SL) AS 'ThanhTien'  FROM SANPHAM INNER JOIN CHITIETHOADON ON CHITIETHOADON.MASP = SANPHAM.MASP WHERE CHITIETHOADON.MAHD = @MAHD ";
            DataTable dtHoaDon = DataProvider.Instance.ExecuteQuery(query, new object[] {idBill });
            
            ReportDataSource rds = new ReportDataSource("DataSetBill", dtHoaDon);
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.SetParameters(new ReportParameter("TongTien", string.Format("{0:#,0.####}", Int32.Parse(tongtienMua))));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("TenKhachHang", tenKHmua));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("MaHoaDon", idBill.ToString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("ThoiGianMua", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")));

            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
