using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DTO
{
    public class Account
    {
        int iD;
        string username;
        string password;
        int role;

        public Account(int id, string username, string password, int role)
        {
            this.iD = id;
            this.username = username;
            this.password = password;
            this.role = role;
        }
        public Account (DataRow row)
        {
            this.iD = (int)row["ID"];
            this.username = row["USERNAME"].ToString();
            this.password = row["PASSWORD"].ToString();
            this.role = (int)row["TYPE"];
        }

        public int ID { get => iD; set => iD = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Role { get => role; set => role = value; }
        
    }
}
