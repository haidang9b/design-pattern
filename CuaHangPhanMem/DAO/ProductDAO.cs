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
        public List<Product> GetProducts()
        {
            List<Product> list = new List<Product>();
            string query = "SELECT * FROM SANPHAM";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                list.Add(product);
            }
            return list;
        }
        public List<Product> GetByProductTypeID(int id)
        {
            List<Product> list = new List<Product>();
            string query = "SELECT * FROM SANPHAM Where LOAISP = @id ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id});
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                list.Add(product);
            }
            return list;
        }
        // XOA SAN PHAM
        public bool Delete(int id)
        {
            string query = "DELETE FROM SANPHAM WHERE MASP = @id" ;
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id });
            return rs > 0;
        }
        // SUA SAN PHAM

        public bool Update(Product update) 
        {
            string query = "UPDATE SANPHAM SET TENSP = @tensp , LOAISP = @loaisp ,SOLUONGTON = @slt , DONGIA = @dongia WHERE MASP = @id " ;
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { update.Name, update.TypeProduct, update.AmountProduct, update.Price, update.ID});
            return rs > 0;
        }


        // THEM SAN PHAM
        public bool Add(Product product)
        {
            string query = "INSERT INTO SANPHAM (TENSP, LOAISP, SOLUONGTON, DONGIA) VALUES ( @name , @maloai , @slt , @price )";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { product.Name, product.TypeProduct, product.AmountProduct, product.Price});
            return rs>0;
        }
        // TIM KIEM SAN PHAM

        public List<Product> searchItem(string name)
        {
            List<Product> list = new List<Product>();
            string query = "SELECT * FROM SANPHAM WHERE TENSP LIKE @name ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { "%"+name+"%"});
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
            string query = "SET DATEFORMAT DMY  SELECT SANPHAM.MASP, SANPHAM.TENSP,SOLUONG, SANPHAM.DONGIA, SOLUONG*SANPHAM.DONGIA AS'TONGTIEN' FROM SANPHAM INNER JOIN (SELECT SP.MASP, SUM(CT.SL) as 'SOLUONG' FROM SANPHAM SP INNER JOIN CHITIETHOADON CT ON SP.MASP = CT.MASP INNER JOIN HOADON HD ON HD.MAHD = CT.MAHD WHERE HD.TGMUA >= @start AND HD.TGMUA <= @end GROUP BY  SP.MASP) AS X ON X.MASP = SANPHAM.MASP ORDER BY SOLUONG DESC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { start, end});
            foreach (DataRow item in data.Rows)
            {
                ViewProductRanking product = new ViewProductRanking(item);
                list.Add(product);
            }
            return list;
        }

    }


}
