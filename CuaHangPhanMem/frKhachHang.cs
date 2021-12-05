using CuaHangPhanMem.DAO;
using CuaHangPhanMem.DTO;
using CuaHangPhanMem.Strategy;
using CuaHangPhanMem.Template;
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
    public partial class frKhachHang : Form
    {
        public frKhachHang()
        {
            InitializeComponent();
        }

        private void frKhachHang_Load(object sender, EventArgs e)
        {
            loadDatacustomer();
        }
        public void loadDatacustomer()
        {
            dgvKhachHang.DataSource = CustomerDAO.Instance.GetCustomers();
        }

        
        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
        // tao khach hang
        private void btnThem_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String sdt = txtSdt.Text;
            String dc = txtDiaChi.Text;

            if (new ValidatorContext(name, ValidatorType.String).runValidation() && new ValidatorContext(sdt, ValidatorType.Phone).runValidation() && new ValidatorContext(dc, ValidatorType.String).runValidation())
            {
                try
                {
                    IActionTemplate template = new AddCustomer();
                    template.form = this;
                    template.runAction();
                }
                catch
                {
                    MessageBox.Show("Thêm khách hàng thất bại!!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ");
            }


        }

        public Customer GetCustomerTextBox()
        {
            string name = txtName.Text;
            string sdt = txtSdt.Text;
            string dc = txtDiaChi.Text;
            int tongtien = 0;
            int id = 0;
                
            try
            {
                id = int.Parse(txtID.Text);
                tongtien = int.Parse(txtTien.Text);
            }
            catch
            {
                id = 0;
                tongtien = 0;
            }

            return new Customer(id, name, sdt, dc, tongtien);
        }
        //clear text box
        public void clearText()
        {
            txtName.Text = "";
            txtID.Text = "";
            txtDiaChi.Text = "";
            txtSdt.Text = "";
            txtTien.Text = "";
            btnThem.Enabled = true;
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearText();
        }
        //click cell vao khach hang
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtName.Text = this.dgvKhachHang.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtID.Text = this.dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDiaChi.Text = this.dgvKhachHang.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSdt.Text = this.dgvKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTien.Text = this.dgvKhachHang.Rows[e.RowIndex].Cells[4].Value.ToString();
                btnThem.Enabled = false;
                btnClear.Enabled = true;
                btnXoa.Enabled = true;
                btnCapNhat.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn dòng hợp lệ");
            }
        }
        //xoa kh
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(new ValidatorContext(txtID.Text, ValidatorType.ID).runValidation())
                {
                    IActionTemplate template = new RemoveCustomer();
                    template.form = this;
                    template.runAction();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khách hàng hợp lệ!!");
                }
            }
            catch
            {
                MessageBox.Show("Xóa khách hàng này thất bại, vui lòng chọn khách hàng hợp lệ!!");
            }
        }
        // cap nhat khach hang
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                string address = txtDiaChi.Text;
                string name = txtName.Text;
                string sdt = txtSdt.Text;
                if (new ValidatorContext(name, ValidatorType.String).runValidation() 
                    && new ValidatorContext(sdt, ValidatorType.Phone).runValidation()
                    && new ValidatorContext(address, ValidatorType.String).runValidation()
                    && new ValidatorContext(txtID.Text, ValidatorType.ID).runValidation())
                {
                    
                    IActionTemplate template = new UpdateCustomer();
                    template.form = this;
                    template.runAction();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin khách hàng hợp lệ");
                }

            }
            catch
            {
                MessageBox.Show("Cập nhật khách hàng thất bại !!");
            }
        }
    }
}
