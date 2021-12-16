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
    public partial class frmTimKiemDonHang : Form
    {
        public frmTimKiemDonHang()
        {
            InitializeComponent();
        }

        private void frmTimKiemDonHang_Load(object sender, EventArgs e)
        {
            loadAllListBill();
        }

        //load tat ca cac bill
        private void loadAllListBill()
        {
            dgvDonHang.DataSource = BillDAO.Instance.getAllBillView();
            dgvDonHang.Columns[0].HeaderText = "ID";
            dgvDonHang.Columns[1].HeaderText = "Họ và Tên";
            dgvDonHang.Columns[2].HeaderText = "Số điện thoại";
            dgvDonHang.Columns[3].HeaderText = "Ngày đặt";
            dgvDonHang.Columns[4].HeaderText = "Tổng tiền";
            dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDonHang.Columns[0].Width = 30;
            dgvDonHang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDonHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void dgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = this.dgvDonHang.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = this.dgvDonHang.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSDT.Text = this.dgvDonHang.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtMoney.Text = this.dgvDonHang.Rows[e.RowIndex].Cells[4].Value.ToString();
                LoadRightTable(int.Parse(txtID.Text));
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn hợp lệ");
            }
        }
        //load right table
        public void LoadRightTable(int id)
        {
            dgvCTDH.DataSource = BillDAO.Instance.loadAllBillViewByIDHD(id);
            dgvCTDH.Columns[0].HeaderText = "Tên phần mềm";
            dgvCTDH.Columns[1].HeaderText = "Giá bán";
            dgvCTDH.Columns[2].HeaderText = "Số lượng";
            dgvCTDH.Columns[3].HeaderText = "Tổng tiền";
            dgvCTDH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCTDH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCTDH.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        //click search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text;
            try
            {
                dgvDonHang.DataSource = BillDAO.Instance.getAllBillViewBySDT(sdt);
            }
            catch
            {
                MessageBox.Show("Tìm không thấy");
            }
        }
        //clear cac textbox
        private void btnClear_Click(object sender, EventArgs e)
        {
            loadAllListBill();
            txtID.Text = "";
            txtMoney.Text = "";
            txtName.Text = "";
            txtSDT.Text = "";
        }
    }
}
