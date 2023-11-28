USE QLNS
GO
CREATE TABLE Chucvu
(
Macv nvarchar(5) primary key,
Tencv nvarchar(30),
Hesophucap float
)
GO
CREATE TABLE Phong
(
Maphong varchar(5) primary key,
Tenphong nvarchar(15),
Diachi nvarchar(50),
SDT nvarchar(15)
)
GO
CREATE TABLE Nhanvien
(
Manv varchar(5) primary key,
Hoten nvarchar(35),
GT nvarchar(10),
NS nvarchar(10),
Diachi nvarchar(100),
Quequan nvarchar(100),
Maphong varchar(5),
foreign key (Maphong) references Phong,
Macv varchar(5),
foreign key (Macv) references Chucvu,
Matkhau nvarchar(15),
Loainguoidung nvarchar(15),
Hesoluong float
)
GO
CREATE TABLE Luong
(
Maluong varchar(5) primary key,
Manv varchar(5),
foreign key (Manv) references Nhanvien,
Thang int,
Nam int,
Luong float
)
GO
CREATE TABLE Chamcong
(
Maccong varchar(5) primary key,
Manv varchar(5),
foreign key (Manv) references Nhanvien,
Thang int,
Nam int, 
Songaylv int
)
SELECT * FROM Chucvu;
INSERT INTO Chucvu(Macv, Tencv,Hesophucap)
VALUES
    ('CV001','Giam Đoc' ,0.8 ),
    ('CV002','Truong Phong',0.5),
	('CV003','Nhan Vien',0.2);
	

SELECT * FROM Phong;
INSERT INTO Phong(Maphong, Tenphong,Diachi,SDT)
VALUES
    ('P01','P.Giam Doc' , 'Ha Noi','0397887658' ),
    ('P02','P.Kinh Doanh' , 'Ha Noi','0395578231' ),
	('P03','P.Marketing' , 'Ha Noi','0987986798' ),
	('P04','P.Ke Toan' , 'Ha Noi','0398775643' ),
	('P05','P.Nhan Su' , 'Ha Noi','0976578899' );

SELECT * FROM Nhanvien;
INSERT INTO Nhanvien(Manv,Hoten,GT,NS,Diachi,Quequan,Maphong,Macv,Matkhau,Loainguoidung,Hesoluong)
VALUES
    ('NV01','Nguyen Thi Mai' ,'Nu','1995', 'Ba Dinh','Ha Nam','P01','CV001','123456','CaNhan',22 ),
    ('NV02','Nguyen Lan Anh' ,'Nu','1997', 'Linh Nam','Nam Dinh','P02','CV001','123456','CaNhan',22 ),
	('NV03','Nguyen Tuan Hai' ,'Nam','1997', 'Ha Noi','Thai Binh','P03','CV002','123456','CaNhan',23),
	('NV04','Nguyen Vu' ,'Nam','1995', 'Minh Khai','Hai Phong','P05','CV003','123456','CaNhan',20),
	('NV05','Vu Ngoc Anh' ,'Nu','1998', 'Ha Noi','Thai Binh','P04','CV003','123456','CaNhan',23),
	('NV06','Tran Quanh Nam' ,'Nam','1998', 'Cau Giay','Hai Phong','P03','CV003','123456','CaNhan',20);
  
SELECT * FROM Chamcong;
INSERT INTO Chamcong(Maccong,Manv,Thang,Nam , Songaylv)
VALUES
	('1','NV01',5,2022,27),
	('2','NV02',7,2022,28),
	('3','NV03',5,2022,28),
	('4','NV04',7,2022,27),
	('5','NV05',6,2022,29),
	('6','NV06',6,2022,28);

SELECT * FROM Luong;
INSERT INTO Luong(Maluong,Manv,Thang,Nam,Luong)
VALUES
	('1','NV01',5,2022,12000),
	('2','NV02',7,2022,23000),
	('3','NV03',5,2022,55000),
	('4','NV04',7,2022,27000),
	('5','NV05',5,2022,23000),
	('6','NV06',7,2022,27000);
	