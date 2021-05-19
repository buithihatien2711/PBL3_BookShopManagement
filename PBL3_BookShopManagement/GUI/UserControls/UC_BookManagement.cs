using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_BookShopManagement.GUI.Forms;

namespace PBL3_BookShopManagement.GUI.UserControls
{
    public partial class UC_BookManagement : UserControl
    {
        public UC_BookManagement()
        {
            InitializeComponent();

            //Tạo watermark cho txtSearch
            txtSearch.ForeColor = Color.LightGray;
            txtSearch.Text = "Enter Name Book";
            txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Enter Name Book";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Enter Name Book")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }
        private void btnAddNewBooks_Click(object sender, EventArgs e)
        {
            using (Form_AddNewBook abn = new Form_AddNewBook())
            {
                abn.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
