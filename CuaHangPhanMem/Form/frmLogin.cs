using CuaHangPhanMem.Command;
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
        LoginCommand commandLogin;
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

            commandLogin = new LoginForm();
            commandLogin.Login(tk, mk);
            if (commandLogin.isLogin)
            {
                this.Hide();
            }
            else
            {
                msgError.Text = "Invalid username or password";
                msgError.Show();
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
