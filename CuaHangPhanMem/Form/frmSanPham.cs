using CuaHangPhanMem.Command;
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
        ActionRemoteControl remote;

        /*Start command enable disable*/
        RemoteCommandControl enableCommandAddSearch;
        RemoteCommandControl disableCommandAddSearch;
        RemoteCommandControl enableCommandRemoveUpdate;
        RemoteCommandControl disableCommandRemoveUpdate;
        /*End command enable disable*/

        public frmSanPham()
        {
            InitializeComponent();
            remote = new ActionRemoteControl();
            ICommandAction add = new ProductAddCommand(this);
            ICommandAction update = new ProductUpdateCommand(this);
            ICommandAction remove = new ProductRemoveCommand(this);
            remote.SetCommandAction((int)TypeAction.Add, add);
            remote.SetCommandAction((int)TypeAction.Remove, remove);
            remote.SetCommandAction((int)TypeAction.Update, update);

            enableCommandAddSearch = new RemoteCommandControl(new EnableCommand(btnThem), new EnableCommand(btnSearch));
            disableCommandAddSearch = new RemoteCommandControl(new DisableCommand(btnThem), new DisableCommand(btnSearch));

            enableCommandRemoveUpdate = new RemoteCommandControl(new EnableCommand(btnXoa), new EnableCommand(btnCapNhat));
            disableCommandRemoveUpdate = new RemoteCommandControl(new DisableCommand(btnXoa), new DisableCommand(btnCapNhat));
        }
        
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            
            LoadListProduct();
            loadCatagoryList();
            clearText();
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
            if(txtID.Text.Length > 0)
            {
                id = int.Parse(txtID.Text);
            }
            try
            {
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
                    MessageBox.Show("Vui lòng điều đủ thông tin hợp lệ");
                }
                else
                {
                    remote.buttonWasPressed((int)TypeAction.Add);
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
            dgvSanPham.Columns[0].HeaderText = "ID";
            dgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns[2].HeaderText = "Loại";
            dgvSanPham.Columns[3].HeaderText = "Số lượng";
            dgvSanPham.Columns[4].HeaderText = "Giá bán";

            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.Columns[0].Width = 30;
            dgvSanPham.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        ///xoa 

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(new ValidatorContext(txtID.Text, ValidatorType.ID).runValidation())
                {
                    /*IActionTemplate template = new RemoveProduct();
                    template.form = this;
                    template.runAction();*/
                    remote.buttonWasPressed((int)TypeAction.Remove);
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
            txtID.Text = "";
            txtDonGia.Text = "";
            txtName.Text = "";
            txtSLT.Text = "";

            enableCommandAddSearch.run();
            disableCommandRemoveUpdate.run();
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

                if (new ValidatorContext(txtName.Text, ValidatorType.String).runValidation()
                    && new ValidatorContext(txtSLT.Text, ValidatorType.PositiveNumber).runValidation()
                    && new ValidatorContext(txtDonGia.Text, ValidatorType.PositiveNumber).runValidation()
                    && new ValidatorContext(txtID.Text, ValidatorType.ID).runValidation())
                {
                    remote.buttonWasPressed((int)TypeAction.Update);
                }
                else
                {
                    /*IActionTemplate template = new UpdateProduct();
                    template.form = this;
                    template.runAction();*/
                    
                    MessageBox.Show("Vui lòng điền đủ thông tin hợp lệ!!");
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

                disableCommandAddSearch.run();
                enableCommandRemoveUpdate.run();
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
