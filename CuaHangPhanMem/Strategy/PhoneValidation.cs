using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Strategy
{
    class PhoneValidation : IValidation
    {
        public bool validation(string str)
        {
            var regex = @"(84|0[3|5|7|8|9])+([0-9]{8})\b";
            var match = Regex.Match(str, regex, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return true;
            }
            return false;
        }
    }
}
