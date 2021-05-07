create table Position(
ID_Position int primary key,
NamePosition varchar(20))

create table Account(
ID_User int primary key,
UserName varchar(30),
Password varchar(20),
ID_Position int references Position(ID_Position))

create table Staff(
ID_Staff int,
Name_Staff varchar(30),
Gender bit,
DateOfBirth datetime,
Address varchar(40),
ID_User int references Account(ID_User))

create table LoaiSach(
MaLoaiSach char(2) primary key,
TenLoaiSach varchar(20))

create table TacGia(
MaTacGia char(4) primary key,
TenTacGia varchar(40),
NamSinh char(4),
NamMat char(4),
QueQuan varchar(20))

create table LinhVuc(
MaLinhVuc char(2) primary key,
TenLinhVuc varchar(30))

create table Sach(
MaSach char(13) primary key,
TenSach varchar(100),
MaTacGia char(4) foreign key (MaTacGia) references TacGia,
MaLoaiSach char(2) foreign key(MaLoaiSach) references LoaiSach,
MaLinhVuc char(2) foreign key(MaLinhVuc) references LinhVuc,
GiaMua int)

create table ThongTinXuatBan(
MaSach char(13) primary key foreign key (MaSach) references Sach,
LanTaiBan char(11),
NamXuatBan char(4),
NhaXuatBan varchar(50),
GiaBia int)

create table Kho(
MaSach char(13) primary key foreign key (MaSach) references Sach,
TongSoLuong int,
SoLuongCon int)

create table NhatKiNhapSach(
STT int primary key,
MaSach char(13) foreign key (MaSach) references Kho,
SoLuong int,
NagyNhap date)

create table HoaDon(
MaHoaDon int primary key,
TenKhachHang varchar(50),
NgayLap Date,
TongTien Decimal(10,2))

create table ChiTietHoaDon(
MaHoaDon int foreign key (MaHoaDon) references HoaDon,
MaSach char(13) foreign key (MaSach) references Sach,
SoLuong int,
MucGiamGia float
constraint pk_ChiTiet primary key(MaHoaDon, MaSach))

create table SachKhuyenMai(
MaSach char(13) primary key foreign key (MaSach) references Sach,
MucGiamGia float)