using CuaHangPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem
{
    public partial class frmThongKeSP : Form
    {
        private bool isRun = false;
        public frmThongKeSP()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                isRun = true;
                string start = dptStart.Value.ToString("dd-MM-yyyy");
                string end = dptEnd.Value.ToString("dd-MM-yyyy");
                MessageBox.Show("bắt đầu:" + start + " kết thúc" + end);

                dataGridView2.DataSource = ProductDAO.Instance.loadAllProductRankingByTime(start, end);
            }
            catch
            {
                MessageBox.Show("Thống kê thất bại");
            }
        }

        private void frmThongKeSP_Load(object sender, EventArgs e)
        {
            LoadDataTKSP();
        }

        private void LoadDataTKSP()
        {
            dataGridView2.DataSource = ProductDAO.Instance.loadAllProductRanking();
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridView2.Columns[2].HeaderText = "Số lượng";
            dataGridView2.Columns[3].HeaderText = "Đơn giá";
            dataGridView2.Columns[4].HeaderText = "Tổng tiền";

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnXuatFILE_Click(object sender, EventArgs e)
        {
            try
            {
                if(isRun == false)
                {
                    MessageBox.Show("Vui lòng thống kê sản phẩm trước khi xuất file");
                    return;
                }
                Thread th = new Thread(() =>
                {
                    string start = dptStart.Value.ToString("dd-MM-yyyy");
                    start = start.Replace("-", "");
                    string end = dptEnd.Value.ToString("dd-MM-yyyy");
                    end = end.Replace("-", "");
                    var fileName = "Thong ke phan mem " + start + " " + end;
                    /*Form re = new frmReportSanpham(start, end);
                    re.Show();*/
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = "PhanMem" + start + end;

                    for (int i = 1; i < dataGridView2.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = dataGridView2.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView2.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    var saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = fileName;
                    saveFileDialog.DefaultExt = ".xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }
                });
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                

            }
            catch
            {

            }
            
        }
    }
}
