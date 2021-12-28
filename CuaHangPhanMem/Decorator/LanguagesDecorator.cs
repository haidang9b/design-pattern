using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Decorator
{
    public abstract class LanguagesDecorator
    {
        public abstract string[] Generate(string title, string content);
    }
}
