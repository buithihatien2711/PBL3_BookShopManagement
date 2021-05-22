using PBL3_BookShopManagement.BLL;
using PBL3_BookShopManagement.DAL;
using PBL3_BookShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_BookShopManagement.GUI.Forms
{
    public partial class Form_BookDetail : Form
    {
        public delegate void MyDel(string name, string LinhVuc, string LoaiSach);
        public MyDel d { get; set; }
        public int masach { get; set; }
            //get { return -1; }
            //set { } }
        public Form_BookDetail(int s)
        {
            InitializeComponent();
            masach = s;
            SetGUI();
        }
        public void SetGUI()
        {
            if (masach != 0)
            {
                SachView sach = BLL_Book.Instance.GetSachViewByMaSach(masach);
                SachView s = BLL_Book.Instance.GetSachViewByMaSach(masach);
                txtBookID.Text = s.MaSach.ToString();
                txtTenSach.Text = s.TenSach.ToString();
                cbbLinhVuc.SelectedIndex = cbbLinhVuc.Items.IndexOf(s.TenLinhVuc);
                cbbLoaiSach.SelectedIndex = cbbLoaiSach.Items.IndexOf(s.TenLoaiSach);
                txtTacGia.Text = s.TenTacGia;
                txtNXB.Text = s.NhaXuatBan;
                txtLanTaiBan.Text = s.LanTaiBan;
                txtNamXuatBan.Text = s.NamXuatBan;
                txtGiaBan.Text = s.GiaBia.ToString();
                txtGiaMua.Text = s.GiaMua.ToString();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private Sach GetSach()
        {
            try
            {
                Sach sach = new Sach();
                if (txtBookID.Text != "")
                {
                    sach.MaSach = Convert.ToInt32(txtBookID.Text.ToString());
                }
                sach.TenSach = txtTenSach.Text;
                sach.GiaMua = Convert.ToInt32(txtGiaMua.Text.ToString());
                sach.TenLoaiSach = cbbLoaiSach.SelectedItem.ToString();
                sach.TenTacGia = txtTacGia.Text;
                sach.TenLinhVuc = cbbLinhVuc.SelectedItem.ToString();
                return sach;
            }
            catch(Exception e)
            {
                MessageBox.Show("entered wrong format");
                return null;
            }
        }
        private ThongTinXuatBan GetThongTinXuatBan()
        {
            try
            {
                ThongTinXuatBan thongTin = new ThongTinXuatBan();
                if (txtBookID.Text != "")
                {
                    thongTin.MaSach = Convert.ToInt32(txtBookID.Text);
                }
                thongTin.LanTaiBan = txtLanTaiBan.Text;
                thongTin.NamXuatBan = txtNamXuatBan.Text;
                thongTin.NhaXuatBan = txtNXB.Text;
                thongTin.GiaBia = Convert.ToInt32(txtGiaBan.Text);
                return thongTin;
            }
            catch
            {
                MessageBox.Show("entered wrong format");
                return null;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtTenSach.Text == null) || (cbbLinhVuc.SelectedIndex == -1) || (cbbLoaiSach.SelectedIndex == -1) || 
                (txtTacGia.Text == null) || (txtNXB.Text == null) || (txtLanTaiBan.Text == null) || (txtNamXuatBan.Text == null) || 
                (txtGiaBan == null) || (txtGiaMua == null))
            {
                MessageBox.Show("Enter complete information");
            }
            else
            {
                if ((GetSach() != null) && (GetThongTinXuatBan() != null))
                {
                    BLL_Book.Instance.ExcuteSach(GetSach(), GetThongTinXuatBan());
                    d(null, "All", "All");
                    this.Close();
                }
            }
        }
    }
}
