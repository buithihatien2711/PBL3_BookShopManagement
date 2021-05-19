use PBL3_BookshopManagement
-----------------Loai sach----------------
insert into LoaiSach values ('Sach Giao Khoa');--1--
insert into LoaiSach values ('Sach tham khao');--2--
insert into LoaiSach values ('Tieu thuyet');--3--
insert into LoaiSach values ('Truyen tranh');--4--
insert into LoaiSach values ('Sach ky nang song');--5--
insert into LoaiSach values ('Sach ton giao');--6--
insert into LoaiSach values ('Truyen ngan');--7--
insert into LoaiSach values ('Ky nang lam viec'); --8--

-----------------Linh vuc------------------
insert into LinhVuc values ('Ngoai ngu');--1--
insert into LinhVuc values ('Tin hoc');--2--
insert into LinhVuc values ('Van hoc');--3--
insert into LinhVuc values ('Toan hoc');--4--
insert into LinhVuc values ('Ky nang');--5--
insert into LinhVuc values ('Lich su');--6--

----------------Tac gia-------------------
insert into TacGia values ('Nguyen Phong', 1950, null, 'Ha Noi');--1--
insert into TacGia values ('Dane Maxwell', null, null, 'My');--2--
insert into TacGia values ('J.K.Rowling', 1965, null, 'Anh');--3--
insert into TacGia values ('Mai Lan Huong', 1980, null, 'Ha Noi');--4--
insert into TacGia values ('Bui Van Ha', null, null, null);--5--
insert into TacGia values ('Nguyen Nhat Anh' , 1955, null, 'Ha Noi');--6--
insert into TacGia values ('Fujiko F. Fujio', 1933, 1996, 'Nhat Ban');--7--
insert into TacGia values ('Hector Malot', 1830, 1907, 'Phap');

-----------------Sach----------------------
insert into Sach values ('Muon kiep nhan sinh', 1, 5, 5, 100000);
insert into Sach values ('Loi tat khoi nghiep', 2, 5, 5, 120000);
insert into Sach values ('Harry Potter', 3, 3, 3, 500000);
insert into Sach values ('Giai thich ngu phap tieng anh', 4, 2, 1, 90000);
insert into Sach values ('Tieng viet lop 1', 5, 1, 3, 50000);
insert into Sach values ('Doraemon', 6, 4, 3, 20000);
insert into Sach values ('Khong gia dinh', 7, 3, 3, 200000);
insert into Sach values ('Tieng viet lop 2', 5, 1, 3, 45000);

----------Thong tin xuat ban-----------------
insert into ThongTinXuatBan values (1, '2', '2019', 'Nha xuat ban tong hop', 110000);--1
insert into ThongTinXuatBan values (2, '3', '2020', 'Nha xuat ban tong hop', 130000);--2
insert into ThongTinXuatBan values (3, '1', '2018', 'Nha xuat ban tre', 60000);--3
insert into ThongTinXuatBan values (4, '5', '2021', 'Nha xuat ban Da Nang', 100000);--4
insert into ThongTinXuatBan values (5, '2', '2018', 'Nha xuat giao duc', 60000);--5
insert into ThongTinXuatBan values (6, '3', '2019', 'Nha xuat ban kim dong', 30000);--6
insert into ThongTinXuatBan values (7, '4', '2020', 'Nha xuat ban tong hop', 210000);--7
insert into ThongTinXuatBan values (8, '7', '2021', 'Nha xuat ban giao duc', 35000);--8

--------------Kho---------------------------
insert into Kho values (1, 50, 20);
insert into Kho values (2, 40, 20);
insert into Kho values (3, 100, 50);
insert into Kho values (4, 70, 50);
insert into Kho values (5, 100, 40);
insert into Kho values (6, 60, 20);
insert into Kho values (7, 40, 10);
insert into Kho values (8, 90, 40);

--------------Nhat ki nhap sach------------------
insert into NhatKiNhapSach values (1, 20, '01/01/2020');
insert into NhatKiNhapSach values (2, 30, '03/05/2020');
insert into NhatKiNhapSach values (3, 40, '07/02/2020');
insert into NhatKiNhapSach values (4, 50, '08/03/2020');
insert into NhatKiNhapSach values (5, 40, '09/04/2020');
insert into NhatKiNhapSach values (1, 50, '10/09/2020');


--------------Sach khuyen mai--------------------
insert into SachKhuyenMai values (1, 0.1);
insert into SachKhuyenMai values (5, 0.4);
insert into SachKhuyenMai values (6, 0.3);
insert into SachKhuyenMai values (7, 0.2);
insert into SachKhuyenMai values (8, 0.15);

--------------Hoa don----------------------------
insert into HoaDon values ('Nguyen Huong', '04/03/2021', 160000)

------------Chi tiet hoa don----------------
insert into ChiTietHoaDon values (1, 3, 1, 0);
insert into ChiTietHoaDon values (1, 4, 1, 0);
