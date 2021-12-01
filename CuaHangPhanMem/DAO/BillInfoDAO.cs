using CuaHangPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillInfoDAO();
                return instance;
            }
            private set { instance = value; }
        }

        private BillInfoDAO() { }

        public void InsertBillInfo(int idBill, int idProduct, int sl)
        {
            DataProvider.Instance.ExecuteNoneQuery("exec USP_INSERTBILLINFO @idBill , @idProduct , @count ", new object[] { idBill, idProduct,sl });
        }

        public List<BillInfo> LoadAllBill()
        {
            List<BillInfo> list = new List<BillInfo>();
            string query = "SELECT [ID],[MAHD],[MASP],[SL] FROM[QUANLYBANHANG].[dbo].[CHITIETHOADON]";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BillInfo bill = new BillInfo(item);
                list.Add(bill);
            }
            return list;
        }
    }
}
