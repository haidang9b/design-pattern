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
    public partial class frmTaiChinh : Form
    {
        
        public frmTaiChinh()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmTaiChinh_Load(object sender, EventArgs e)
        {
            loadAllBill();
        }

        private void loadAllBill()
        {
            dataGridView2.DataSource = BillDAO.Instance.GetBills();
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Mã khách hàng";
            dataGridView2.Columns[2].HeaderText = "Tên nhân viên";
            dataGridView2.Columns[3].HeaderText = "Thời gian mua";
            dataGridView2.Columns[4].HeaderText = "Tổng tiền";

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string start = dptStart.Value.ToString("dd-MM-yyyy");
                string end = dptEnd.Value.ToString("dd-MM-yyyy");
                
                dataGridView2.DataSource = BillDAO.Instance.getAllBillViewByTime(start, end);
                txtMoney.Text = BillDAO.Instance.getMoneyByTime(start, end).ToString();
            }
            catch
            {
                MessageBox.Show("Thống kê thất bại");
            }
        }

        private void btnXuatSP_Click(object sender, EventArgs e)
        {
            try
            {
                Thread th = new Thread(() =>
               {
                   string tongtiendoanhthu = txtMoney.Text;
                   string start = dptStart.Value.ToString("dd-MM-yyyy");
                   string end = dptEnd.Value.ToString("dd-MM-yyyy");
                   if (tongtiendoanhthu == "")
                   {
                       MessageBox.Show("Phải thống kê mới có thể xuất file");

                   }
                   else
                   {
                       start = start.Replace("-", "");
                       end = end.Replace("-", "");
                       var fileName = "Thong ke tai chinh " + start + " " + end;
                       Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                       Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                       Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                       worksheet = workbook.Sheets["Sheet1"];
                       worksheet = workbook.ActiveSheet;
                       worksheet.Name = "TaiChinh" + start + end;

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
                   }
               });
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                
            }
            catch
            {
                MessageBox.Show("Thống kê thất bại");
            }
        }
    }
}
