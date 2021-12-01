using CuaHangPhanMem.DAO;
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
            dataGridView2.DataSource = BillDAO.Instance.loadAllBill();

            
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
                
                string tongtiendoanhthu = txtMoney.Text;
                string start = dptStart.Value.ToString("dd-MM-yyyy");
                string end = dptEnd.Value.ToString("dd-MM-yyyy");
                if (tongtiendoanhthu == "")
                {
                    MessageBox.Show("Phải thống kê mới có thể xuất file");

                }
                else
                {
                    frmReportDoanhthu reportDoanhthu = new frmReportDoanhthu(start, end, tongtiendoanhthu);
                    reportDoanhthu.Show();
                }
            }
            catch
            {
                MessageBox.Show("Thống kê thất bại");
            }
        }
    }
}
