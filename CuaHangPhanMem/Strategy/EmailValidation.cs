using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Strategy
{
    class EmailValidation : IValidation
    {
        public bool validation(string str)
        {
            try
            {
                string trim = str.Replace(" ", "");
                if (trim.Length  <= 0)
                {
                    return false;
                }
                MailAddress m = new MailAddress(trim);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
