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
            MessageBoxResult confirmResult = MessageBox.Show("Bạn có muốn xóa tài khoản này không ??", "Xác nhận xóa tài khoản", MessageBoxButton.YesNo);

            if(confirmResult == MessageBoxResult.Yes)
            {
                if (AccountDAO.Instance.Delete(account.ID))
                {
                    MessageBox.Show("Xóa tài khoản thành công !!");

                }
                else
                {
                    MessageBox.Show("Xóa tài khoản này thất bại!");
                }
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
