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
            DataProvider.Instance.ExecuteNoneQuery("exec USP_INSERTBILL "+ id+" ,'"+name+"' " );
        }
        public int GetUncheckBillByIDCustomer(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM HOADON WHERE MAKH= @id AND STATUS = 0", new object[] { id});
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
            string query = "EXEC PROC_THANHTOAN @idkh" ;
            int rs = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idkh});
            return rs > 0;
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

    }
}
