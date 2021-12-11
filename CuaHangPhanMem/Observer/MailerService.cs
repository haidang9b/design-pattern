using CuaHangPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Observer
{
    class MailerService
    {
        List<IEmailObserver> observers;
        public MailerService()
        {
            observers = new List<IEmailObserver>();
        }

        public void AddObserver(IEmailObserver _observer)
        {
            observers.Add(_observer);
        }

        public void RemoveObserver(IEmailObserver _observer)
        {
            observers.Remove(_observer);
        }

        public void SendEmail(EmailData data)
        {
            foreach(var obs in observers)
            {
                obs.Notify(data);
            }
        }

        public void SetEmailData(EmailData data)
        {
            SendEmail(data);
        }
    }
}
