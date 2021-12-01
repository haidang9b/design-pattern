using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DTO
{
    public class BillInfo
    {
        int id;
        int idhd;
        int masp;
        int sl;

        public BillInfo(int id, int idhd, int masp,int sl)
        {
            this.id = id;
            this.idhd = idhd;
            this.masp = masp;
            this.sl = sl;
        }
        public BillInfo(DataRow row)
        {
            this.id = (int)row["ID"];
            this.idhd = (int)row["MAHD"];
            this.masp = (int)row["MASP"];
            this.sl = (int)row["SL"];
        }
        public int Id { get => id; set => id = value; }
        public int Idhd { get => idhd; set => idhd = value; }
        public int Masp { get => masp; set => masp = value; }
        public int Soluong { get => sl; set => sl = value; }
    }
}
