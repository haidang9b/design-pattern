using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DTO
{
    public class ProductType
    {
        private int id;
        private string name;
        public ProductType(int id,string name)
        {
            this.id = id;
            this.name = name;
        }
        public ProductType(DataRow row)
        {
            this.id = (int)row["MALOAI"];
            this.name = row["TENLOAI"].ToString();
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
