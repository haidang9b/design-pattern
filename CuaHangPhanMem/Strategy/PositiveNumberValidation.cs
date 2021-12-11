using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Strategy
{
    class PositiveNumberValidation : IValidation
    {
        public bool validation(string str)
        {
            if (str.Length == 0)
            {
                return false;
            }
            try
            {
                int tmp = int.Parse(str);
                return tmp > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
