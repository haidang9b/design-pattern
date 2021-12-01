using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DTO
{
    public class Bill
    {
        int id;
        int makh;
        string tennv;
        string dtmua;
        string tongtien;
        public Bill(int id,int makh, string tennv, string dtmua, string tongtien)
        {
            this.id = id;
            this.makh = makh;
            this.tennv = tennv;
            this.dtmua = dtmua;
            this.tongtien = tongtien;
        }
        public Bill(DataRow row)
        {
            this.id = (int)row["MAHD"] ;
            this.makh = (int)row["MAKH"];
            this.tennv = row["NVBAN"].ToString();
            this.dtmua = row["TGMUA"].ToString();
            this.tongtien = row["TONGTIEN"].ToString();
        }
        public int ID { get => id; set => id = value; }
        public int MaKH { get => makh; set => makh = value; }
        public string TenNV { get => tennv; set => tennv = value; }
        public string TGmua { get => dtmua; set => dtmua = value; }
        public string TongTien { get => tongtien; set => tongtien = value; }
    }

}
