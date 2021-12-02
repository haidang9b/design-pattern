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
            string query = "SELECT MAKH,TENKH,SDTKH,DIACHI,TONGTIEN FROM KHACHHANG WHERE TONGTIEN>= @start AND TONGTIEN < @end";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { start , end});
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
            string query = "SELECT MAKH,TENKH,SDTKH,DIACHI,TONGTIEN FROM KHACHHANG";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                list.Add(customer);
            }
            return list;
        }
        public bool InsertCustomer(Customer customer)
        {
            string query = "INSERT INTO KHACHHANG(TENKH,SDTKH,DIACHI,TONGTIEN) VALUES( @name , @sdt , @diachi ,0)";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { customer.Name, customer.Phone, customer.Add});
            return rs > 0;
        }

        public bool DeleteCustomer(int id)
        {
            string query = "DELETE FROM KHACHHANG WHERE MAKH = @id ";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id});
            return rs > 0;
        }

        public bool UpdateCustomer(Customer customer)
        {
            string query = "UPDATE KHACHHANG SET TENKH = @name , SDTKH = @sdt , DIACHI= @add WHERE MAKH = @id " ;
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { customer.Name, customer.Phone, customer.Add, customer.Id });
            return rs > 0;
        }

        public List<Customer> SearchCustomerByPhone(int phone)
        {
            List<Customer> list = new List<Customer>();
            string query = "SELECT MAKH,TENKH,SDTKH,DIACHI,TONGTIEN FROM KHACHHANG WHERE SDTKH LIKE @phone";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { "%"+phone+"%"});
            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                list.Add(customer);
            }
            return list;
        }

    }
}
