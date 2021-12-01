using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DTO
{
    public class Customer
    {
        private int id;
        private string name;
        private string phone;
        private string add;
        private string totalmoney;

        public Customer(int id, string name,string phone, string add, string totalMoney)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.add = add;
            this.totalmoney = totalMoney;
        }
        public Customer(DataRow row)
        {
            this.id = (int)row["MAKH"];
            this.name = row["TENKH"].ToString();
            this.phone = row["SDTKH"].ToString();
            this.add = row["DIACHI"].ToString();
            this.totalmoney = row["TONGTIEN"].ToString();
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Add { get => add; set => add = value; }
        public string Totalmoney { get => totalmoney; set => totalmoney = value; }
    }
}
