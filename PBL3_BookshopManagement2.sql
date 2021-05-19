create table Position(
ID_Position int primary key,
NamePosition varchar(20))

create table Account(
ID_User int identity(1, 1) primary key,
UserName varchar(30) unique,
Password varchar(20),
ID_Position int references Position(ID_Position))

create table Staff(
ID_Staff int identity(1, 1) primary key,
Name_Staff varchar(30),
Gender bit,
DateOfBirth datetime,
Address varchar(40),
ID_User int references Account(ID_User) unique)

create table Sach(
MaSach int identity(1, 1) primary key,
TenSach varchar(100),
GiaMua int,
TenLoaiSach varchar(20),
TenTacGia varchar(40),
TenLinhVuc varchar(30))

create table ThongTinXuatBan(
MaSach int primary key foreign key (MaSach) references Sach,
LanTaiBan char(11),
NamXuatBan char(4),
NhaXuatBan varchar(50),
GiaBia int)

create table Kho(
MaSach int primary key foreign key (MaSach) references Sach,
TongSoLuong int,
SoLuongCon int)

create table NhatKiNhapSach(
STT int identity(1, 1) primary key,
MaSach int foreign key (MaSach) references Kho,
SoLuong int,
NgayNhap date,
ID_Staff int)

create table HoaDon(
MaHoaDon int identity(1, 1) primary key,
TenKhachHang varchar(50),
NgayLap Date,
TongTien Decimal(10,2),
ID_Staff int)

create table ChiTietHoaDon(
MaHoaDon int foreign key (MaHoaDon) references HoaDon,
MaSach int foreign key (MaSach) references Sach,
SoLuong int,
MucGiamGia float
constraint pk_ChiTiet primary key(MaHoaDon, MaSach))

create table SachKhuyenMai(
MaSach int primary key foreign key (MaSach) references Sach,
MucGiamGia float)