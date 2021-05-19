using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_BookShopManagement.GUI.UserControls
{
    public partial class UC_ManageRevenue : UserControl
    {
        public UC_ManageRevenue()
        {
            InitializeComponent();

            //Tạo watermark cho txtIDBook
            txtIDHoaDon.ForeColor = Color.LightGray;
            txtIDHoaDon.Text = "Enter IDInvoice";
            txtIDHoaDon.Leave += new System.EventHandler(this.txtIDBook_Leave);
            txtIDHoaDon.Enter += new System.EventHandler(this.txtIDBook_Enter);

            //Tạo watermark cho txtIDStaff
            txtIDStaff.ForeColor = Color.LightGray;
            txtIDStaff.Text = "Enter IDStaff";
            txtIDStaff.Leave += new System.EventHandler(this.txtIDStaff_Leave);
            txtIDStaff.Enter += new System.EventHandler(this.txtIDStaff_Enter);
        }

        //Tạo watermark cho txtIDBook
        private void txtIDBook_Leave(object sender, EventArgs e)
        {
            if(txtIDHoaDon.Text == "")
            {
                txtIDHoaDon.Text = "Enter IDInvoice";
                txtIDHoaDon.ForeColor = Color.Gray;
            }
        }

        private void txtIDBook_Enter(object sender, EventArgs e)
        {
            if(txtIDHoaDon.Text == "Enter IDInvoice")
            {
                txtIDHoaDon.Text = "";
                txtIDHoaDon.ForeColor = Color.Black;
            }
        }

        //Tạo watermark cho txtIDStaff
        private void txtIDStaff_Leave(object sender, EventArgs e)
        {
            if (txtIDStaff.Text == "")
            {
                txtIDStaff.Text = "Enter IDStaff";
                txtIDStaff.ForeColor = Color.Gray;
            }
        }

        private void txtIDStaff_Enter(object sender, EventArgs e)
        {
            if (txtIDStaff.Text == "Enter IDStaff")
            {
                txtIDStaff.Text = "";
                txtIDStaff.ForeColor = Color.Black;
            }
        }

        private void btnAddNewBooks_Click(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
