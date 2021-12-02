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
        public static string connectString1 = "Data Source=DROM\\SQLEXPRESS,1433;Initial Catalog=QUANLYBANHANG;Integrated Security=False;Persist Security Info=True;User ID=sa;Password=123;Context Connection=False";
        public static string connectString2 = "Data Source=127.0.0.1;port=3306;Integrated Security=False;Initial Catalog=quanlycuahang; User=root;Password=;";
    }
}
