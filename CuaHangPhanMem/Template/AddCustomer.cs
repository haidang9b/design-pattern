using CuaHangPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem.Template
{
    class AddCustomer : IActionTemplate
    {
        protected override void action()
        {
            var newForm = (frKhachHang)form;
            var customer = newForm.GetCustomerTextBox();
            if (CustomerDAO.Instance.Add(customer))
            {
                MessageBox.Show("Thêm khách hàng thành công !!");
                
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!!");
            }
        }

        protected override void ClearTextBox()
        {

            var newForm = (frKhachHang)form;
            newForm.clearText();
        }

        protected override void LoadData()
        {
            var newForm = (frKhachHang)form;
            newForm.loadDatacustomer();
        }
    }
}
