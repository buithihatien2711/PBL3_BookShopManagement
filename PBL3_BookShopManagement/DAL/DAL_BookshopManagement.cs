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

        public DataTable getAllStaffView_DAL()
        {
            string query = "select Staff.ID_Staff, Name_Staff, Gender, DateOfBirth, Address, Account.ID_User, UserName, Password, NamePosition " +
                             "from Staff, Account, Position where Staff.ID_User = Account.ID_User and Account.ID_Position = Position.ID_Position";
            return DBHelper.Instance.GetRecord(query);
        }
        public DataTable getAllPosition_DAL()
        {
            return DBHelper.Instance.GetRecord("select * from Position");
        }
        public void AddStaff_DAL(Staff staff, Account account)
        {
            string query_insertAccount = "insert into Account values ('" + account.UserName + "', '" + account.Password + "', " + account.ID_Position.ToString() + ")";
            DBHelper.Instance.ExcuteDB(query_insertAccount);

            string query = "SELECT TOP 1 ID_User FROM Account ORDER BY ID_User DESC";

            // DataTable dt = DBHelper.Instance.GetRecord(query);

            int id_user = -1;
            foreach (DataRow i in DBHelper.Instance.GetRecord(query).Rows)
            {
                id_user = Convert.ToInt32(i[0]);
            }

            string query_insertStaff = "insert into Staff values ('" + staff.Name_Staff + "' , '"
                            + staff.Gender.ToString() + "', '" + staff.DateOfBirth.ToString() + "', '" + staff.Address + "', " + id_user.ToString() + ")";
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
    }
}
