using CuaHangPhanMem.DAO;
using CuaHangPhanMem.DTO;
using CuaHangPhanMem.Observer;
using CuaHangPhanMem.Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem
{
    public partial class frmNotifyEmail : Form
    {
        public frmNotifyEmail()
        {
            InitializeComponent();
            openFileDialogEmail.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

        }
        private void clearText() {
            txtContent.Text = "";
            txtTitle.Text = "";
            txtDinhKem.Text = "";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if(openFileDialogEmail.ShowDialog() == DialogResult.OK)
            {
                txtDinhKem.Text = openFileDialogEmail.FileName;
            }
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            try
            {
                if(new ValidatorContext(txtTitle.Text, ValidatorType.String).runValidation() 
                    && new ValidatorContext(txtContent.Text, ValidatorType.String).runValidation())
                {
                    EmailData data = new EmailData();
                    data.content = txtContent.Text;
                    data.attach = txtDinhKem.Text;
                    data.title = txtTitle.Text;
                    Thread th = new Thread(() =>
                    {
                        List<Customer> customers = CustomerDAO.Instance.GetCustomers();
                        var service = new MailerService();

                        foreach(var c in customers)
                        {
                            if(new ValidatorContext(c.Email, ValidatorType.Email).runValidation()
                            && c.Email.Contains("@gmail.com"))
                            {
                                service.AddObserver(c);
                            }
                                
                        }
                       

                        service.SetEmailData(data);
                    });
                    th.Start();
                    MessageBox.Show("Đang thực hiện gửi Email");
                    clearText();

                }
            }
            catch
            {
                MessageBox.Show("Có lỗi");
            }

            
        }
    }
}
