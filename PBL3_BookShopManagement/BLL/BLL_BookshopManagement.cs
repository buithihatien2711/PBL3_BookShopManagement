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
        public List<StaffView> getAllStaffView_BLL()
        {
            List<StaffView> list = new List<StaffView>();
            foreach (DataRow i in DAL_BookshopManagement.Instance.getAllStaffView_DAL().Rows)
            {
                list.Add(new StaffView
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
                });
            }
            return list;
        }
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
        public StaffView GetStaffViewbyID(int id)
        {
            StaffView staffView = new StaffView();
            foreach(StaffView i in getAllStaffView_BLL())
            {
                if(i.ID_Staff == id)
                {
                    staffView = i;
                }
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
    }
}
