using CuaHangPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem.Template
{
    class UpdateProduct : IActionTemplate
    {
        protected override void action()
        {
            var newForm = (frmSanPham)form;
            var product = newForm.GetProductTextBox();
            if (ProductDAO.Instance.Update(product))
            {
                MessageBox.Show("Cập nhật phần mềm thành công !!");
            }
            else
            {
                MessageBox.Show("Cập nhật phần mềm không thành công!!");
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
