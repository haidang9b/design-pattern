using CuaHangPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.DAO
{
    public class BillDAO
    {
        
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return instance;
            }
            private set { instance = value; }
        }
        private BillDAO() { }
        public List<Bill> GetBills()
        {
            List<Bill> list = new List<Bill>();
            string query = "SELECT MAHD , MAKH, NVBAN, TGMUA , TONGTIEN FROM HOADON ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Bill bill = new Bill(item);
                list.Add(bill);
            }
            return list;
        }
        public int GetTotalMonney()
        {
            int money = 0;
            string query = "Select SUM(TONGTIEN) from HOADON";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            money = (int) data.Rows[0][0];
            return money;
           
        }

        public void Add(int id, string name)
        {
            string query = "INSERT HOADON(MAKH ,NVBAN ,TGMUA ,TONGTIEN) VALUES ( @makh , @nvban , @tgban , 0)";
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");

            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, name, sqlFormattedDate });

            // NOT USING PROCEDURE
            /*DataProvider.Instance.ExecuteNoneQuery("exec USP_INSERTBILL "+ id+" ,'"+name+"' " );*/
        }
        public int GetUncheckBillByIDCustomer(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM HOADON WHERE MAKH = @id AND STATUS = 0", new object[] { id});
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }

        public int getMaxID()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("Select max(mahd) from HOADON ");
            }
            catch
            {
                return 1;
            }
        }
        public bool PaytheBill(int idkh)
        {
            int oldTotalMoney = CustomerDAO.Instance.GetTotalMoneyByID(idkh);
            int idhd = GetIDBillNonePayment(idkh);
            
            string queryUpdateTotalMoney = " UPDATE KHACHHANG SET TONGTIEN = (SELECT SUM(DONGIA * SL) " +
                                            " FROM CHITIETHOADON CT " +
                                            " INNER JOIN SANPHAM SP ON SP.MASP = CT.MASP " +

                                            " WHERE CT.MAHD = @IDHD ) + @MONEY " +
                                            " WHERE MAKH = @IDKH ";
            DataProvider.Instance.ExecuteNoneQuery(queryUpdateTotalMoney, new object[] { idhd, oldTotalMoney, idkh });

            string updateBill = " UPDATE HOADON SET STATUS = 1, TONGTIEN  = (SELECT SUM(DONGIA*SL) " +
                " FROM CHITIETHOADON CT " +
                " INNER JOIN SANPHAM SP ON SP.MASP = CT.MASP " +
                " WHERE CT.MAHD = @IDHD ) " +
                " WHERE MAKH = @IDKH ";

            ReduceProductQuantity(idhd);
            int rs = DataProvider.Instance.ExecuteNoneQuery(updateBill, new object[] { idhd, idkh });


           /* string query = "EXEC PROC_THANHTOAN @idkh" ;
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idkh});*/
            return rs > 0;
        }

        public void ReduceProductQuantity(int idhd)
        {
            string queryMySQL = "UPDATE SANPHAM AS p INNER JOIN CHITIETHOADON AS op ON p.MASP = op.MASP SET p.SOLUONGTON = p.SOLUONGTON - op.SL WHERE op.MAHD = @MAHD ";
            string queryMMSQL = "UPDATE P SET SOLUONGTON = SOLUONGTON - CTHD.SL FROM SANPHAM P INNER JOIN CHITIETHOADON CTHD ON P.MASP = CTHD.MASP WHERE MAHD = @MAHD ";
            if (SaveDataStatic.typeServer == 1)
            {
                DataProvider.Instance.ExecuteNoneQuery(queryMMSQL, new object[] { idhd });
            }
            else
            {
                DataProvider.Instance.ExecuteNoneQuery(queryMySQL, new object[] { idhd });
            }

        }

        public int GetIDBillNonePayment(int makh)
        {
            string query = "SELECT MAHD FROM HOADON HD INNER JOIN KHACHHANG KH ON KH.MAKH = HD.MAKH WHERE HD.STATUS = 0 AND HD.MAKH = @makh ";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { makh});

            DataRow dataRow = dataTable.Rows[0];
            return (int)dataRow["MAHD"];

        }

        public List<Bill> getAllBillViewByTime(string start, string end)
        {
            List<Bill> list = new List<Bill>();
            string query = "SET DATEFORMAT DMY  SELECT* FROM HOADON WHERE HOADON.TGMUA >= @start AND HOADON.TGMUA <= @end ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { start, end});
            foreach (DataRow item in data.Rows)
            {
                Bill bill = new Bill(item);
                list.Add(bill);
            }
            return list;
        }
        public int getMoneyByTime(string start, string end)
        {
            try
            {
                string query = "SET DATEFORMAT DMY  SELECT Sum(TONGTIEN) FROM HOADON WHERE HOADON.TGMUA >= @start AND HOADON.TGMUA <= @end";
                int money = (int)DataProvider.Instance.ExecuteScalar(query, new object[] { start, end});
                return money;
            }
            catch
            {
                return 0;
            }
        }

        public List<ViewBill> getAllBillView()
        {
            List<ViewBill> list = new List<ViewBill>();
            string query = "SELECT * FROM BILLVIEW";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ViewBill product = new ViewBill(item);
                list.Add(product);
            }
            return list;
        }

        public List<ViewBill> getAllBillViewBySDT(string sdt)
        {
            List<ViewBill> list = new List<ViewBill>();
            string query = "SELECT * FROM BILLVIEW WHERE SDTKH LIKE @sdt";

            var data = DataProvider.Instance.ExecuteQuery(query, new object[] { "%"+sdt+"%"});
            foreach (DataRow item in data.Rows)
            {
                ViewBill product = new ViewBill(item);
                list.Add(product);
            }
            return list;
        }

        public List<ViewBillInfo> loadAllBillViewByIDHD(int idHD)
        {
            List<ViewBillInfo> list = new List<ViewBillInfo>();
            string query = "SELECT  TENSP, SL, DONGIA, DONGIA*SL AS'TONGGIA' FROM CHITIETHOADON CT INNER JOIN SANPHAM ON SANPHAM.MASP = CT.MASP INNER JOIN HOADON ON HOADON.MAHD = CT.MAHD INNER JOIN KHACHHANG ON HOADON.MAKH = KHACHHANG.MAKH AND HOADON.STATUS = 1 WHERE HOADON.MAHD = @idhd " ;
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idHD});
            foreach (DataRow item in data.Rows)
            {
                ViewBillInfo product = new ViewBillInfo(item);
                list.Add(product);
            }
            return list;
        }

        public List<ViewBillInfo> loadAllBillViewNonePay(int idkh)
        {
            List<ViewBillInfo> list = new List<ViewBillInfo>();
            string query = "SELECT  TENSP, SL, DONGIA, DONGIA*SL AS'TONGGIA' FROM CHITIETHOADON CT INNER JOIN SANPHAM ON SANPHAM.MASP = CT.MASP INNER JOIN HOADON ON HOADON.MAHD = CT.MAHD INNER JOIN KHACHHANG ON HOADON.MAKH = KHACHHANG.MAKH AND HOADON.STATUS = 0 WHERE KHACHHANG.MAKH = @idkh";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idkh });
            foreach (DataRow item in data.Rows)
            {
                ViewBillInfo product = new ViewBillInfo(item);
                list.Add(product);
            }
            return list;
        }


        public void InsertBillInfo(int idBill, int idProduct, int sl)
        {
            string query = "SELECT ID , SL  FROM CHITIETHOADON WHERE MAHD = @idhd AND MASP = @idsp";
            // check exist product in bill;
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idBill, idProduct });
            if (data.Rows.Count > 0)
            {
                DataRow dataRow = data.Rows[0];
                var countProduct = (int)dataRow["SL"];
                var IDCTHD = (int)dataRow["ID"];
                var newCount = countProduct + sl;
                // new count product = old + new;
                if (newCount > 0)
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
                if (sl <= 0)
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

    }
}
