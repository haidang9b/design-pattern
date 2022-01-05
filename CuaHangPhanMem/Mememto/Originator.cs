using CuaHangPhanMem.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Mememto
{
    class Originator
    {
        private EmailData data;

        public void setEmailData(EmailData _data)
        {
            this.data = _data;
        }

        public EmailData saveToMemento()
        {
            return new EmailData {title = data.title, content = data.content, attach = data.attach };
        }

        public EmailData restoreFromMemento(EmailData data)
        {
            this.data = data;
            return this.data;
        }
    }
}
