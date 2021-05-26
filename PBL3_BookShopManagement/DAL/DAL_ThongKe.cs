using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_BookShopManagement.DAL
{
    class DAL_ThongKe
    {
        private static DAL_ThongKe _Instance;
        public static DAL_ThongKe Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_ThongKe();
                }
                return _Instance;
            }
            private set { }
        }
        private DAL_ThongKe() { }

        public int GetSoLuongHoaDon_DAL()
        {
            int SoHoaDon = 0;
            foreach(DataRow i in DBHelper.Instance.GetRecord("select count(MaHoaDon) from HoaDon").Rows)
            {
                SoHoaDon = Convert.ToInt32(i[0]);
            }
            return SoHoaDon;
        }
        public decimal GetDoanhThu_DAL()
        {
            int DoanhThu = 0;
            foreach(DataRow i in DBHelper.Instance.GetRecord("select sum(TongTien) from HoaDon").Rows)
            {
                DoanhThu = Convert.ToInt32(i[0]);
            }
            return DoanhThu;
        }
        public int GetSoLuongSachBan_DAL()
        {
            int SoSach = 0;
            foreach (DataRow i in DBHelper.Instance.GetRecord("select sum(SoLuong) from ChiTietHoaDon").Rows)
            {
                SoSach = Convert.ToInt32(i[0]);
            }
            return SoSach;
        }
        public DataTable GetHoaDon_DAL(DateTime dateFrom, DateTime dateTo)
        {
            string query = string.Format("select * from HoaDon where NgayLap >= '{0}' and NgayLap <= '{1}'", dateFrom, dateTo);
            return DBHelper.Instance.GetRecord(query);
        }
        public DataTable GetDoanhThuTheoNhanVien_DAL(DateTime dateFrom, DateTime dateTo)
        {
            string query = string.Format("select HoaDon.ID_Staff, Name_Staff, sum(TongTien) from HoaDon, Staff  " +
                "where HoaDon.ID_Staff = Staff.ID_Staff and NgayLap >= '{0}' and NgayLap <= '{1}' group by HoaDon.ID_Staff, Name_Staff ",
                dateFrom, dateTo);
            return DBHelper.Instance.GetRecord(query);
        }
        public DataTable GetDoanhThuTheoTenSach_DAL(DateTime dateFrom, DateTime dateTo)
        {
            string query = string.Format("select truyvan.MaSach, TenSach, TongTienBan " +
                "from (select truyvancon.MaSach, Sum(TienBan) as TongTienBan " +
                "from (select ChiTietHoaDon.MaSach, GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong as TienBan " +
                "from ChiTietHoaDon, ThongTinXuatBan, HoaDon where ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach and NgayLap >= '{0}' " +
                "and NgayLap <= '{1}' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon) truyvancon group by truyvancon.MaSach) truyvan, " +
                "Sach where truyvan.MaSach = Sach.MaSach", dateFrom, dateTo);
            return DBHelper.Instance.GetRecord(query);
        }
        public DataTable GetDoanhThuTheoLoaiSach_DAL(DateTime dateFrom, DateTime dateTo)
        {
            string query = string.Format("select TenLoaiSach, sum(TienBan) as TongTien from(select TenLoaiSach, TienBan " +
                "from (select ChiTietHoaDon.MaSach, GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong as TienBan " +
                "from ChiTietHoaDon, ThongTinXuatBan, HoaDon where ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach and NgayLap >= '{0}' " +
                "and NgayLap <= '{1}' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon)  truyvancon, Sach where Sach.MaSach = truyvancon.MaSach) " +
                "truyvan2 group by TenLoaiSach", dateFrom, dateTo);
            return DBHelper.Instance.GetRecord(query);
        }
        public DataTable GetDoanhThuTheoLinhVuc_DAL(DateTime dateFrom, DateTime dateTo)
        {
            string query = string.Format("select TenLinhVuc, sum(TienBan) as TongTien from(select TenLinhVuc, TienBan " +
                "from (select ChiTietHoaDon.MaSach, GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong as TienBan " +
                "from ChiTietHoaDon, ThongTinXuatBan, HoaDon where ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach " +
                "and NgayLap >= '{0}' and NgayLap <= '{1}' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon) truyvancon, " +
                "Sach where Sach.MaSach = truyvancon.MaSach) truyvan2 group by TenLinhVuc", dateFrom, dateTo);
            return DBHelper.Instance.GetRecord(query);
        }
        public decimal GetChiPhi_DAL()
        {
            int DoanhThu = 0;
            foreach (DataRow i in DBHelper.Instance.GetRecord("select sum(TongTien) from HoaDon").Rows)
            {
                DoanhThu = Convert.ToInt32(i[0]);
            }
            return DoanhThu;
        }
        public int GetSoLuongSachMua_DAL()
        {
            int SoSach = 0;
            foreach (DataRow i in DBHelper.Instance.GetRecord("select sum(SoLuong) from ChiTietHoaDon").Rows)
            {
                SoSach = Convert.ToInt32(i[0]);
            }
            return SoSach;
        }
        public DataTable GetNhatKiNhapKho_DAL(DateTime dateFrom, DateTime dateTo)
        {
            string query = string.Format("select * from NhatKiNhapSach where NgayNhap >= '{0}' and NgayNhap <= '{1}'", dateFrom, dateTo);
            return DBHelper.Instance.GetRecord(query);
        }
        public DataTable GetChiPhiTheoNhanVien_DAL(DateTime dateFrom, DateTime dateTo)
        {
            string query = string.Format("select HoaDon.ID_Staff, Name_Staff, sum(TongTien) from HoaDon, Staff  " +
                "where HoaDon.ID_Staff = Staff.ID_Staff and NgayLap >= '{0}' and NgayLap <= '{1}' group by HoaDon.ID_Staff, Name_Staff ",
                dateFrom, dateTo);
            return DBHelper.Instance.GetRecord(query);
        }
        public DataTable GetChiPhiTheoTenSach_DAL(DateTime dateFrom, DateTime dateTo)
        {
            string query = string.Format("select truyvan.MaSach, TenSach, TongTienBan " +
                "from (select truyvancon.MaSach, Sum(TienBan) as TongTienBan " +
                "from (select ChiTietHoaDon.MaSach, GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong as TienBan " +
                "from ChiTietHoaDon, ThongTinXuatBan, HoaDon where ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach and NgayLap >= '{0}' " +
                "and NgayLap <= '{1}' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon) truyvancon group by truyvancon.MaSach) truyvan, " +
                "Sach where truyvan.MaSach = Sach.MaSach", dateFrom, dateTo);
            return DBHelper.Instance.GetRecord(query);
        }
        public DataTable GetChiPhiTheoLoaiSach_DAL(DateTime dateFrom, DateTime dateTo)
        {
            string query = string.Format("select TenLoaiSach, sum(TienBan) as TongTien from(select TenLoaiSach, TienBan " +
                "from (select ChiTietHoaDon.MaSach, GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong as TienBan " +
                "from ChiTietHoaDon, ThongTinXuatBan, HoaDon where ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach and NgayLap >= '{0}' " +
                "and NgayLap <= '{1}' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon)  truyvancon, Sach where Sach.MaSach = truyvancon.MaSach) " +
                "truyvan2 group by TenLoaiSach", dateFrom, dateTo);
            return DBHelper.Instance.GetRecord(query);
        }
        public DataTable GetChiPhiTheoLinhVuc_DAL(DateTime dateFrom, DateTime dateTo)
        {
            string query = string.Format("select TenLinhVuc, sum(TienBan) as TongTien from(select TenLinhVuc, TienBan " +
                "from (select ChiTietHoaDon.MaSach, GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong as TienBan " +
                "from ChiTietHoaDon, ThongTinXuatBan, HoaDon where ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach " +
                "and NgayLap >= '{0}' and NgayLap <= '{1}' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon) truyvancon, " +
                "Sach where Sach.MaSach = truyvancon.MaSach) truyvan2 group by TenLinhVuc", dateFrom, dateTo);
            return DBHelper.Instance.GetRecord(query);
        }
    }
}
