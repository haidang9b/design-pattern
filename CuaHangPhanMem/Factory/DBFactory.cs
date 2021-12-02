using CuaHangPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Factory
{
    public class DBFactory
    {
        private static DBFactory instance = null;

        private DBFactory() { }

        public static DBFactory Instance()
        {
            if(instance == null)
            {
                instance = new DBFactory();
            }
            return instance;
        }


        public DatabaseFactory createDatabaseFactory()
        {
            if(SaveDataStatic.typeServer == 1)
            {
                return new MSSQLDbFactory();
            }
            return new MySQLDbFactory();
        }

        
    }
}
