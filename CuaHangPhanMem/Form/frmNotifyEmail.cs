using CuaHangPhanMem.DAO;
using CuaHangPhanMem.Decorator;
using CuaHangPhanMem.DTO;
using CuaHangPhanMem.Mememto;
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
        private Caretaker caretaker = new Caretaker();
        private Originator originator = new Originator();
        private int saveArticles = 0;
        private int currentArticles = 0;
        public frmNotifyEmail()
        {
            InitializeComponent();
            btnUndo.Enabled = false;
            btnRedo.Enabled = false;
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
                if (new ValidatorContext(txtTitle.Text, ValidatorType.String).runValidation()
                    && new ValidatorContext(txtContent.Text, ValidatorType.String).runValidation())
                {
                    EmailData data = new EmailData();
                    LanguagesDecorator vietnamese = new DefaultLanguage();


                    if (English.Checked)
                    {
                        vietnamese = new EnglishComdiment(vietnamese);

                    }

                    string[] dataEmail = vietnamese.Generate(txtTitle.Text, txtContent.Text);
                    data.title = dataEmail[0];
                    data.content = dataEmail[1];
                    data.attach = txtDinhKem.Text;
                    MessageBox.Show(data.title + " -- " + data.content);




                    //EmailData data = new EmailData();
                    //data.content = txtContent.Text;
                    //data.attach = txtDinhKem.Text;
                    //data.title = txtTitle.Text;
                    Thread th = new Thread(() =>
                    {
                        List<Customer> customers = CustomerDAO.Instance.GetCustomers();
                        var service = new MailerService();

                        foreach (var c in customers)
                        {
                            if (new ValidatorContext(c.Email, ValidatorType.Email).runValidation()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            EmailData data = new EmailData();
            data.content = txtContent.Text;
            data.attach = txtDinhKem.Text;
            data.title = txtTitle.Text;
            originator.setEmailData(data);
            caretaker.add(originator.saveToMemento());
            saveArticles += 1;
            currentArticles += 1;
            btnUndo.Enabled = true;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if(currentArticles >= 1)
            {
                currentArticles -= 1;
                var previousData = originator.restoreFromMemento(caretaker.get(currentArticles));
                txtContent.Text = previousData.content;
                txtDinhKem.Text = previousData.attach;
                txtTitle.Text = previousData.title;
                btnRedo.Enabled = true;
            }
            else
            {
                btnUndo.Enabled = false;
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if((saveArticles -1) > currentArticles)
            {
                currentArticles += 1;
                var nextData = originator.restoreFromMemento(caretaker.get(currentArticles));
                txtContent.Text = nextData.content;
                txtDinhKem.Text = nextData.attach;
                txtTitle.Text = nextData.title;
                btnUndo.Enabled = true;
            }
            else
            {
                btnRedo.Enabled = false;
            }
        }
    }
}
