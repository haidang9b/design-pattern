using CuaHangPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem.Template
{
    class AddAccount : IActionTemplate
    {
        private bool isDone = false;

        protected override bool hasDone()
        {
            return isDone;
        }
        protected override void action()
        {
            var newForm = (frmAccount)form;
            var account = newForm.GetAccountTextBox();
            bool res = AccountDAO.Instance.Add(account);
            if (res)
            {
                isDone = true;
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
        }

       

        protected override void ClearTextBox()
        {
            var newForm = (frmAccount)form;
            newForm.clearText();
        }

        protected override void LoadData()
        {
            var newForm = (frmAccount)form;
            newForm.LoadAllAccount();
        }
    }
}
