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
    public partial class frmAccount : Form
    {
        public frmAccount()
        {
            InitializeComponent();
        }

       

        private void frmAccount_Load(object sender, EventArgs e)
        {
            LoadAllAccount();
        }
        public void LoadAllAccount()
        {
            dataGridView1.DataSource = AccountDAO.Instance.GetAccounts();
        }

        public Account GetAccountTextBox()
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            int ID = 0;
            int role = 1;

            try
            {
                ID = int.Parse(txtID.Text);
                role = int.Parse(cbRole.SelectedIndex.ToString());
            }
            catch
            {
                ID = 0;
                role = 1;
            }

            return new Account(ID, username, password, role);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            string slect = cbRole.SelectedIndex.ToString();
            
            if(new ValidatorContext(username, ValidatorType.String).runValidation() 
                && new ValidatorContext(password, ValidatorType.String).runValidation() 
                && new ValidatorContext(slect, ValidatorType.ID).runValidation())
            {
                int role = int.Parse(cbRole.SelectedIndex.ToString());
                try
                {
                    if(role == 0 || role == 1)
                    {
                        IActionTemplate template = new AddAccount();
                        template.form = this;
                        template.runAction();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn hợp lệ ");
                    }
                }
                catch
                {
                    MessageBox.Show("Có vẻ tài khoản này đã tồn tại trong hệ thống");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtUser.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPass.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                cbRole.SelectedIndex = int.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                btnThem.Enabled = false;
                btnClear.Enabled = true;
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                txtUser.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn dòng hợp lệ");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearText();
        }

        public void clearText()
        {
            txtID.Text = "";
            txtPass.Text = "";
            txtUser.Text = "";
            cbRole.SelectedItem = null;
            btnCapNhat.Enabled = false;
            btnThem.Enabled = true;
            btnClear.Enabled = true;
            btnXoa.Enabled = false;
            txtUser.Enabled = true;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            
            string username = txtUser.Text;
            string password = txtPass.Text;
            string slect = cbRole.SelectedIndex.ToString();

            if (new ValidatorContext(username, ValidatorType.String).runValidation()
                && new ValidatorContext(password, ValidatorType.String).runValidation()
                && new ValidatorContext(slect, ValidatorType.ID).runValidation())
            {
                int role = int.Parse(cbRole.SelectedIndex.ToString());
                try
                {
                    if (role < 2)
                    {
                        IActionTemplate template = new UpdateAccount();
                        template.form = this;
                        template.runAction();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn hợp lệ ");
                    }
                    
                }
                catch
                {
                    MessageBox.Show("Có vẻ tài khoản này đã tồn tại trong hệ thống");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                if(new ValidatorContext(txtID.Text, ValidatorType.ID).runValidation())
                {
                    IActionTemplate template = new RemoveAccount();
                    template.form = this;
                    template.runAction();
                }
            }
            catch
            {
                MessageBox.Show("Xóa tài khoản này thất bại!");
            }
        }
    }
}
