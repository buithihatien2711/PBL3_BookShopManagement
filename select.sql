use PBL3_BookshopManagement
--select ChiTietHoaDon.MaSach, sum(ChiTietHoaDon.SoLuong) from ChiTietHoaDon group by ChiTietHoaDon.MaSach
--Thống kê theo Tên Sách
--select TenSach, TongSoLuong, GiaBia, (TongSoLuong*GiaBia*(1-SachKhuyenMai.MucGiamGia/100)) as Gia from Sach, ThongTinXuatBan, SachKhuyenMai ,(select ChiTietHoaDon.MaSach, sum(ChiTietHoaDon.SoLuong) as TongSoLuong from ChiTietHoaDon group by ChiTietHoaDon.MaSach) truyvancon
--where Sach.MaSach = truyvancon.MaSach and truyvancon.MaSach = ThongTinXuatBan.MaSach and truyvancon.MaSach = SachKhuyenMai.MaSach

--Thống kê theo loại sách
--select TenLoaiSach, SUM(TongSoLuong), SUM(Gia) as TienBan from (select TenLoaiSach, TongSoLuong, GiaBia, (TongSoLuong*GiaBia*(1-SachKhuyenMai.MucGiamGia/100)) as Gia from Sach, ThongTinXuatBan, SachKhuyenMai ,(select ChiTietHoaDon.MaSach, sum(ChiTietHoaDon.SoLuong) as TongSoLuong from ChiTietHoaDon group by ChiTietHoaDon.MaSach) truyvancon
--where Sach.MaSach = truyvancon.MaSach and truyvancon.MaSach = ThongTinXuatBan.MaSach and truyvancon.MaSach = SachKhuyenMai.MaSach) truyvancon2 group by truyvancon2.TenLoaiSach

--Thống kê theo loại sách
--select TenLinhVuc, SUM(TongSoLuong), SUM(Gia) as TienBan from (select TenLinhVuc, TongSoLuong, GiaBia, (TongSoLuong*GiaBia*(1-SachKhuyenMai.MucGiamGia/100)) as Gia from Sach, ThongTinXuatBan, SachKhuyenMai ,(select ChiTietHoaDon.MaSach, sum(ChiTietHoaDon.SoLuong) as TongSoLuong from ChiTietHoaDon group by ChiTietHoaDon.MaSach) truyvancon
--where Sach.MaSach = truyvancon.MaSach and truyvancon.MaSach = ThongTinXuatBan.MaSach and truyvancon.MaSach = SachKhuyenMai.MaSach) truyvancon2 group by truyvancon2.TenLinhVuc

--select Sach.MaSach, TenSach, GiaBia from Sach, ThongTinXuatBan where Sach.MaSach = ThongTinXuatBan.MaSach

--Thống kê theo Tên Sách
select truyvan.MaSach, TenSach, TongTienBan from (select truyvancon.MaSach, Sum(TienBan) as TongTienBan from (select ChiTietHoaDon.MaSach, GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong as TienBan from ChiTietHoaDon, ThongTinXuatBan, HoaDon 
where ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach and NgayLap >= '01/01/2021' and NgayLap <= '01/31/2021' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon) truyvancon group by truyvancon.MaSach) truyvan, Sach where truyvan.MaSach = Sach.MaSach

--Thống kê theo Loại Sách
select TenLoaiSach, sum(TienBan) as TongTien from(select TenLoaiSach, TienBan from (select ChiTietHoaDon.MaSach, GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong as TienBan from ChiTietHoaDon, ThongTinXuatBan, HoaDon where ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach
and NgayLap >= '01/01/2021' and NgayLap <= '01/31/2021' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon)  truyvancon, Sach where Sach.MaSach = truyvancon.MaSach) truyvan2 group by TenLoaiSach

select TenLoaiSach, sum(TienBan) as TongTien from(select TenLoaiSach, TienBan from (select ChiTietHoaDon.MaSach, GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong as TienBan from ChiTietHoaDon, ThongTinXuatBan 
where ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach) truyvancon, Sach where Sach.MaSach = truyvancon.MaSach) truyvan2 group by TenLoaiSach

--Thống kê theo Lĩnh vực
select TenLinhVuc, sum(TienBan) as TongTien from(select TenLinhVuc, TienBan from (select ChiTietHoaDon.MaSach, GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong as TienBan from ChiTietHoaDon, ThongTinXuatBan where ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach) truyvancon, Sach
where Sach.MaSach = truyvancon.MaSach) truyvan2 group by TenLinhVuc

select TenLinhVuc, sum(TienBan) as TongTien from(select TenLinhVuc, TienBan from (select ChiTietHoaDon.MaSach, GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong as TienBan from ChiTietHoaDon, ThongTinXuatBan, HoaDon 
where ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach and NgayLap >= '01/01/2021' and NgayLap <= '01/31/2021' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon) truyvancon, Sach where Sach.MaSach = truyvancon.MaSach) truyvan2 group by TenLinhVuc

--Tổng chi phí
--Chi phí mỗi lần nhập
select NhatKiNhapSach.MaSach, SoLuong*GiaMua as ChiPhi from Sach, NhatKiNhapSach where Sach.MaSach = NhatKiNhapSach.MaSach
--Tổng chi phí
select Sum(ChiPhi) as TongChiPhi from (select NhatKiNhapSach.MaSach, SoLuong*GiaMua as ChiPhi from Sach, NhatKiNhapSach where Sach.MaSach = NhatKiNhapSach.MaSach) as truyvan

--Số lượng sách mua
select Sum(SoLuong) from NhatKiNhapSach
--Lấy ra NhatKyNhapKho
select NhatKiNhapSach.MaSach, TenSach, SoLuong, SoLuong*GiaMua as ChiPhi, NgayNhap, NhatKiNhapSach.ID_Staff, Name_Staff from NhatKiNhapSach, Sach, Staff
where NhatKiNhapSach.MaSach = Sach.MaSach and NhatKiNhapSach.ID_Staff = Staff.ID_Staff

--Lấy chi phí theo nhân viên
select truyvan.ID_Staff, Name_Staff, ChiPhi from Staff, (select NhatKiNhapSach.ID_Staff, Sum(SoLuong*GiaMua) as ChiPhi from Sach, NhatKiNhapSach where NhatKiNhapSach.MaSach = Sach.MaSach group by NhatKiNhapSach.ID_Staff) truyvan
where truyvan.ID_Staff = Staff.ID_Staff

