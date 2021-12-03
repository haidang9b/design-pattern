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
            string query = "SELECT ID , SL  FROM CHITIETHOADON WHERE MAHD = @idhd AND MASP = @idsp";
            // check exist product in bill;
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idBill, idProduct});
            if(data.Rows.Count > 0)
            {
                DataRow dataRow = data.Rows[0];
                var countProduct = (int)dataRow["SL"];
                var IDCTHD = (int)dataRow["ID"];
                var newCount = countProduct + sl;
                // new count product = old + new;
                if(newCount > 0)
                {
                    string queryUpdate = "UPDATE CHITIETHOADON SET SL = @NEWCOUNT WHERE MAHD = @idBill AND @idProduct =MASP";
                    DataProvider.Instance.ExecuteNoneQuery(queryUpdate, new object[] { newCount, idBill, idProduct });
                }
                else
                {
                    // if <= 0  remove; 
                    string queryDelete = "DELETE CHITIETHOADON WHERE MAHD = @idBill AND @idProduct =MASP";
                    DataProvider.Instance.ExecuteNoneQuery(queryDelete, new object[] { idBill, idProduct });
                }
            }
            else
            {
                if(sl <= 0)
                {
                    return;
                }
                // add item to bill
                string queryNew = "INSERT INTO CHITIETHOADON(MAHD,MASP,SL) VALUES( @idBill , @idProduct , @count )";
                DataProvider.Instance.ExecuteNoneQuery(queryNew, new object[] { idBill, idProduct, sl });
            }
            // NOT USING PROCEDURE
            /*DataProvider.Instance.ExecuteNoneQuery("exec USP_INSERTBILLINFO @idBill , @idProduct , @count ", new object[] { idBill, idProduct,sl });*/
        }

        public List<BillInfo> LoadAllBill()
        {
            List<BillInfo> list = new List<BillInfo>();
            string query = "SELECT ID,MAHD,MASP,SL FROM CHITIETHOADON";
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
