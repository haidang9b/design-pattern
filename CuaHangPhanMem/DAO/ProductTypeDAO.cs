using CuaHangPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DAO
{
    public class ProductTypeDAO
    {
        private static ProductTypeDAO instance;
        public static ProductTypeDAO Instance 
        {
            get
            {
                if (instance == null)
                    instance = new ProductTypeDAO();
                return instance;
            }
            set => instance = value; 
        }
        private ProductTypeDAO() { }
        //LOAD DATA
        public List<ProductType> LoadAllProductType()
        {
            List<ProductType> list = new List<ProductType>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT MALOAI, TENLOAI FROM LOAISP");
            foreach (DataRow item in data.Rows)
            {
                ProductType product = new ProductType(item);
                list.Add(product);
            }
            return list;
        }
        // THEM LOAI SAN PHAM
        public bool Add(string name)
        {
            string query = "INSERT INTO LOAISP(TENLOAI) VALUES( @name )";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name});
            return rs>0;
        }
        
        // XOA LOAI SAN PHAM
        public bool Delete(int id)
        {
            string query = "DELETE FROM LOAISP WHERE MALOAI = @id";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id});
            return rs > 0;
        }
        // SUA LOAI SAN PHAM
        public bool Update(int id, string name)
        {
            string query = "UPDATE LOAISP SET TENLOAI= @name WHERE MALOAI = @id ";
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name, id});
            return rs > 0;
        }
        public List<ProductType> searchItem(string name)
        {
            List<ProductType> list = new List<ProductType>();
            string query = "SELECT * FROM LOAISP WHERE TENLOAI LIKE @name ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { "%"+name+"%"});
            foreach (DataRow item in data.Rows)
            {
                ProductType product = new ProductType(item);
                list.Add(product);
            }
            return list;
        }

    }
}
