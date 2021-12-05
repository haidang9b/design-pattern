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
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadListProduct();
            loadCatagoryList();
        }
        //load loai san pham va do vao list 
        private void loadCatagoryList()
        {
            List<ProductType> listCata = ProductTypeDAO.Instance.LoadAllProductType();
            comboBox1.DataSource = listCata;
            comboBox1.DisplayMember = "name";
        }

        public Product GetProductTextBox()
        {
            int id = 0;
            string name = txtName.Text;
            ProductType selected = comboBox1.SelectedItem as ProductType;
            int productType = selected.Id;
            int slt = 0;
            int price = 0;

            try
            {
                id = int.Parse(txtID.Text);
                slt = int.Parse(txtSLT.Text);
                price = int.Parse(txtDonGia.Text);
            }
            catch
            {
                id = 0;
                slt = 0;
                price = 0;
            }
            return new Product(id, name, productType, slt, price);

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            try
            {
                ProductType selected = comboBox1.SelectedItem as ProductType;
                int maloai = selected.Id;
                string name = txtName.Text;
                int slt = int.Parse(txtSLT.Text);
                int price = int.Parse(txtDonGia.Text);
                if(new ValidatorContext(txtName.Text, ValidatorType.String).runValidation() == false
                    && new ValidatorContext(txtSLT.Text, ValidatorType.PositiveNumber).runValidation() == false
                    && new ValidatorContext(txtDonGia.Text, ValidatorType.PositiveNumber).runValidation() == false)
                {
                    MessageBox.Show("Vui lòng điều đủ thông tin");
                }
                else
                {
                    IActionTemplate template = new AddProduct();
                    template.form = this;
                    template.runAction();
                }
            }
            catch
            {
                MessageBox.Show("Không thành công, vui lòng kiểm tra lại thông tin vừa nhập!!");
            }
            
            
        }
        public void LoadListProduct()
        {
            dgvSanPham.DataSource = ProductDAO.Instance.GetProducts();
        }

        ///xoa 

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(new ValidatorContext(txtID.Text, ValidatorType.ID).runValidation())
                {
                    IActionTemplate template = new RemoveProduct();
                    template.form = this;
                    template.runAction();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hợp lệ");
                }

            }
            catch
            {
                MessageBox.Show("Xóa phần mềm thành công !!");

            }
        }
        public void clearText()
        {
            txtDonGia.Text = "";
            txtName.Text = "";
            txtSLT.Text = "";
            btnThem.Enabled = true;
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = false;
            btnSearch.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearText();
        }
        //set event click cap nhat
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                ProductType selected = comboBox1.SelectedItem as ProductType;
                int maloai = selected.Id;
                int id =int.Parse( txtID.Text);
                String name = txtName.Text;
                int slt = int.Parse(txtSLT.Text);
                int price = int.Parse(txtDonGia.Text);

                if (new ValidatorContext(txtName.Text, ValidatorType.String).runValidation() == false
                    && new ValidatorContext(txtSLT.Text, ValidatorType.PositiveNumber).runValidation() == false
                    && new ValidatorContext(txtDonGia.Text, ValidatorType.PositiveNumber).runValidation() == false 
                    && new ValidatorContext(txtID.Text, ValidatorType.ID).runValidation() == false)
                {
                    MessageBox.Show("Vui lòng điền đủ thông tin !!");
                }
                else
                {
                    IActionTemplate template = new UpdateProduct();
                    template.form = this;
                    template.runAction();
                }
            }
            catch
            {
                MessageBox.Show("cập nhật sản phẩm thất bại!!");
            }
        }
        //click cell san pham
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = this.dgvSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = this.dgvSanPham.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox1.SelectedIndex = (int)this.dgvSanPham.Rows[e.RowIndex].Cells[2].Value;
                txtSLT.Text = this.dgvSanPham.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDonGia.Text = this.dgvSanPham.Rows[e.RowIndex].Cells[4].Value.ToString();
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
        // set event click search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                String name = txtName.Text;
                dgvSanPham.DataSource = ProductDAO.Instance.searchItem(name);
            }
            catch
            {
                MessageBox.Show("Tìm không được, kiểm tra lại");
            }
        }

       
    }
}
