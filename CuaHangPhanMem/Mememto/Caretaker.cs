using CuaHangPhanMem.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Mememto
{
    class Caretaker
    {
        List<EmailData> history = new List<EmailData>();
        public void add(EmailData data)
        {
            history.Add(data);
        }

        public EmailData get(int index)
        {
            return history.ElementAt(index);
        }
    }
}
