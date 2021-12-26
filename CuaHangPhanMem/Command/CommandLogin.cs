using CuaHangPhanMem.DAO;
using CuaHangPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem.Command
{
    public abstract class LoginCommand
    {
        public bool isLogin = false;
        public abstract void Login(string username, string password);
        public abstract void Logout();
    }



    public class LoginForm : LoginCommand
    {
        public override void Login(string username, string password)
        {
            Account item = AccountDAO.Instance.GetAccountLogin(username, password);
            if (item == null)
            {
                isLogin = false;
                return;
            }
            if (item.Role == 0) // is admin
            {
                SaveDataStatic.login = item;
                Form frm = FactoryLogin.Instance.CreateLogin(LoginType.Admin, username);
                
                frm.Show();
                isLogin = true;
            }
            if(item.Role == 1)
            {
                SaveDataStatic.login = item;
                Form banHangStaff = FactoryLogin.Instance.CreateLogin(LoginType.User, username);
                
                banHangStaff.Show();
                isLogin = true;
            }
           
        }

        public override void Logout()
        {
            LOGIN frm = new LOGIN();
            frm.Show();
            SaveDataStatic.login = null;
        }
    }
}
