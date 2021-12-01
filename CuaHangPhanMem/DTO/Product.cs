using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DTO
{
    public class Product
    {
        private int id;
        private string name;
        private int typeProduct;
        private int amountProduct;
        private int price;
        public Product(int id, string name, int typeProduct, int amountProduct, int price)
        {
            this.id = id;
            this.name = name;
            this.typeProduct = typeProduct;
            this.amountProduct = amountProduct;
            this.price = price;
        }
        public Product(DataRow row)
        {
            this.id = (int)row["MASP"] ;
            this.name = row["TENSP"].ToString();
            this.typeProduct = (int)row["LOAISP"];
            this.amountProduct = (int)row["SOLUONGTON"];
            this.price = (int)row["DONGIA"];

        }

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int TypeProduct { get => typeProduct; set => typeProduct = value; }
        public int AmountProduct { get => amountProduct; set => amountProduct = value; }
        public int Price { get => price; set => price = value; }

        
    }
}
