using CuaHangPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CuaHangPhanMem.Template
{
    class RemoveAccount : IActionTemplate
    {
        protected override void action()
        {
            var newForm = (frmAccount)form;
            var account = newForm.GetAccountTextBox();
            if (AccountDAO.Instance.Delete(account.ID))
            {
                MessageBox.Show("Xóa tài khoản thành công !!");

            }
            else
            {
                MessageBox.Show("Xóa tài khoản này thất bại!");
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
