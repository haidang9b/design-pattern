using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DTO
{
    public class ViewProductRanking
    {
        int iD;
        string tenSP;
        Int64 soLuong;
        Int64 donGia;
        Int64 tongTien;

        public ViewProductRanking(int iD, string tenSP, Int64 soLuong, Int64 donGia, Int64 tongTien)
        {
            this.iD = iD;
            this.tenSP = tenSP;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.tongTien = tongTien;
        }
        public ViewProductRanking(DataRow row)
        {
            this.iD = (int)row["MASP"];
            this.tenSP = row["TENSP"].ToString();
            this.soLuong = Int64.Parse(row["SOLUONG"].ToString());
            this.donGia = Int64.Parse(row["DONGIA"].ToString());
            this.tongTien = Int64.Parse(row["TONGTIEN"].ToString());
        }
        public int ID { get => iD; set => iD = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public Int64 SoLuong { get => soLuong; set => soLuong = value; }
        public Int64 DonGia { get => donGia; set => donGia = value; }
        public Int64 TongTien { get => tongTien; set => tongTien = value; }
    }
}
