using PBL3_BookShopManagement.DAL;
using PBL3_BookShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_BookShopManagement.BLL
{
    class BLL_BookshopManagement
    {
        private static BLL_BookshopManagement _Instance;

        public static BLL_BookshopManagement Instance 
        {
            get  
            { 
                if(_Instance == null)
                {
                    _Instance = new BLL_BookshopManagement();
                }
                return _Instance;
            }
            private set { }
        }
        public List<Staff> getAllSatff_BLL()
        {
            List<Staff> list = new List<Staff>();
            foreach (DataRow i in DAL_BookshopManagement.Instance.getAllStaff_DAL().Rows)
            {
                list.Add(new Staff
                {
                    ID_Staff = Convert.ToInt32(i["ID_Staff"]),
                    Name_Staff = i["Name_Staff"].ToString(),
                    Gender = Convert.ToBoolean(i["Gender"]),
                    DateOfBirth = Convert.ToDateTime(i["DateOfBirth"]),
                    Address = i["Address"].ToString(),
                    ID_User = Convert.ToInt32(i["ID_User"])
                });
            }
            return list;
        }

        //public List<StaffView> getAllStaffView_BLL()
        //{
        //    List<StaffView> list = new List<StaffView>();
        //    foreach (DataRow i in DAL_BookshopManagement.Instance.getAllStaffView_DAL().Rows)
        //    {
        //        list.Add(new StaffView
        //        {
        //            ID_Staff = Convert.ToInt32(i["ID_Staff"]),
        //            Name_Staff = i["Name_Staff"].ToString(),
        //            Gender = Convert.ToBoolean(i["Gender"]),
        //            DateOfBirth = Convert.ToDateTime(i["DateOfBirth"]),
        //            Address = i["Address"].ToString(),
        //            ID_User = Convert.ToInt32(i["ID_User"]),
        //            UserName = i["UserName"].ToString(),
        //            Password = i["Password"].ToString(),
        //            NamePosition = i["NamePosition"].ToString()
        //        });
        //    }
        //    return list;
        //}
        public List<CBBItem> getListCBBPosition()
        {
            List<CBBItem> list = new List<CBBItem>();
            foreach(DataRow i in DAL_BookshopManagement.Instance.getAllPosition_DAL().Rows)
            {
                list.Add(new CBBItem { Value = Convert.ToInt32(i["ID_Position"]), Text = i["NamePosition"].ToString() });
            }
            return list;
        }

        //public List<Position> getAllPosition_BLL()
        //{
        //    List<Position> list = new List<Position>();
        //    foreach(DataRow i in DAL_BookshopManagement.Instance.getAllPosition_DAL().Rows)
        //    {
        //        list.Add(new Position { ID_Position = Convert.ToInt32(i["ID_Position"]), NamePosition = i["NamePosition"].ToString() });
        //    }
        //    return list;
        //}
        public void AddStaff_BLL(Staff staff, Account account)
        {
            DAL_BookshopManagement.Instance.AddStaff_DAL(staff, account);
        }
        public void UpdateStaff_BLL(Staff staff, Account account)
        {
            DAL_BookshopManagement.Instance.UpdateStaff_DAL(staff, account);
        }
        public StaffView GetStaffView(DataRow i)
        {
            return new StaffView
            {
                ID_Staff = Convert.ToInt32(i["ID_Staff"]),
                Name_Staff = i["Name_Staff"].ToString(),
                Gender = Convert.ToBoolean(i["Gender"]),
                DateOfBirth = Convert.ToDateTime(i["DateOfBirth"]),
                Address = i["Address"].ToString(),
                ID_User = Convert.ToInt32(i["ID_User"]),
                UserName = i["UserName"].ToString(),
                Password = i["Password"].ToString(),
                NamePosition = i["NamePosition"].ToString()
            };
        }
        public StaffView GetStaffViewbyID(int id)
        {
            StaffView staffView = new StaffView();
            foreach(StaffView i in GetListStaffView_BLL(null, 0))
            {
                staffView = i;
            }
            return staffView;
        }
        public Staff GetStaffbyID(int id)
        {
            Staff staff = new Staff();
            foreach (Staff i in getAllSatff_BLL())
            {
                if (i.ID_Staff == id)
                {
                    staff = i;
                }
            }
            return staff;
        }
        public List<Account> GetAllAcount_BLL()
        {
            List<Account> list = new List<Account>();
            foreach (DataRow i in DAL_BookshopManagement.Instance.GetAllAcount_DAL().Rows)
            {
                list.Add(new Account
                {
                    ID_User = Convert.ToInt32(i["ID_User"]),
                    UserName = i["UserName"].ToString(),
                    Password = i["Password"].ToString(),
                    ID_Position = Convert.ToInt32(i["ID_Position"])
                });
            }
            return list;
        }
        public Account GetAccountbyID(int id)
        {
            Account account = new Account();
            foreach(Account i in GetAllAcount_BLL())
            {
                if(i.ID_User == id)
                {
                    account = i;
                }
            }
            return account;
        }
        public bool Excute(int IDStaff)
        {
            bool check = false;
            foreach(Staff i in getAllSatff_BLL())
            {
                if (i.ID_Staff == IDStaff) check = true;
            }
            return check;
        }
        public void DelStaff_BLL(List<string> listIDStaff) 
        {
            foreach(string i in listIDStaff)
            {
                DAL_BookshopManagement.Instance.DeleteStaff_DAL(i);
            }
        }
        public List<StaffView> GetListStaffView_BLL(string name, int idPos)
        {
            List<StaffView> list = new List<StaffView>();
            //DataTable dt = new DataTable();
            if (idPos == 0)
            {

                foreach(DataRow i in DAL_BookshopManagement.Instance.GetListStaffViewbyName_DAL(name).Rows)
                {
                    list.Add(GetStaffView(i));
                }
            }
            else
            {
                foreach (DataRow i in DAL_BookshopManagement.Instance.GetListStaffViewbyIDPos_DAL(idPos, name).Rows)
                {
                    list.Add(GetStaffView(i));
                }
            }
            return list;

            //if(dt != null)
            //{
            //    List<StaffView> list = new List<StaffView>();
            //    foreach (DataRow i in dt.Rows)
            //    {
            //        list.Add(new StaffView
            //        {
            //            ID_Staff = Convert.ToInt32(i["ID_Staff"]),
            //            Name_Staff = i["Name_Staff"].ToString(),
            //            Gender = Convert.ToBoolean(i["Gender"]),
            //            DateOfBirth = Convert.ToDateTime(i["DateOfBirth"]),
            //            Address = i["Address"].ToString(),
            //            ID_User = Convert.ToInt32(i["ID_User"]),
            //            UserName = i["UserName"].ToString(),
            //            Password = i["Password"].ToString(),
            //            NamePosition = i["NamePosition"].ToString()
            //        });
            //    }
            //    return list;
            //}
            //else
            //{
            //    return null;
            //}
        }
        //public List<StaffView> SortStaff(List<StaffView> list)
        //{
        //    List<StaffView> listSort = new List<StaffView>();

        //}
        public SachView GetSachView(DataRow i)
        {
            return new SachView
            {
                MaSach = Convert.ToInt32(i["MaSach"]),
                TenSach = i["TenSach"].ToString(),
                GiaMua = Convert.ToInt32(i["GiaMua"]),
                TenLoaiSach = i["TenLoaiSach"].ToString(),
                TenTacGia = i["TenTacGia"].ToString(),
                TenLinhVuc = i["TenLinhVuc"].ToString(),
                LanTaiBan = i["LanTaiBan"].ToString(),
                NamXuatBan = i["NamXuatBan"].ToString(),
                GiaBia = Convert.ToInt32(i["GiaBia"]),  
            };
        }
        List<SachView> getListSachView(string name, string TheLoai, string LoaiSach)
        {
            if((TheLoai == null) && (LoaiSach == null))
            {
                //code
                DAL_BookshopManagement.Instance.getAllSachViewbyName_DAL(name);
            }
            else
            {
                if (LoaiSach == null)
                {
                    DAL_BookshopManagement.Instance.getAllSachViewbyTheLoai_DAL(TheLoai, name);
                }
                else
                {
                    DAL_BookshopManagement.Instance.getAllSachViewbyLoaiSach_DAL(LoaiSach, TheLoai, name);
                }
            }
        }
    }
}
