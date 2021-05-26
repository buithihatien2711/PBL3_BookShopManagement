﻿using System;
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
            ShowBaoCaoTH(dtpFrom.Value, dtpTo.Value);
            //Show();
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

            dtpFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpTo.Value = dtpFrom.Value.AddYears(1).AddDays(-1);
        }

        public void ShowBaoCaoTH(DateTime dateFrom, DateTime dateTo)
        {
            dataGridView1.DataSource = BLL_ThongKe.Instance.GetHoaDon_BLL(dateFrom, dateTo);
            dataGridView1.Columns[0].HeaderText = "ID Invoice";
            dataGridView1.Columns[1].HeaderText = "Name Customer";
            dataGridView1.Columns[2].HeaderText = "Date(month/day/year)";
            dataGridView1.Columns[3].HeaderText = "Total";
            dataGridView1.Columns[4].HeaderText = "ID Staff";
        }
        public void ShowTheoNV(DateTime dateFrom, DateTime dateTo)
        {
            dataGridView1.DataSource = BLL_ThongKe.Instance.GetDoanhThuTheoNhanVien_BLL(dateFrom, dateTo);
            dataGridView1.Columns[0].HeaderText = "ID Staff";
            dataGridView1.Columns[1].HeaderText = "Name Staff";
            dataGridView1.Columns[2].HeaderText = "Total";
        }
        public void ShowTheoSach(DateTime dateFrom, DateTime dateTo)
        {
            dataGridView1.DataSource = BLL_ThongKe.Instance.GetDoanhThuTheoTenSach_BLL(dateFrom, dateTo);
            dataGridView1.Columns[0].HeaderText = "ID Book";
            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[2].HeaderText = "Total";
        }
        public void ShowTheoLoaiSach(DateTime dateFrom, DateTime dateTo)
        {
            dataGridView1.DataSource = BLL_ThongKe.Instance.GetDoanhThuTheoLoaiSach_BLL(dateFrom, dateTo);
            dataGridView1.Columns[0].HeaderText = "Kind of book";
            dataGridView1.Columns[1].HeaderText = "Total";
        }
        public void ShowTheoLinhVuc(DateTime dateFrom, DateTime dateTo)
        {
            dataGridView1.DataSource = BLL_ThongKe.Instance.GetDoanhThuTheoLinhVuc_BLL(dateFrom, dateTo);
            dataGridView1.Columns[0].HeaderText = "Category";
            dataGridView1.Columns[1].HeaderText = "Total";
        }
        private void btnStatistic_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = dtpFrom.Value;
            DateTime dateTo = dtpTo.Value;
            if (rbtnTongHop.Checked)
            {
                ShowBaoCaoTH(dateFrom, dateTo);
            }
            else
            {
                if (rbtnNhanVien.Checked)
                {
                    ShowTheoNV(dateFrom, dateTo);
                }
                else
                {
                    if (rbtnSach.Checked)
                    {
                        ShowTheoSach(dateFrom, dateTo);
                    }
                    else
                    {
                        if (rbtnLoaiSach.Checked)
                        {
                            ShowTheoLoaiSach(dateFrom, dateTo);
                        }
                        else
                        {
                            ShowTheoLinhVuc(dateFrom, dateTo);
                        }
                    }
                }
            }
        }

        private void rbtnTongHop_CheckedChanged(object sender, EventArgs e)
        {
            ShowBaoCaoTH(dtpFrom.Value, dtpTo.Value);
        }

        private void rbtnNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            ShowTheoNV(dtpFrom.Value, dtpTo.Value);
        }

        private void rbtnSach_CheckedChanged(object sender, EventArgs e)
        {
            ShowTheoSach(dtpFrom.Value, dtpTo.Value);
        }

        private void rbtnLoaiSach_CheckedChanged(object sender, EventArgs e)
        {
            ShowTheoLoaiSach(dtpFrom.Value, dtpTo.Value);
        }

        private void rbtnLinhVuc_CheckedChanged(object sender, EventArgs e)
        {
            ShowTheoLinhVuc(dtpFrom.Value, dtpTo.Value);
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (rbtnTongHop.Checked)
            {
                ShowBaoCaoTH(dtpFrom.Value, dtpTo.Value);
            }
            else
            {
                if (rbtnNhanVien.Checked)
                {
                    ShowTheoNV(dtpFrom.Value, dtpTo.Value);
                }
                else
                {
                    if (rbtnSach.Checked)
                    {
                        ShowTheoSach(dtpFrom.Value, dtpTo.Value);
                    }
                    else
                    {
                        if (rbtnLoaiSach.Checked)
                        {
                            ShowTheoLoaiSach(dtpFrom.Value, dtpTo.Value);
                        }
                        else
                        {
                            ShowTheoLinhVuc(dtpFrom.Value, dtpTo.Value);
                        }
                    }
                }
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (rbtnTongHop.Checked)
            {
                ShowBaoCaoTH(dtpFrom.Value, dtpTo.Value);
            }
            else
            {
                if (rbtnNhanVien.Checked)
                {
                    ShowTheoNV(dtpFrom.Value, dtpTo.Value);
                }
                else
                {
                    if (rbtnSach.Checked)
                    {
                        ShowTheoSach(dtpFrom.Value, dtpTo.Value);
                    }
                    else
                    {
                        if (rbtnLoaiSach.Checked)
                        {
                            ShowTheoLoaiSach(dtpFrom.Value, dtpTo.Value);
                        }
                        else
                        {
                            ShowTheoLinhVuc(dtpFrom.Value, dtpTo.Value);
                        }
                    }
                }
            }
        }
    }
}
