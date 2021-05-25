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
    public partial class UC_ManageRevenue : UserControl
    {
        public UC_ManageRevenue()
        {
            InitializeComponent();
            SetGUI();
            ////Tạo watermark cho txtIDBook
            //txtIDHoaDon.ForeColor = Color.LightGray;
            //txtIDHoaDon.Text = "Enter IDInvoice";
            //txtIDHoaDon.Leave += new System.EventHandler(this.txtIDBook_Leave);
            //txtIDHoaDon.Enter += new System.EventHandler(this.txtIDBook_Enter);

            ////Tạo watermark cho txtIDStaff
            //txtIDStaff.ForeColor = Color.LightGray;
            //txtIDStaff.Text = "Enter IDStaff";
            //txtIDStaff.Leave += new System.EventHandler(this.txtIDStaff_Leave);
            //txtIDStaff.Enter += new System.EventHandler(this.txtIDStaff_Enter);
            
        }

        //Tạo watermark cho txtIDBook
        //private void txtIDBook_Leave(object sender, EventArgs e)
        //{
        //    if(txtIDHoaDon.Text == "")
        //    {
        //        txtIDHoaDon.Text = "Enter IDInvoice";
        //        txtIDHoaDon.ForeColor = Color.Gray;
        //    }
        //}

        //private void txtIDBook_Enter(object sender, EventArgs e)
        //{
        //    if(txtIDHoaDon.Text == "Enter IDInvoice")
        //    {
        //        txtIDHoaDon.Text = "";
        //        txtIDHoaDon.ForeColor = Color.Black;
        //    }
        //}

        //Tạo watermark cho txtIDStaff
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
        public void SetGUI()
        {
            rbtnTongHop.Checked = true;
            txtSoHoaDon.Text = BLL_ThongKe.Instance.GetSoLuongHoaDon_BLL().ToString();
            txtDoanhThu.Text = BLL_ThongKe.Instance.GetDoanhThu_BLL().ToString();
            txtSoSachBan.Text = BLL_ThongKe.Instance.GetSoLuongSachBan_BLL().ToString();
        }
        private void btnStatistic_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL_ThongKe.Instance.GetHoaDon_BLL(dateFrom.Value, dateTo.Value);
            dataGridView1.Columns[0].HeaderText = "ID Invoice";
            dataGridView1.Columns[1].HeaderText = "Name Customer";
            dataGridView1.Columns[2].HeaderText = "Date(month/day/year)";
            dataGridView1.Columns[3].HeaderText = "Total";
            dataGridView1.Columns[4].HeaderText = "ID_Staff";
        }
    }
}
