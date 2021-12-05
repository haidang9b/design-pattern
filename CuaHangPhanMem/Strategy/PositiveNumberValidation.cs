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
            if (int.TryParse(str, out int value))
            {
                var result = value > 0 ? true : false;
                return result;
            }
            return false;
        }
    }
}
