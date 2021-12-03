using CuaHangPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CuaHangPhanMem
{
    public partial class LOGIN : Form
    {
            
        public LOGIN()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String mk = txtPassword.Text;
            String tk = txtUsername.Text;          

            if(comboBox1.SelectedIndex == 0)
            {
                SaveDataStatic.typeServer = 1;
            }
            else
            {
                SaveDataStatic.typeServer = 2;
            }
            if (AccountDAO.Instance.LoginAdmin(tk,mk))
            {
                Form frm = FactoryLogin.Instance.CreateLogin(LoginType.Admin, tk);
                frm.Show();
                this.Hide();
            }
            else if(AccountDAO.Instance.LoginStaff(tk, mk))
            {
                
                Form banHangStaff = FactoryLogin.Instance.CreateLogin(LoginType.User, tk);
                banHangStaff.Show();
                this.Hide();
            }
            else
            {
                
                if(tk.Length == 0 && mk.Length == 0)
                {
                    msgError.Text = "Please enter your username and password " ;
                    msgError.Show();
                }

                else if (tk.Length == 0) {
                    msgError.Text = "Please enter your username";
                    msgError.Show();
                }
                else if (mk.Length == 0)
                {
                    msgError.Text = "Please enter your password";
                    msgError.Show();
                }
                else
                {
                    msgError.Text = "Invalid username or password";
                    msgError.Show();
                }
            }
     
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                Properties.Settings.Default.userName = txtUsername.Text;
                Properties.Settings.Default.passUser = txtPassword.Text;
                Properties.Settings.Default.Save();
            }
            if (cbShowPassword.Checked == false)
            {
                Properties.Settings.Default.userName = "";
                Properties.Settings.Default.passUser = ""; 
                Properties.Settings.Default.Save();
            }

        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.userName != string.Empty)
            {
                txtUsername.Text = Properties.Settings.Default.userName;
                txtPassword.Text = Properties.Settings.Default.passUser;
                cbShowPassword.Checked = true;
            }
            comboBox1.SelectedIndex = 0;
        }
    }
}
