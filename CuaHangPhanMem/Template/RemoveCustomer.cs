using CuaHangPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CuaHangPhanMem.Template
{
    class RemoveCustomer : IActionTemplate
    {
        protected override void action()
        {
            var newForm = (frKhachHang)form;
            var customer = newForm.GetCustomerTextBox();
            if (CustomerDAO.Instance.Delete(customer.Id))
            {
                MessageBox.Show("Xóa khách hàng thành công !!");

            }
            else
            {
                MessageBox.Show("Xóa khách hàng thất bại!!");
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
