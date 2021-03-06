using CuaHangPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CuaHangPhanMem.Template
{
    class RemoveProduct : IActionTemplate
    {
        private bool isDone = false;

        protected override bool hasDone()
        {
            return isDone;
        }
        protected override void action()
        {
            var newForm = (frmSanPham)form;
            var product = newForm.GetProductTextBox();

            MessageBoxResult confirmResult = MessageBox.Show("Bạn có muốn xóa phần mềm này không ??", "Xác nhận xóa phần mềm", MessageBoxButton.YesNo);

            if(confirmResult == MessageBoxResult.Yes)
            {
                if (ProductDAO.Instance.Delete(product.ID))
                {
                    isDone = true;
                    MessageBox.Show("Xóa phần mềm thành công !!");
                }
                else
                {
                    MessageBox.Show("Xóa phần mềm không thành công!!");
                }
            }

        }

        protected override void ClearTextBox()
        {
            var newForm = (frmSanPham)form;
            newForm.clearText();
        }

        protected override void LoadData()
        {
            var newForm = (frmSanPham)form;
            newForm.LoadListProduct();
        }
    }
}
