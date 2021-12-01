using CuaHangPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        
        public static AccountDAO Instance
        {
            get {
                if (instance == null)
                    instance = new AccountDAO();
                return instance; 
            }
            private set { instance = value; } 
        }
        private AccountDAO()
        {

        }
        public bool LoginAdmin(string use,string pass)
        {
            string query = "SELECT * FROM [QUANLYBANHANG].[dbo].[ACCOUNT] WHERE USERNAME = '"+use+ "' AND PASSWORD='"+pass+ "' AND TYPE = 0";
            DataTable rs = DataProvider.Instance.ExecuteQuery(query);
            return rs.Rows.Count==1;
        }

        public bool LoginStaff(string use, string pass)
        {
            string query = "SELECT * FROM [QUANLYBANHANG].[dbo].[ACCOUNT] WHERE USERNAME = '" + use + "' AND PASSWORD='" + pass + "' AND TYPE = 1";
            DataTable rs = DataProvider.Instance.ExecuteQuery(query);
            return rs.Rows.Count == 1;
        }
        public List<Account> loadAllAccount()
        {
            List<Account> list = new List<Account>();
            string query = "SELECT [ID],[USERNAME],[PASSWORD],[TYPE] FROM [QUANLYBANHANG].[dbo].[ACCOUNT]";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                list.Add(account);
            }
            return list;
        }

        public bool InsertAdmin(string username, string password)
        {
            string query = "INSERT INTO ACCOUNT VALUES('"+username+"','"+password+"',0)";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query);
            return rs > 0;
        }
        
        public bool InsertStaff(string username, string password)
        {
            string query = "INSERT INTO ACCOUNT VALUES('" + username + "','" + password + "',1)";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query);
            return rs > 0;
        }

        public bool UpdateUser(int id, string password, int role)
        {
            string query = "UPDATE ACCOUNT SET PASSWORD = '"+password+"', TYPE = "+role + " WHERE ID= "+id;
            int rs = DataProvider.Instance.ExecuteNoneQuery(query);
            return rs > 0;

        }
        public bool DeleteAccount(int id)
        {
            string query = "DELETE FROM ACCOUNT WHERE ID= " + id;
            int rs = DataProvider.Instance.ExecuteNoneQuery(query);
            return rs > 0;
        }
    }
}
