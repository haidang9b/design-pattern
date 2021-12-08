using CuaHangPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CuaHangPhanMem.Template
{
    class RemoveProductType : IActionTemplate
    {
        protected override void action()
        {
            var newForm = (frmLoaiSP)form;
            var item = newForm.GetProductTypeTextBox();
            MessageBoxResult confirmResult = MessageBox.Show("Bạn có muốn xóa loại phần mềm này không ??", "Xác nhận xóa loại phần mềm", MessageBoxButton.YesNo);
            
            if(confirmResult == MessageBoxResult.Yes)
            {
                if (ProductTypeDAO.Instance.Delete(item.Id))
                {
                    MessageBox.Show("Xóa loại phần mềm thành công !!");
                }
                else
                {
                    MessageBox.Show("Xóa loại phần mềm thất bại!!");
                }
            }
        }

        protected override void ClearTextBox()
        {
            var newForm = (frmLoaiSP)form;
            newForm.clearText();
        }

        protected override void LoadData()
        {
            var newForm = (frmLoaiSP)form;
            newForm.loadProductType();
        }
    }
}
