using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_BookShopManagement.DAL;
using PBL3_BookShopManagement.BLL;
using PBL3_BookShopManagement.DTO;

namespace PBL3_BookShopManagement.GUI.UserControls
{
    public partial class UC_ManageUser : UserControl
    {
        public UC_ManageUser()
        {
            InitializeComponent();
            GetCBB(cbbRole);
            txtSearchName.ForeColor = Color.LightGray;
            txtSearchName.Text = "Enter Name Staff";
            txtSearchName.Leave += new System.EventHandler(this.txtSearchName_Leave);
            txtSearchName.Enter += new System.EventHandler(this.txtSearchName_Enter);


        }

        private void txtSearchName_Leave(object sender, EventArgs e)
        {
            if(txtSearchName.Text == "")
            {
                txtSearchName.Text = "Enter Name Staff";
                txtSearchName.ForeColor = Color.Gray;
            }
        }

        private void txtSearchName_Enter(object sender, EventArgs e)
        {
            if(txtSearchName.Text == "Enter Name Staff")
            {
                txtSearchName.Text = "";
                txtSearchName.ForeColor = Color.Black;
            }
        }
        public void GetCBB(ComboBox cbb)
        {
            if(cbb != null)
            {
                cbb.Items.Clear();
            }
            cbb.Items.AddRange(BLL_BookshopManagement.Instance.getListCBBPosition().ToArray());
        }

        private Staff GetStaff()
        {
            Staff staff = new Staff();
            staff.Name_Staff = txtName.Text;
            staff.DateOfBirth = Convert.ToDateTime(dateBirth.Value);
            staff.Address = txtAddress.Text;
            if (rbtnMale.Checked == true)
            {
                staff.Gender = true;
            }
            else
            {
                staff.Gender = false;
            }
            return staff;
        }
        private Account GetAccount()
        {
            Account account = new Account();
            account.UserName = txtUserName.Text;
            account.Password = txtPass.Text;
            if (cbbRole.SelectedIndex != -1)
            {
                account.ID_Position = ((CBBItem)(cbbRole.SelectedItem)).Value;
            }
            return account;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((txtName.Text == null) || (txtAddress.Text == null) || ((rbtnMale.Checked == false) && (rbtnFemale.Checked == false)) || 
                (txtUserName.Text == null) || (txtPass.Text == null) || (cbbRole.SelectedIndex == -1))
            {
                MessageBox.Show("Enter complete information");
            }
            else
            {
                DAL_BookshopManagement.Instance.AddStaff_DAL(GetStaff(), GetAccount());
                dataGridView1.DataSource = BLL_BookshopManagement.Instance.getAllStaffView_BLL();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL_BookshopManagement.Instance.getAllStaffView_BLL();
           //dataGridView1.DataSource = BLL_BookshopManagement.Instance.getAllPosition_BLL();
        }
        private void SetDetail(StaffView staffView)
        {
            txtName.Text = staffView.Name_Staff;
            dateBirth.Value = staffView.DateOfBirth;
            txtAddress.Text = staffView.Address;
            if(staffView.Gender == true)
            {
                rbtnMale.Checked = true;
            }
            else
            {
                rbtnFemale.Checked = true;
            }
            CBBItem item = new CBBItem();
            foreach(CBBItem i in cbbRole.Items)
            {
                if (i.Text == staffView.NamePosition) item = i;
            }
            cbbRole.SelectedIndex = cbbRole.Items.IndexOf(item);

            txtUserName.Text = staffView.UserName;
            txtPass.Text = staffView.Password;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ID_User = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_User"].Value);
        }
    }
}
//Staff staff = new Staff();
//staff.ID_Staff = 1;
//staff.Name_Staff = "NVB";
//staff.DateOfBirth = DateTime.Now;
//staff.Address = "Quang Tri";
//staff.Gender = true;
//staff.ID_User = 1;

//Account account = new Account();
//account.ID_User = 1;
//account.UserName = "seller";
//account.Password = "seller";
//account.ID_Position = 2;
