using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Observer
{
    public interface IEmailObserver
    {
        void Notify(EmailData data);
    }
}
