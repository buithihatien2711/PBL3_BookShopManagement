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
    public partial class UC_Discount : UserControl
    {
        public UC_Discount()
        {
            InitializeComponent();

            txtSearchName.ForeColor = Color.LightGray;
            txtSearchName.Text = "Enter Name Book";
            txtSearchName.Leave += new System.EventHandler(this.txtSearchName_Leave);
            txtSearchName.Enter += new System.EventHandler(this.txtSearchName_Enter);
        }

        private void txtSearchName_Leave(object sender, EventArgs e)
        {
            if (txtSearchName.Text == "")
            {
                txtSearchName.Text = "Enter Name Book";
                txtSearchName.ForeColor = Color.Gray;
            }
        }

        private void txtSearchName_Enter(object sender, EventArgs e)
        {
            if (txtSearchName.Text == "Enter Name Book")
            {
                txtSearchName.Text = "";
                txtSearchName.ForeColor = Color.Black;
            }
        }

        Random rand = new Random();

        private void LoadChart()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadChart();
        }
    }
}
