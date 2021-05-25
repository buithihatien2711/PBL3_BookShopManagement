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
        public DataTable GetNhatKiNhapKho_DAL(DateTime dateFrom, DateTime dateTo)
        {
            string query = string.Format("select * from NhatKiNhapSach where NgayNhap >= '{0}' and NgayNhap <= '{1}'", dateFrom, dateTo);
            return DBHelper.Instance.GetRecord(query);
        }
        public DataTable GetDoanhThuTheoNhanVien(DateTime dateFrom, DateTime dateTo)
        {
            string query = string.Format("select HoaDon.ID_Staff, Name_Staff, sum(TongTien) from HoaDon, Staff  " +
                "where HoaDon.ID_Staff = Staff.ID_Staff and NgayLap >= '{1}' and NgayLap <= '{2}' group by HoaDon.ID_Staff, Name_Staff ",
                dateFrom, dateTo);
            return DBHelper.Instance.GetRecord(query);
        }
        public DataTable GetDoanhThuTheoLoaiSach(DateTime dateFrom, DateTime dateTo)
        {

            return DBHelper.Instance.GetRecord();
        }
        public DataTable GetDoanhThuTheoLinhVuc(DateTime dateFrom, DateTime dateTo)
        {

        }
    }
}
