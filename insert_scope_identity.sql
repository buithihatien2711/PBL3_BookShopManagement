use PBL3_BookshopManagement

--select Staff.ID_Staff, Name_Staff, Gender, DateOfBirth, Address, Account.ID_User, UserName, Password, NamePosition from Staff, Account, Position where Staff.ID_User = Account.ID_User and Account.ID_Position = Position.ID_Position;
--insert into Account values ('NVA', 'NVA', 3);
--insert into Position values ('5', 'Ko ro');
--select SCOPE_IDENTITY();

--insert into Account values ('d', 'd', 2)
--SELECT TOP 1 ID_User FROM Account  ORDER BY ID_User DESC; 

insert into Staff values ('d' ,'True', '5/18/2021 9:49:21 AM', 'Quang Tri', 28)