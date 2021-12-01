using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhanMem.Factory
{
    public enum SubFormType
    {
        KhachHang,
        Account,
        BanHang,
        InfoApp,
        LoaiSP,
        SanPham,
        TaiChinh,
        ThongKeSP,
        TimKiemDonHang,
        Home
    }
    public class FactorySubForm
    {
        private static FactorySubForm instance;
        public static FactorySubForm Instance
        {
            get
            {
                if (instance == null)
                    instance = new FactorySubForm();
                return instance;
            }
            private set { instance = value; }
        }
        private FactorySubForm() { }
        public Form CreateSubForm(SubFormType type, string tk=null)
        {
            switch (type)
            {
                case SubFormType.KhachHang:
                    return new frKhachHang();
                case SubFormType.Account:
                    return new frmAccount();
                case SubFormType.BanHang:
                    return new frmBanHang(tk);
                case SubFormType.InfoApp:
                    return new frmInfoApp();
                case SubFormType.LoaiSP:
                    return new frmLoaiSP();
                case SubFormType.SanPham:
                    return new frmSanPham();
                case SubFormType.TaiChinh:
                    return new frmTaiChinh();
                case SubFormType.ThongKeSP:
                    return new frmThongKeSP();
                case SubFormType.TimKiemDonHang:
                    return new frmTimKiemDonHang();
                case SubFormType.Home:
                    return new fromHome();
            }
            return null;
        }
    }
}
