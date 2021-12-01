using CuaHangPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;

        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductDAO();
                return instance;
            }
            private set { instance = value; }
        }
        private ProductDAO() { }
        // LOAD DATA
        public List<Product> LoadAllProduct()
        {
            List<Product> list = new List<Product>();
            string query = "SELECT * FROM [QUANLYBANHANG].[dbo].[SANPHAM]";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                list.Add(product);
            }
            return list;
        }
        public List<Product> LoadAllProductByCatagoryID(int id)
        {
            List<Product> list = new List<Product>();
            string query = "SELECT * FROM [QUANLYBANHANG].[dbo].[SANPHAM] Where LOAISP = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                list.Add(product);
            }
            return list;
        }
        // XOA SAN PHAM
        public bool DeleteProduct(int id)
        {
            string query = "DELETE FROM SANPHAM WHERE MASP = " + id;
            int rs = DataProvider.Instance.ExecuteNoneQuery(query);
            return rs > 0;
        }
        // SUA SAN PHAM

        public bool UpdateProduct(int id, string name, int catalog, int slt, int price) 
        {
            string query = "UPDATE SANPHAM SET TENSP = N'" + name +"' , LOAISP = " + catalog +" ,SOLUONGTON = " + slt +" , DONGIA = " + price +" WHERE MASP = " + id;
            int rs = DataProvider.Instance.ExecuteNoneQuery(query);
            return rs > 0;
        }


        // THEM SAN PHAM
        public bool InsertProduct(string name, int maloai, int slt, int price)
        {
            string query = "INSERT INTO SANPHAM VALUES( N'" 
                + name + "' , " + maloai + " , " + slt + " , " + price + ")";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query);
            return rs>0;
        }
        // TIM KIEM SAN PHAM

        public List<Product> searchItem(string name)
        {
            List<Product> list = new List<Product>();
            string query = "SELECT * FROM [QUANLYBANHANG].[dbo].[SANPHAM] WHERE TENSP LIKE N'%" + name + "%' ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                list.Add(product);
            }
            return list;
        }
        public List<ViewProductRanking> loadAllProductRanking()
        {
            List<ViewProductRanking> list = new List<ViewProductRanking>();
            string query = "SELECT SANPHAM.MASP, SANPHAM.TENSP,SOLUONG, SANPHAM.DONGIA, SOLUONG*SANPHAM.DONGIA AS'TONGTIEN' FROM SANPHAM INNER JOIN (SELECT SP.MASP, SUM(CT.SL) as 'SOLUONG' FROM SANPHAM SP INNER JOIN CHITIETHOADON CT ON SP.MASP = CT.MASP INNER JOIN HOADON HD ON HD.MAHD = CT.MAHD GROUP BY  SP.MASP) AS X ON X.MASP = SANPHAM.MASP ORDER BY SOLUONG DESC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ViewProductRanking product = new ViewProductRanking(item);
                list.Add(product);
            }
            return list;
        }
        public List<ViewProductRanking> loadAllProductRankingByTime(string start, string end)
        {
            List<ViewProductRanking> list = new List<ViewProductRanking>();
            string query = "SET DATEFORMAT DMY  SELECT SANPHAM.MASP, SANPHAM.TENSP,SOLUONG, SANPHAM.DONGIA, SOLUONG*SANPHAM.DONGIA AS'TONGTIEN' FROM SANPHAM INNER JOIN (SELECT SP.MASP, SUM(CT.SL) as 'SOLUONG' FROM SANPHAM SP INNER JOIN CHITIETHOADON CT ON SP.MASP = CT.MASP INNER JOIN HOADON HD ON HD.MAHD = CT.MAHD WHERE HD.TGMUA >='" + start + "' AND HD.TGMUA <= '" + end + "' GROUP BY  SP.MASP) AS X ON X.MASP = SANPHAM.MASP ORDER BY SOLUONG DESC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ViewProductRanking product = new ViewProductRanking(item);
                list.Add(product);
            }
            return list;
        }

    }


}
