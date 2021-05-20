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
            SetCBB(cbbRole, false);
            SetCBB(cbbShow, true);
            txtSearchName.ForeColor = Color.LightGray;
            txtSearchName.Text = "Enter Name Staff";
            txtSearchName.Leave += new System.EventHandler(this.txtSearchName_Leave);
            txtSearchName.Enter += new System.EventHandler(this.txtSearchName_Enter);

            cbbShow.SelectedIndex = 0;
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

        public void SetCBB(ComboBox cbb, bool All)
        {
            if(cbb != null)
            {
                cbb.Items.Clear();
            }
            if (All)
            {
                cbb.Items.Add(new CBBItem { Text = "All", Value = 0 });
            }
            cbb.Items.AddRange(BLL_BookshopManagement.Instance.getListCBBPosition().ToArray());
        }

        private Staff GetStaff()
        {
            Staff staff = new Staff();
            if(txtIDStaff.Text != "")
            {
                staff.ID_Staff = Convert.ToInt32(txtIDStaff.Text.ToString());
            }
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
            if (txtIDUser.Text != "")
            {
                account.ID_User = Convert.ToInt32(txtIDUser.Text.ToString());
            }
            
            account.UserName = txtUserName.Text;
            account.Password = txtPass.Text;
            if (cbbRole.SelectedIndex != -1)
            {
                account.ID_Position = ((CBBItem)(cbbRole.SelectedItem)).Value;
            }
            return account;
        }

        public void ResetGUI()
        {
            txtIDStaff.Text = "";
            txtName.Text = "";
            dateBirth.Value = DateTime.Now;
            txtAddress.Text = "";
            rbtnMale.Checked = false;
            rbtnFemale.Checked = false;
            CBBItem item = new CBBItem();
            txtIDUser.Text = "";
            cbbRole.SelectedIndex = -1;
            txtUserName.Text = "";
            txtPass.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResetGUI();
            txtName.Focus();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL_BookshopManagement.Instance.GetListStaffView_BLL(null, ((CBBItem)(cbbShow.SelectedItem)).Value);
            //dataGridView1.DataSource = BLL_BookshopManagement.Instance.getAllPosition_BLL();
        }

        private void SetDetail(Staff staff, Account account)
        {
            txtIDStaff.Text = staff.ID_Staff.ToString();
            txtName.Text = staff.Name_Staff;
            dateBirth.Value = staff.DateOfBirth;
            txtAddress.Text = staff.Address;
            if(staff.Gender == true)
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
                if (i.Value == account.ID_Position) item = i;
            }
            txtIDUser.Text = staff.ID_User.ToString();
            cbbRole.SelectedIndex = cbbRole.Items.IndexOf(item);
            txtUserName.Text = account.UserName;
            txtPass.Text = account.Password;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ID_User = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_User"].Value);
            int ID_Staff = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Staff"].Value);
            Account account = BLL_BookshopManagement.Instance.GetAccountbyID(ID_User);
            Staff staff = BLL_BookshopManagement.Instance.GetStaffbyID(ID_Staff);
            SetDetail(staff, account);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetGUI();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtName.Text == null) || (txtAddress.Text == null) || ((rbtnMale.Checked == false) && (rbtnFemale.Checked == false)) ||
                (txtUserName.Text == null) || (txtPass.Text == null) || (cbbRole.SelectedIndex == -1))
            {
                MessageBox.Show("Enter complete information");
            }
            else
            {
                int idStaff = 0;
                if(txtIDStaff.Text != "")
                {
                    idStaff = Convert.ToInt32(txtIDStaff.Text.ToString());
                }
                if (BLL_BookshopManagement.Instance.Excute(idStaff))
                {
                    BLL_BookshopManagement.Instance.UpdateStaff_BLL(GetStaff(), GetAccount());
                }
                else
                {
                    BLL_BookshopManagement.Instance.AddStaff_BLL(GetStaff(), GetAccount());
                }
                dataGridView1.DataSource = BLL_BookshopManagement.Instance.GetListStaffView_BLL(null, ((CBBItem)(cbbShow.SelectedItem)).Value);
                ResetGUI();
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 0)
            {
                List<string> listDel = new List<string>();
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    listDel.Add(i.Cells["ID_Staff"].Value.ToString());
                }
                BLL_BookshopManagement.Instance.DelStaff_BLL(listDel);
                dataGridView1.DataSource = BLL_BookshopManagement.Instance.GetListStaffView_BLL(null, ((CBBItem)(cbbShow.SelectedItem)).Value);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL_BookshopManagement.Instance.GetListStaffView_BLL(txtSearchName.Text, ((CBBItem)(cbbShow.SelectedItem)).Value);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {

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
