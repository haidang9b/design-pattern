using CuaHangPhanMem.Adapter;
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
    public partial class frKhachHang : Form
    {
        ActionRemoteControl remote;

        /*Start command enable disable*/
        RemoteCommandControl enableCommandAdd;
        RemoteCommandControl disableCommandAdd;
        RemoteCommandControl enableCommandRemoveUpdate;
        RemoteCommandControl disableCommandRemoveUpdate;
        /*End command enable disable*/
        public frKhachHang()
        {
            InitializeComponent();
            remote = new ActionRemoteControl();
            
            ICommandAction add = new CustomerAddCommand(this);
            ICommandAction update = new CustomerUpdateCommand(this);
            ICommandAction remove = new CustomerRemoveCommand(this);
            
            remote.SetCommandAction((int)TypeAction.Add, add);
            remote.SetCommandAction((int)TypeAction.Remove, remove);
            remote.SetCommandAction((int)TypeAction.Update, update);

            enableCommandAdd = new RemoteCommandControl(new EnableCommand(btnThem));
            disableCommandAdd = new RemoteCommandControl(new DisableCommand(btnThem));
            enableCommandRemoveUpdate = new RemoteCommandControl( new EnableCommand(btnXoa), new EnableCommand(btnCapNhat));
            disableCommandRemoveUpdate = new RemoteCommandControl(new DisableCommand(btnXoa), new DisableCommand(btnCapNhat));
        }

        private void frKhachHang_Load(object sender, EventArgs e)
        {
            LoadDataCustomer();
            clearText();
        }
        public void LoadDataCustomer()
        {
            /*dgvKhachHang = new CustomerCustomDataGridView();*/
            dgvKhachHang.DataSource = CustomerDAO.Instance.GetCustomers();
            dgvKhachHang.Columns[0].HeaderText = "ID";
            dgvKhachHang.Columns[1].HeaderText = "Họ và tên";
            dgvKhachHang.Columns[2].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns[3].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[4].HeaderText = "Tổng tiền";
            dgvKhachHang.Columns[5].HeaderText = "Email";

            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.Columns[0].Width = 30;
            dgvKhachHang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                    remote.buttonWasPressed((int)TypeAction.Add);
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
            string email = txtEmail.Text;
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

            return new Customer(id, name, sdt, dc, tongtien, email);
        }
        //clear text box
        public void clearText()
        {
            txtName.Text = "";
            txtID.Text = "";
            txtDiaChi.Text = "";
            txtSdt.Text = "";
            txtTien.Text = "";
            txtEmail.Text = "";

            enableCommandAdd.run();
            disableCommandRemoveUpdate.run();
            /*btnThem.Enabled = true;
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = false;*/
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
                txtEmail.Text = this.dgvKhachHang.Rows[e.RowIndex].Cells[5].Value.ToString();
                disableCommandAdd.run();
                enableCommandRemoveUpdate.run();
/*                btnThem.Enabled = false;
                btnClear.Enabled = true;
                btnXoa.Enabled = true;
                btnCapNhat.Enabled = true;*/
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
                    remote.buttonWasPressed((int)TypeAction.Remove);
                    /*IActionTemplate template = new RemoveCustomer();
                    template.form = this;
                    template.runAction();*/
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
                    remote.buttonWasPressed((int)TypeAction.Update);
                    /*IActionTemplate template = new UpdateCustomer();
                    template.form = this;
                    template.runAction();*/
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

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
