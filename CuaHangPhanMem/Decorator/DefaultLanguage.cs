using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Decorator
{
    public class DefaultLanguage : LanguagesDecorator
    {
        public override string[] Generate(string title, string content)
        {
            string[] Data = { title, content };
            return Data;
        }

    }
}
