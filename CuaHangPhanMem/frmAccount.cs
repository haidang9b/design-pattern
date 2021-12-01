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
        private void LoadAllAccount()
        {
            dataGridView1.DataSource = AccountDAO.Instance.loadAllAccount();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            string slect = cbRole.SelectedIndex.ToString();
            
            if(username.Length >0 && password.Length >0 && slect.Length>0)
            {
                int role = int.Parse(cbRole.SelectedIndex.ToString());
                try
                {
                    if(role == 0)
                    {
                        bool res = AccountDAO.Instance.InsertAdmin(username, password);
                        if (res)
                        {
                            MessageBox.Show("Thêm tài khoản Admin thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thêm tài khoản Admin thất bại");
                        }
                    }
                    else if(role == 1)
                    {
                        bool res = AccountDAO.Instance.InsertStaff(username, password);
                        if (res)
                        {
                            MessageBox.Show("Thêm tài khoản Staff thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thêm tài khoản Staff thất bại");
                        }
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
            LoadAllAccount();
            clearText();

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

        private void clearText()
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
            int id = int.Parse(txtID.Text);
            string username = txtUser.Text;
            string password = txtPass.Text;
            string slect = cbRole.SelectedIndex.ToString();

            if (username.Length > 0 && password.Length > 0 && slect.Length > 0)
            {
                int role = int.Parse(cbRole.SelectedIndex.ToString());
                try
                {
                    if (role < 2)
                    {
                        bool res = AccountDAO.Instance.UpdateUser(id, password,role);
                        if (res)
                        {
                            MessageBox.Show("Cập nhật mật khẩu thành công");
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật mật khẩu thất bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn hợp lệ ");
                    }
                    LoadAllAccount();
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
            LoadAllAccount();
            clearText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                if (AccountDAO.Instance.DeleteAccount(id))
                {
                    MessageBox.Show("Xóa tài khoản thành công !!");
                    LoadAllAccount();
                    clearText();
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản này thất bại!");
                }
            }
            catch
            {
                MessageBox.Show("Xóa tài khoản này thất bại!");
            }
        }
    }
}
