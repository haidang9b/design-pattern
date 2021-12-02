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
        public bool LoginAdmin(string user,string pass)
        {

            string query = "SELECT * FROM ACCOUNT WHERE USERNAME = @USER AND PASSWORD= @PASS AND TYPE = 0";
            DataTable rs = DataProvider.Instance.ExecuteQuery(query, new object[]{ user, pass});
            return rs.Rows.Count==1;
        }

        public bool LoginStaff(string user, string pass)
        {
            string query = "SELECT * FROM ACCOUNT WHERE USERNAME = @USER AND PASSWORD = @PASS AND TYPE = 1";
            DataTable rs = DataProvider.Instance.ExecuteQuery(query, new object[] { user, pass });
            return rs.Rows.Count == 1;
        }
        public List<Account> GetAccounts()
        {
            List<Account> list = new List<Account>();
            string query = "SELECT ID,USERNAME,PASSWORD,TYPE FROM ACCOUNT";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                list.Add(account);
            }
            return list;
        }
        
        public bool Add(Account account)
        {
            string query = "INSERT INTO ACCOUNT( USERNAME, PASSWORD, TYPE) VALUES( @username , @password , @role )";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { account.Username, account.Password, account.Role });
            return rs > 0;
        }

        public bool Update(Account account)
        {
            string query = "UPDATE ACCOUNT SET PASSWORD = @pass , TYPE = @role WHERE ID= @id ";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { account.Password, account.Role, account.ID});
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
