using CuaHangPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CuaHangPhanMem.Template
{
    class UpdateAccount : IActionTemplate
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
            bool res = AccountDAO.Instance.Update(account);
            if (res)
            {
                isDone = true;
                MessageBox.Show("Cập nhật mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật mật khẩu thất bại");
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
