using CuaHangPhanMem.DAO;
using CuaHangPhanMem.DTO;
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
    public partial class frmLoaiSP : Form
    {
        public frmLoaiSP()
        {
            InitializeComponent();
        }

        private void frmLoaiSP_Load(object sender, EventArgs e)
        {
            loadProductType();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            if(name.Length > 0)
            {
                try
                {
                    if (ProductTypeDAO.Instance.InsertProductType(name))
                    {
                        MessageBox.Show("Thêm loại phần mềm thành công !!");
                        loadProductType();
                        clearText();
                    }
                    else
                    {
                        MessageBox.Show("Thêm loại phần mềm thất bại!!");
                    }
                }
                catch
                {
                    MessageBox.Show("Thêm loại phần mềm thất bại!!");
                }
                btnThem.Enabled = true;
                btnClear.Enabled = true;
                btnXoa.Enabled = true;
                btnSearch.Enabled = false;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin");
            }
            

        }
        private void loadProductType()
        {
            dgvLoaiSanPham.DataSource = ProductTypeDAO.Instance.LoadAllProductType();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            try
            {
                int id = int.Parse(txtID.Text);
                if (ProductTypeDAO.Instance.DeleteProductType(id))
                {
                    MessageBox.Show("Xóa loại phần mềm thành công !!");
                    loadProductType();
                    clearText();
                }
                else
                {
                    MessageBox.Show("Xóa loại phần mềm thất bại !!");
                }
            }
            catch
            {
                MessageBox.Show("Xóa loại phần mềm thất bại , do loại sản phẩm này đang chứa sản phẩm!!");
            }
            
        }

        private void dgvLoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtName.Text = this.dgvLoaiSanPham.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtID.Text = this.dgvLoaiSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                btnThem.Enabled = false;
                btnClear.Enabled = true;
                btnXoa.Enabled = true;
                btnSearch.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn dòng hợp lệ");
            }
            
        }
        private void clearText()
        {
            txtName.Text = "";
            txtID.Text = "";
            btnThem.Enabled = true;
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = false;
            btnSearch.Enabled = true;
            loadProductType();

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                string name = txtName.Text;
                if(name.Length < 1)
                {
                    MessageBox.Show("Vui lòng nhập tên loại phần mềm");
                }
                else
                {
                    if (ProductTypeDAO.Instance.UpdateProductType(id, name))
                    {
                        clearText();
                        loadProductType();
                        MessageBox.Show("Cập nhật loại phần mềm thành công !!");

                    }
                    else
                    {
                        MessageBox.Show("Cập nhật loại phần mềm thất bại !!");
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("Cập nhật loại phần mềm thất bại !!");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvLoaiSanPham.DataSource = ProductTypeDAO.Instance.searchItem(txtName.Text);
        }
    }
}
