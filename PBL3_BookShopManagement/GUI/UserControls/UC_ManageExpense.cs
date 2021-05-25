using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_BookShopManagement.BLL;

namespace PBL3_BookShopManagement.GUI.UserControls
{
    public partial class UC_ManageExpense : UserControl
    {
        public UC_ManageExpense()
        {
            InitializeComponent();

            ////Tạo watermark cho txtIDBook
            //txtIDBook.ForeColor = Color.LightGray;
            //txtIDBook.Text = "Enter IDBook";
            //txtIDBook.Leave += new System.EventHandler(this.txtIDBook_Leave);
            //txtIDBook.Enter += new System.EventHandler(this.txtIDBook_Enter);

            ////Tạo watermark cho txtIDStaff
            //txtIDStaff.ForeColor = Color.LightGray;
            //txtIDStaff.Text = "Enter IDStaff";
            //txtIDStaff.Leave += new System.EventHandler(this.txtIDStaff_Leave);
            //txtIDStaff.Enter += new System.EventHandler(this.txtIDStaff_Enter);
        }

        //Tạo watermark cho txtIDBook
        //private void txtIDBook_Leave(object sender, EventArgs e)
        //{
        //    if(txtIDBook.Text == "")
        //    {
        //        txtIDBook.Text = "Enter IDBook";
        //        txtIDBook.ForeColor = Color.Gray;
        //    }
        //}

        //private void txtIDBook_Enter(object sender, EventArgs e)
        //{
        //    if(txtIDBook.Text == "Enter IDBook")
        //    {
        //        txtIDBook.Text = "";
        //        txtIDBook.ForeColor = Color.Black;
        //    }
        //}

        ////Tạo watermark cho txtIDStaff
        //private void txtIDStaff_Leave(object sender, EventArgs e)
        //{
        //    if (txtIDStaff.Text == "")
        //    {
        //        txtIDStaff.Text = "Enter IDStaff";
        //        txtIDStaff.ForeColor = Color.Gray;
        //    }
        //}

        //private void txtIDStaff_Enter(object sender, EventArgs e)
        //{
        //    if (txtIDStaff.Text == "Enter IDStaff")
        //    {
        //        txtIDStaff.Text = "";
        //        txtIDStaff.ForeColor = Color.Black;
        //    }
        //}

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL_ThongKe.Instance.GetNhatKiNhapKho_BLL(dateFrom.Value, dateTo.Value);
        }
    }
}
