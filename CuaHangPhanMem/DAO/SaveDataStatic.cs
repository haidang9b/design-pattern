using CuaHangPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DAO
{
    public static class SaveDataStatic
    {
        public static int typeServer = 2;
        // MSSQL
        public static string connectString1 = "Data Source=DROM\\SQLEXPRESS,1433;Initial Catalog=QUANLYBANHANG;Integrated Security=False;Persist Security Info=True;User ID=sa;Password=123;Context Connection=False";
        //MySQL
        public static string connectString2 = "Data Source=127.0.0.1;port=3306;Integrated Security=False;Initial Catalog=quanlycuahang; User=root;Password=;";

        public static string email = "dromvvvvxvxvx@gmail.com";
        public static string pass_email = "cu4h4ngfanm3m@bc";
        public static Account login = null; 
    }
}
