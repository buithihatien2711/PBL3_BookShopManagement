using PBL3_BookShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_BookShopManagement.DAL
{
    class DAL_BookshopManagement
    {
        private static DAL_BookshopManagement _Instance;

        public static DAL_BookshopManagement Instance 
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new DAL_BookshopManagement();
                }
                return _Instance;
            }
            private set { }
        }

        public DataTable getAllStaff_DAL()
        {
            return DBHelper.Instance.GetRecord("select * from Staff");
        }

        //public DataTable getAllStaffView_DAL()
        //{
        //    string query = "select Staff.ID_Staff, Name_Staff, Gender, DateOfBirth, Address, Account.ID_User, UserName, Password, NamePosition " +
        //                     "from Staff, Account, Position where Staff.ID_User = Account.ID_User and Account.ID_Position = Position.ID_Position";
        //    return DBHelper.Instance.GetRecord(query);
        //}
        public DataTable getAllPosition_DAL()
        {
            return DBHelper.Instance.GetRecord("select * from Position");
        }
        public void AddStaff_DAL(Staff staff, Account account)
        {
            string query_insertAccount = string.Format("insert into Account values ( N'{0}',  N'{1}', {2})", 
                account.UserName, account.Password, account.ID_Position);
                //"insert into Account values ('" + account.UserName + "', '" + account.Password + "', " + account.ID_Position.ToString() + ")";
            DBHelper.Instance.ExcuteDB(query_insertAccount);

            string query = "SELECT TOP 1 ID_User FROM Account ORDER BY ID_User DESC";

            // DataTable dt = DBHelper.Instance.GetRecord(query);

            int id_user = -1;
            foreach (DataRow i in DBHelper.Instance.GetRecord(query).Rows)
            {
                id_user = Convert.ToInt32(i[0]);
            }

            string query_insertStaff = "insert into Staff values ('" + staff.Name_Staff + "' , '" +  staff.Gender.ToString() 
                + "', '" + staff.DateOfBirth.ToString() + "', '" + staff.Address + "', " + id_user.ToString() + ")";
            DBHelper.Instance.ExcuteDB(query_insertStaff);
        }
        public void UpdateStaff_DAL(Staff staff, Account account)
        {
            string query_updateAccount = "update Account set UserName = '" + account.UserName + "', Password = '" + account.Password + "', ID_Position = " + account.ID_Position.ToString() + " where ID_User =" + account.ID_User.ToString();
            DBHelper.Instance.ExcuteDB(query_updateAccount);
            string query_UpdateStaff = "update Staff set Name_Staff = '" + staff.Name_Staff + "', Gender = '" + staff.Gender.ToString() + "', DateOfBirth = '"
                + staff.DateOfBirth.ToString() + "', Address = '" + staff.Address + "' where ID_Staff = " + staff.ID_Staff.ToString();
            DBHelper.Instance.ExcuteDB(query_UpdateStaff);
        }
        public DataTable GetAllAcount_DAL()
        {
            string query = "select * from Account";
            return DBHelper.Instance.GetRecord(query);
        }
        public void DeleteStaff_DAL(string IDStaff)
        {
            string query = "select ID_User from Staff where ID_Staff = " + IDStaff;
            DataTable dt = DBHelper.Instance.GetRecord(query);
            int IDUser = -1;
            foreach(DataRow i in dt.Rows)
            {
                IDUser = Convert.ToInt32(i["ID_User"]);
            }

            string query_DelStaff  = "delete from Staff where ID_Staff = " + IDStaff;
            DBHelper.Instance.ExcuteDB(query_DelStaff);

            string query_DelAccount = "delete from Account where ID_User = " + IDUser;
            DBHelper.Instance.ExcuteDB(query_DelAccount);
        }
        public DataTable GetListStaffViewbyName_DAL(string name)
        {
            DataTable dt = new DataTable();
            if (name == null)
            {
                string query = "select Staff.ID_Staff, Name_Staff, Gender, DateOfBirth, Address, Account.ID_User, UserName, Password, NamePosition " +
                                 "from Staff, Account, Position where Staff.ID_User = Account.ID_User and Account.ID_Position = Position.ID_Position";
                return DBHelper.Instance.GetRecord(query);
            }
            else
            {
                string query = "select Staff.ID_Staff, Name_Staff, Gender, DateOfBirth, Address, Account.ID_User, UserName, Password, NamePosition " +
                             "from Staff, Account, Position where Staff.ID_User = Account.ID_User and Account.ID_Position = Position.ID_Position and Name_Staff = '" + name + "'";
                return DBHelper.Instance.GetRecord(query);
            }
        }
        public DataTable GetListStaffViewbyIDPos_DAL(int idPos, string name)
        {
            if(idPos == 0)
            {
                return GetListStaffViewbyName_DAL(name);
            }
            else
            {
                if(name == null)
                {
                    string query = "select Staff.ID_Staff, Name_Staff, Gender, DateOfBirth, Address, Account.ID_User, UserName, Password, NamePosition " +
                     "from Staff, Account, Position where Staff.ID_User = Account.ID_User and Account.ID_Position = Position.ID_Position " +
                     " and Account.ID_Position = " + idPos.ToString();
                    return DBHelper.Instance.GetRecord(query);
                }
                else
                {
                    string query = "select Staff.ID_Staff, Name_Staff, Gender, DateOfBirth, Address, Account.ID_User, UserName, Password, NamePosition " +
                     "from Staff, Account, Position where Staff.ID_User = Account.ID_User and Account.ID_Position = Position.ID_Position " +
                     " Name_Staff = '" + name +  "' and Account.ID_Position = " + idPos.ToString();
                    return DBHelper.Instance.GetRecord(query);
                }
                
            }
        }
        public DataTable getAllSach_DAL()
        {
            return DBHelper.Instance.GetRecord("select * from Sach");
        }
        public DataTable getAllThongTinXB()
        {
            return DBHelper.Instance.GetRecord("select * from ThongTinXuatBan");
        }
        public DataTable getAllSachViewbyName_DAL(string name)
        {
            if(name == null)
            {
                return DBHelper.Instance.GetRecord("select Sach.MaSach, TenSach, GiaMua, TenLoaiSach, TenTacGia, TenLinhVuc, LanTaiBan, NamXuatBan, NhaXuatBan, GiaBia " +
                 "from Sach, ThongTinXuatBan where Sach.MaSach = Sach.ThongTinXuatBan ");
            }
            else
            {
                string query = "select Sach.MaSach, TenSach, GiaMua, TenLoaiSach, TenTacGia, TenLinhVuc, LanTaiBan, NamXuatBan, NhaXuatBan, GiaBia " +
                 "from Sach, ThongTinXuatBan where Sach.MaSach = Sach.ThongTinXuatBan and Name = '" + name + "'";
                return DBHelper.Instance.GetRecord(query);
            }
        }
        public DataTable getAllSachViewbyTheLoai_DAL(string TheLoai, string name)
        {
            if(TheLoai == "All")
            {
                return getAllSachViewbyName_DAL(name);
            }
            else
            {
                if(name == null)
                {
                    string query = "select Sach.MaSach, TenSach, GiaMua, TenLoaiSach, TenTacGia, TenLinhVuc, LanTaiBan, NamXuatBan, NhaXuatBan, GiaBia " +
                         "from Sach, ThongTinXuatBan where Sach.MaSach = Sach.ThongTinXuatBan and TheLoai = '" + TheLoai + "'";
                    return DBHelper.Instance.GetRecord(query);
                }
                else
                {
                    string query = "select Sach.MaSach, TenSach, GiaMua, TenLoaiSach, TenTacGia, TenLinhVuc, LanTaiBan, NamXuatBan, NhaXuatBan, GiaBia " +
                        "from Sach, ThongTinXuatBan where Sach.MaSach = Sach.ThongTinXuatBan and Name = '" + name + "' and TheLoai = '" + TheLoai + "'";
                    return DBHelper.Instance.GetRecord(query);
                }
            }
        }
        public DataTable getAllSachViewbyLoaiSach_DAL(string LoaiSach, string TheLoai, string name)
        {
            if(name == null)
            {
                if(TheLoai == null)
                {
                    string query = "select Sach.MaSach, TenSach, GiaMua, TenLoaiSach, TenTacGia, TenLinhVuc, LanTaiBan, NamXuatBan, NhaXuatBan, GiaBia " +
                         "from Sach, ThongTinXuatBan where Sach.MaSach = Sach.ThongTinXuatBan and LoaiSach = '" + LoaiSach + "'";
                    return DBHelper.Instance.GetRecord(query);
                }
                else
                {
                    string query = "select Sach.MaSach, TenSach, GiaMua, TenLoaiSach, TenTacGia, TenLinhVuc, LanTaiBan, NamXuatBan, NhaXuatBan, GiaBia " +
                         "from Sach, ThongTinXuatBan where Sach.MaSach = Sach.ThongTinXuatBan and LoaiSach = '" + LoaiSach + "' and TheLoai = '" + TheLoai + "'";
                    return DBHelper.Instance.GetRecord(query);
                }
            }
            else
            {
                if (TheLoai == null)
                {
                    string query = "select Sach.MaSach, TenSach, GiaMua, TenLoaiSach, TenTacGia, TenLinhVuc, LanTaiBan, NamXuatBan, NhaXuatBan, GiaBia " +
                         "from Sach, ThongTinXuatBan where Sach.MaSach = Sach.ThongTinXuatBan and LoaiSach = '" + LoaiSach + "' and TenSach = '" + name + "'";
                    return DBHelper.Instance.GetRecord(query);
                }
                else
                {
                    string query = "select Sach.MaSach, TenSach, GiaMua, TenLoaiSach, TenTacGia, TenLinhVuc, LanTaiBan, NamXuatBan, NhaXuatBan, GiaBia " 
                         + "from Sach, ThongTinXuatBan where Sach.MaSach = Sach.ThongTinXuatBan and LoaiSach = '" + LoaiSach 
                         + "' and TenSach = '" + name + "'" + "' and TheLoai = '" + TheLoai + "'";
                    return DBHelper.Instance.GetRecord(query);
                }
            }
        }
    }
}
