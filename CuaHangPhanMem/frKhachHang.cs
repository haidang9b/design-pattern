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
        private void loadDatacustomer()
        {
            dgvKhachHang.DataSource = CustomerDAO.Instance.LoadAllCustomer();
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

            if (name.Length > 0 || sdt.Length >0 || dc.Length>0)
            {
                try
                {
                    if (CustomerDAO.Instance.InsertCustomer(name,sdt,dc))
                    {
                        MessageBox.Show("Thêm khách hàng thành công !!");
                        loadDatacustomer();
                        clearText();
                    }
                    else
                    {
                        MessageBox.Show("Thêm khách hàng mềm thất bại!!");
                    }
                }
                catch
                {
                    MessageBox.Show("Thêm khách hàng thất bại!!");
                }
                btnThem.Enabled = true;
                btnClear.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin");
            }


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
            loadDatacustomer();
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
                int id = int.Parse(txtID.Text);
                if (CustomerDAO.Instance.DeleteCustomer(id))
                {
                    MessageBox.Show("Xóa khách hàng thành công !!");
                    loadDatacustomer();
                    clearText();
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng này thất bại, vui lòng chọn khách hàng hợp lệ!!");
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
                if (name.Length < 1 || address.Length<1 || sdt.Length<1)
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng");
                }
                else
                {
                    if (CustomerDAO.Instance.UpdateCustomer(id, name,sdt,address))
                    {
                        
                        loadDatacustomer();
                        MessageBox.Show("Cập nhật khách hàng thành công !!");
                        clearText();

                    }
                    else
                    {
                        MessageBox.Show("Cập nhật khách hàng thất bại !!");
                    }
                }

            }
            catch
            {
                MessageBox.Show("Cập nhật khách hàng thất bại !!");
            }
        }
    }
}
