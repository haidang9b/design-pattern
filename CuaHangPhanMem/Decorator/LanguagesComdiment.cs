using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Decorator
{
    public abstract class LanguagesComdiment : LanguagesDecorator
    {
        protected LanguagesDecorator languages;
    }
}
