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
        int soLuong;
        int donGia;
        int tongTien;

        public ViewProductRanking(int iD, string tenSP, int soLuong, int donGia, int tongTien)
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
            this.soLuong = (int)row["SOLUONG"];
            this.donGia = (int)row["DONGIA"];
            this.tongTien = (int)row["TONGTIEN"];
        }
        public int ID { get => iD; set => iD = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int DonGia { get => donGia; set => donGia = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
    }
}
