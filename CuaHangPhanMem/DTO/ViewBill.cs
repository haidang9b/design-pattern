using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DTO
{
    public class ViewBill
    {
        int iD;
        string name;
        string sdt;
        string date;
        string totalMoney;

        public ViewBill(int iD, string name, string sdt,string date , string totalMoney)
        {
            this.iD = iD;
            this.name = name;
            this.sdt = sdt;
            this.date = date;
            this.totalMoney = totalMoney;
        }
        public ViewBill(DataRow row)
        {
            this.iD = (int)row["MAHD"];
            this.name = row["TENKH"].ToString();
            this.sdt = row["SDTKH"].ToString();
            this.date = row["TGMUA"].ToString();
            this.totalMoney = row["TONGTIEN"].ToString();
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Date { get => date; set => date = value; }
        public string TotalMoney { get => totalMoney; set => totalMoney = value; }
        
    }
}
