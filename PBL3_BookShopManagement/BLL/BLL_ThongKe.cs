using PBL3_BookShopManagement.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_BookShopManagement.BLL
{
    class BLL_ThongKe
    {
        private static BLL_ThongKe _Instance;
        public static BLL_ThongKe Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_ThongKe();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_ThongKe() { }
        public DataTable GetHoaDon_BLL(DateTime dateFrom, DateTime dateTo)
        {
            return DAL_ThongKe.Instance.GetHoaDon_DAL(dateFrom, dateTo);
        }
        public DataTable GetNhatKiNhapKho_BLL(DateTime dateFrom, DateTime dateTo)
        {
            return DAL_ThongKe.Instance.GetNhatKiNhapKho_DAL(dateFrom, dateTo);
        }
        public int GetSoLuongHoaDon_BLL()
        {
            return DAL_ThongKe.Instance.GetSoLuongHoaDon_DAL();
        }
        public decimal GetDoanhThu_BLL()
        {
            return DAL_ThongKe.Instance.GetDoanhThu_DAL();
        }
        public int GetSoLuongSachBan_BLL()
        {
            return DAL_ThongKe.Instance.GetSoLuongSachBan_DAL();
        }
    }
}
