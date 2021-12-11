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
            string query = "SELECT MAKH,TENKH,SDTKH,DIACHI,TONGTIEN, EMAIL FROM KHACHHANG WHERE TONGTIEN>= @start AND TONGTIEN < @end";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { start , end});
            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                list.Add(customer);
            }
            return list;
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>();
            string query = "SELECT MAKH,TENKH,SDTKH,DIACHI,TONGTIEN, EMAIL  FROM KHACHHANG";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                list.Add(customer);
            }
            return list;
        }
        public bool Add(Customer customer)
        {
            string query = "INSERT INTO KHACHHANG(TENKH,SDTKH,DIACHI,TONGTIEN, EMAIL ) VALUES( @name , @sdt , @diachi ,0, @mail)";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { customer.Name, customer.Phone, customer.Add, customer.Email});
            return rs > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM KHACHHANG WHERE MAKH = @id ";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id});
            return rs > 0;
        }

        public bool Update(Customer customer)
        {
            string query = "UPDATE KHACHHANG SET TENKH = @name , SDTKH = @sdt , DIACHI= @add , EMAIL = @mail WHERE MAKH = @id " ;
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { customer.Name, customer.Phone, customer.Add, customer.Email,customer.Id });
            return rs > 0;
        }

        public List<Customer> SearchCustomerByPhone(int phone)
        {
            List<Customer> list = new List<Customer>();
            string query = "SELECT MAKH,TENKH,SDTKH,DIACHI,TONGTIEN, EMAIL FROM KHACHHANG WHERE SDTKH LIKE @phone";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { "%"+phone+"%"});
            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                list.Add(customer);
            }
            return list;
        }


        public int GetTotalMoneyByID(int id)
        {
            string query = "SELECT TONGTIEN FROM KHACHHANG WHERE MAKH =  @IDKH ";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            DataRow dataRow = dataTable.Rows[0];
            return (int)dataRow["TONGTIEN"];
        }

    }
}
