using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DTO
{
    public class ViewBillInfo
    {
        private string name;
        private int counter;
        private int price;
        private int totalMoney;
        public ViewBillInfo(string name, int counter, int price, int totalMoney=0)
        {
            this.name = name;
            this.counter = counter;
            this.price = price;
            this.totalMoney = totalMoney;
        }
        public ViewBillInfo(DataRow row)
        {
            this.name = row["TENSP"].ToString() ;
            this.counter = (int)row["SL"];
            this.price = (int)row["DONGIA"];
            this.totalMoney = (int)row["TONGGIA"];
        }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public int Count { get => counter; set => counter = value; }
        public int TotalMoney { get => totalMoney; set => totalMoney = value; }
    }
}
