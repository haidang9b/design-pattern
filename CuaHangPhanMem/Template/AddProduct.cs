using CuaHangPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem.Template
{
    class AddProduct : IActionTemplate
    {
        protected override void action()
        {
            var newForm = (frmSanPham)form;
            var product = newForm.GetProductTextBox();
            if (ProductDAO.Instance.Add(product))
            {
                MessageBox.Show("Thêm phần mềm thành công !!");
            }
            else
            {
                MessageBox.Show("Không thành công!!");
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
