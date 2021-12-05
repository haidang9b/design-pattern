using CuaHangPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CuaHangPhanMem.Template
{
    class UpdateProductType : IActionTemplate
    {
        protected override void action()
        {
            var newForm = (frmLoaiSP)form;
            var item = newForm.GetProductTypeTextBox();
            if (ProductTypeDAO.Instance.Update(item.Id, item.Name))
            {
                MessageBox.Show("Cập nhật loại phần mềm thành công !!");
            }
            else
            {
                MessageBox.Show("Cập nhật loại phần mềm thất bại!!");
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
