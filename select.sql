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


-------------------------------THỐNG KÊ DOANH THU----------------------------------
--Lấy ra số sách bán theo khoảng thời gian
select SUM(SoLuong) from ChiTietHoaDon
select SUM(SoLuong) from ChiTietHoaDon, HoaDon where NgayLap >= '01/01/2021' and NgayLap <= '01/31/2021' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon
select SUM(SoLuong) from ChiTietHoaDon, HoaDon where NgayLap >= '1/1/2021 12:00:00 AM' and NgayLap <= '5/26/2021 9:36:06 PM' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon

--Lấy số lượng hóa đơn theo khoảng thời gian
select COUNT(MaHoaDon) from HoaDon where NgayLap >= '01/01/2021' and NgayLap <= '01/31/2021'

--Lấy doanh theo khoảng thời gian
select SUM(TongTien) from HoaDon where NgayLap >= '01/01/2021' and NgayLap <= '01/31/2021'

--Theo nhan vien
select HoaDon.ID_Staff, Name_Staff, SUM(SoLuong) as SoSachBan, SUM(TongTien) as TongTienBan from ChiTietHoaDon, HoaDon, Staff where HoaDon.ID_Staff = Staff.ID_Staff and NgayLap >= '01/01/2021' and NgayLap <= '01/31/2021' 
and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon group by HoaDon.ID_Staff, Name_Staff 

--Thống kê theo Tên Sách
select truyvancon.MaSach, TenSach, TongSachBan, TongTienBan from Sach, (select ChiTietHoaDon.MaSach, Sum(SoLuong) as TongSachBan, SUM(GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong) as TongTienBan from ChiTietHoaDon, ThongTinXuatBan, HoaDon 
where ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach and NgayLap >= '01/01/2021' and NgayLap <= '01/31/2021' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon
group by ChiTietHoaDon.MaSach) truyvancon where truyvancon.MaSach = Sach.MaSach

--Thống kê theo Loại Sách
select TenLoaiSach, SUM(SoLuong) as TongSachBan, SUM(GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong) as TongTienBan from Sach, ChiTietHoaDon, HoaDon, ThongTinXuatBan
where ChiTietHoaDon.MaSach = Sach.MaSach and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon and ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach and NgayLap >= '01/01/2021' and NgayLap <= '01/31/2021'
group by TenLoaiSach

--Thống kê theo Lĩnh vực
select TenLinhVuc, SUM(SoLuong) as TongSoLuong, SUM(GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong) as TongTien from HoaDon, ChiTietHoaDon, Sach, ThongTinXuatBan
where ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon and ChiTietHoaDon.MaSach = Sach.MaSach and ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach and NgayLap >= '01/01/2021' and NgayLap <= '01/31/2021'
group by TenLinhVuc

--Lấy ra chi tiết hóa đơn



-----------------------THỐNG KÊ CHI PHÍ-------------------------------
--Tổng sách mua
select sum(SoLuong) from NhatKiNhapSach

--Số sách mua trong khoảng thời gian
select * from NhatKiNhapSach
select SUM(SoLuong) from NhatKiNhapSach where NgayNhap >= '01/01/2021' and NgayNhap <= '01/31/2021'

--Thống kê chi phí trong khoảng thời gian
select SUM(SoLuong*GiaMua) as ChiPhi from Sach, NhatKiNhapSach where Sach.MaSach = NhatKiNhapSach.MaSach and NgayNhap >= '01/01/2021' and NgayNhap <= '01/31/2021'

--Chi phí mỗi lần nhập
select NhatKiNhapSach.MaSach, SoLuong*GiaMua as ChiPhi from Sach, NhatKiNhapSach where Sach.MaSach = NhatKiNhapSach.MaSach

--Tổng chi phí
select Sum(ChiPhi) as TongChiPhi from (select NhatKiNhapSach.MaSach, SoLuong*GiaMua as ChiPhi from Sach, NhatKiNhapSach where Sach.MaSach = NhatKiNhapSach.MaSach) as truyvan

--Số lượng sách mua
select Sum(SoLuong) from NhatKiNhapSach

--Lấy ra NhatKyNhapKho
select NhatKiNhapSach.MaSach, TenSach, SoLuong, SoLuong*GiaMua as ChiPhi, NgayNhap, NhatKiNhapSach.ID_Staff, Name_Staff from NhatKiNhapSach, Sach, Staff
where NhatKiNhapSach.MaSach = Sach.MaSach and NhatKiNhapSach.ID_Staff = Staff.ID_Staff and NgayNhap >= '01/01/2021' and NgayNhap <= '01/31/2021'

--Lấy chi phí theo nhân viên
select truyvan.ID_Staff, Name_Staff, TongSachMua, TongTienMua from Staff,
(select NhatKiNhapSach.ID_Staff, SUM(SoLuong) as TongSachMua, Sum(SoLuong*GiaMua) as TongTienMua from Sach, NhatKiNhapSach where NhatKiNhapSach.MaSach = Sach.MaSach and NgayNhap >= '01/08/2021' and NgayNhap <= '01/28/2021'group by NhatKiNhapSach.ID_Staff) truyvan
where truyvan.ID_Staff = Staff.ID_Staff

--Lấy chi phí theo sách
select truyvancon.MaSach, TenSach, TongSachMua, TongTienMua from Sach, 
(select NhatKiNhapSach.MaSach, Sum(SoLuong) as TongSachMua, Sum(SoLuong*GiaMua) as TongTienMua from Sach, NhatKiNhapSach where Sach.MaSach = NhatKiNhapSach.MaSach and NgayNhap >= '01/01/2021' and NgayNhap <= '01/31/2021' group by NhatKiNhapSach.MaSach) truyvancon
where truyvancon.MaSach = Sach.MaSach

--Lấy chi phí theo LoaiSach
select TenLoaiSach , SUM(SoLuong) as TongSachMua, SUM(SoLuong*GiaMua) as TongSachBan from Sach, NhatKiNhapSach where NhatKiNhapSach.MaSach = Sach.MaSach and NgayNhap >= '01/01/2021' and NgayNhap <= '01/31/2021' group by Sach.TenLoaiSach

--Lấy chi phí theo Lĩnh Vực
select TenLinhVuc , SUM(SoLuong) as TongSachMua, SUM(SoLuong*GiaMua) as TongSachBan from Sach, NhatKiNhapSach where NhatKiNhapSach.MaSach = Sach.MaSach and NgayNhap >= '01/01/2021' and NgayNhap <= '01/31/2021' group by Sach.TenLinhVuc


select TenLoaiSach, SUM(SoLuong) as TongSachBan, SUM(GiaBia*(1 - ChiTietHoaDon.MucGiamGia/100)*SoLuong) as TongTienBan from Sach, ChiTietHoaDon, HoaDon, ThongTinXuatBan
where ChiTietHoaDon.MaSach = Sach.MaSach and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon and ChiTietHoaDon.MaSach = ThongTinXuatBan.MaSach and NgayLap >= '01/01/2021' and NgayLap <= '01/31/2021' group by TenLoaiSach


select * from ChiTietHoaDon