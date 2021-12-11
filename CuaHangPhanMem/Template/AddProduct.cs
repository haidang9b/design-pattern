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

        private bool isDone = false;

        protected override bool hasDone()
        {
            return isDone;
        }
        protected override void action()
        {
            var newForm = (frmSanPham)form;
            var product = newForm.GetProductTextBox();
            if (ProductDAO.Instance.Add(product))
            {
                isDone = true;
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
