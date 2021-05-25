use PBL3_BookshopManagement
select TenLoaiSach, sum(TongTien) from HoaDon, Sach, ChiTietHoaDon
where ChiTietHoaDon.MaSach = Sach.MaSach  group by TenLoaiSach