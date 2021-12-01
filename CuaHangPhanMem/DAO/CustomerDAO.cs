using CuaHangPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomerDAO();
                return instance;
            }
            private set { instance = value; }
        }
        private CustomerDAO() { }
        public List<Customer> LoadAllCustomerVIP(int start, int end)
        {
            List<Customer> list = new List<Customer>();
            string query = "SELECT [MAKH],[TENKH],[SDTKH],[DIACHI],[TONGTIEN] FROM [QUANLYBANHANG].[dbo].[KHACHHANG] WHERE TONGTIEN>=" + start + " AND TONGTIEN <" + end;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                list.Add(customer);
            }
            return list;
        }
        public List<Customer> LoadAllCustomer()
        {
            List<Customer> list = new List<Customer>();
            string query = "SELECT [MAKH],[TENKH],[SDTKH],[DIACHI],[TONGTIEN] FROM [QUANLYBANHANG].[dbo].[KHACHHANG]";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                list.Add(customer);
            }
            return list;
        }
        public bool InsertCustomer(string name, string sdt, string address)
        {
            string query = "INSERT INTO KHACHHANG(TENKH,SDTKH,DIACHI,TONGTIEN) VALUES(N'" + name + "','" + sdt + "',N'" + address + "',0)";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query);
            return rs > 0;
        }

        public bool DeleteCustomer(int id)
        {
            string query = "DELETE FROM KHACHHANG WHERE MAKH = " + id;
            int rs = DataProvider.Instance.ExecuteNoneQuery(query);
            return rs > 0;
        }

        public bool UpdateCustomer(int id, string name, string sdt, string address)
        {
            string query = "UPDATE KHACHHANG SET TENKH = N'" + name + "', SDTKH = '" + sdt + "' , DIACHI= N'" + address + "' WHERE MAKH = " + id;
            int rs = DataProvider.Instance.ExecuteNoneQuery(query);
            return rs > 0;
        }

        public List<Customer> SearchCustomerByPhone(int phone)
        {
            List<Customer> list = new List<Customer>();
            string query = "SELECT [MAKH],[TENKH],[SDTKH],[DIACHI],[TONGTIEN] FROM [QUANLYBANHANG].[dbo].[KHACHHANG] WHERE SDTKH LIKE '%" + phone + "%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                list.Add(customer);
            }
            return list;
        }

    }
}
