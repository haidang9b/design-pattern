using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem
{
    public enum LoginType
    {
        User,
        Admin
    }
    public class FactoryLogin
    {
        private static FactoryLogin instance;
        public static FactoryLogin Instance
        {
            get
            {
                if (instance == null)
                    instance = new FactoryLogin();
                return instance;
            }
            private set { instance = value; }
        }
        private FactoryLogin() { }
        public Form CreateLogin(LoginType type, string tk)
        {
            switch (type)
            {
                case LoginType.Admin:
                    return new BanHang();

                case LoginType.User:
                    return new BanHangStaff();
            }
            return null;
        }
    }
}
