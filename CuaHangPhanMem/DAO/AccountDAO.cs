using CuaHangPhanMem.DTO;
using CuaHangPhanMem.Factory;
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
        public Account GetAccountLogin(string username, string password)
        {
            string query = "SELECT ID,USERNAME, FULLNAME,PASSWORD,TYPE FROM ACCOUNT WHERE USERNAME = @u AND PASSWORD = @p ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password});
            if(data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new Account(row);
            }
            return null;
        }
  
        public List<Account> GetAccounts()
        {
            List<Account> list = new List<Account>();
            string query = "SELECT ID,USERNAME, FULLNAME,PASSWORD,TYPE FROM ACCOUNT";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                list.Add(account);
            }
            return list;
        }
        public bool isExist(string username)
        {
            string query = "SELECT ID,USERNAME, FULLNAME,PASSWORD,TYPE FROM ACCOUNT WHERE USERNAME = @u ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { username });
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool Add(Account account)
        {
            string query = "INSERT INTO ACCOUNT( USERNAME, PASSWORD, TYPE, FULLNAME) VALUES( @username , @password , @role , @fullname )";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { account.Username, account.Password, account.Role , account.FullName});
            return rs > 0;
        }

        public bool Update(Account account)
        {
            string query = "UPDATE ACCOUNT SET PASSWORD = @pass , TYPE = @role , FULLNAME = @fullname WHERE ID= @id ";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { account.Password, account.Role, account.FullName, account.ID});
            return rs > 0;

        }
        public bool Delete(int id)
        {
            string query = "DELETE FROM ACCOUNT WHERE ID= @id";
            
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id});
            return rs > 0;
        }
    }
}
