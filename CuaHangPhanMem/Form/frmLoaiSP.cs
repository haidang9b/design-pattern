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
    public partial class frmLoaiSP : Form
    {
        ActionRemoteControl remote;

        /*Start command enable disable*/
        RemoteCommandControl enableCommandAddSearch;
        RemoteCommandControl disableCommandAddSearch;
        RemoteCommandControl enableCommandRemoveUpdate;
        RemoteCommandControl disableCommandRemoveUpdate;
        /*End command enable disable*/

        public frmLoaiSP()
        {
            InitializeComponent();

            remote = new ActionRemoteControl();
            ICommandAction add = new ProductTypeAddCommand(this);
            ICommandAction update = new ProductTypeUpdateCommand(this);
            ICommandAction remove = new ProductTypeRemoveCommand(this);
            remote.SetCommandAction((int)TypeAction.Add, add);
            remote.SetCommandAction((int)TypeAction.Remove, remove);
            remote.SetCommandAction((int)TypeAction.Update, update);

            enableCommandAddSearch = new RemoteCommandControl(new EnableCommand(btnThem), new EnableCommand(btnSearch));
            disableCommandAddSearch = new RemoteCommandControl(new DisableCommand(btnThem), new DisableCommand(btnSearch));

            enableCommandRemoveUpdate = new RemoteCommandControl(new EnableCommand(btnXoa), new EnableCommand(btnCapNhat));
            disableCommandRemoveUpdate = new RemoteCommandControl(new DisableCommand(btnXoa), new DisableCommand(btnCapNhat));
        }

        private void frmLoaiSP_Load(object sender, EventArgs e)
        {
            loadProductType();
            clearText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            if(new ValidatorContext(name, ValidatorType.String).runValidation())
            {
                /* IActionTemplate template = new AddProductType();
                 template.form = this;
                 template.runAction();*/

                remote.buttonWasPressed((int)TypeAction.Add);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ");
            }
            

        }

        public ProductType GetProductTypeTextBox()
        {
            string name = txtName.Text;
            int id = 0;
            try {
                id = int.Parse(txtID.Text);
            }
            catch
            {
                id = 0;
            }
            return new ProductType(id, name);
        }
        public void loadProductType()
        {
            dgvLoaiSanPham.DataSource = ProductTypeDAO.Instance.LoadAllProductType();
            dgvLoaiSanPham.Columns[0].HeaderText = "ID";
            dgvLoaiSanPham.Columns[1].HeaderText = "Tên Loại";

            dgvLoaiSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoaiSanPham.Columns[0].Width = 100;
            dgvLoaiSanPham.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLoaiSanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                if( new ValidatorContext(txtID.Text , ValidatorType.ID).runValidation() == false)
                {
                    MessageBox.Show("Vui lòng chọn loại phần mềm cần xóa");
                    return;
                }

                /* IActionTemplate template = new RemoveProductType();
                 template.form = this;
                 template.runAction();*/
                remote.buttonWasPressed((int)TypeAction.Remove);
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

                disableCommandAddSearch.run();
                enableCommandRemoveUpdate.run();

            }
            catch
            {
                MessageBox.Show("Vui lòng chọn dòng hợp lệ");
            }
            
        }
        public void clearText()
        {
            txtName.Text = "";
            txtID.Text = "";

            enableCommandAddSearch.run();
            disableCommandRemoveUpdate.run();

            /*btnThem.Enabled = true;
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = false;
            btnSearch.Enabled = true;*/
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                string name = txtName.Text;
                if(new ValidatorContext(txtID.Text, ValidatorType.ID).runValidation() == false)
                {
                    MessageBox.Show("Vui lòng chọn loại phần mềm");
                }
                else if(new ValidatorContext(name, ValidatorType.String).runValidation() == false)
                {
                    MessageBox.Show("Vui lòng nhập tên loại phần mềm");
                }
                else
                {
                    /*IActionTemplate template = new UpdateProductType();
                    template.form = this;
                    template.runAction();*/
                    remote.buttonWasPressed((int)TypeAction.Update);
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
