using CuaHangPhanMem.DAO;
using CuaHangPhanMem.Observer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DTO
{
    public class Customer : IEmailObserver
    {
        private int id;
        private string name;
        private string phone;
        private string add;
        private int totalmoney;
        private string email;


        public Customer(int id, string name,string phone, string add, int totalMoney, string email)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.add = add;
            this.totalmoney = totalMoney;
            this.email = email;
        }
        public Customer(DataRow row)
        {
            this.id = (int)row["MAKH"];
            this.name = row["TENKH"].ToString();
            this.phone = row["SDTKH"].ToString();
            this.add = row["DIACHI"].ToString();
            this.totalmoney = (int)row["TONGTIEN"];
            this.email = row["EMAIL"].ToString();
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Add { get => add; set => add = value; }
        public int Totalmoney { get => totalmoney; set => totalmoney = value; }
        public string Email { get => email; set => email = value; }

        // Dùng cho observer pattern
        public void Notify(EmailData data)
        {
            MailMessage mail = new MailMessage();
            SmtpClient server = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(SaveDataStatic.email);
            mail.To.Add(this.email.Replace(" ", ""));
            mail.Subject = data.title;
            mail.Body = data.content;
            if (File.Exists(data.attach))
            {
                Attachment attachment = new Attachment(data.attach);
                mail.Attachments.Add(attachment);
            }
            server.Port = 587;
            server.Credentials = new NetworkCredential(SaveDataStatic.email, SaveDataStatic.pass_email);
            server.EnableSsl = true;
            server.Send(mail);
        }
    }
}
