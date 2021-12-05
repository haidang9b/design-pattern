using CuaHangPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Strategy
{
    public class StringValidation : IValidation
    {
        public bool validation(string str)
        {
            string trim = str.Replace(" ", "");
            if (trim.Length > 0)
            {
                return true;
            }
            
            return false;
        }
    }
}
