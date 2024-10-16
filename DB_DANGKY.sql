create database dbdangky
GO
use dbdangky
GO
CREATE TABLE KHACHHANG
(
MaKH INT IDENTITY(1,1),
HoTen NVARCHAR(50) NOT NULL,
Taikhoan Varchar(50) UNIQUE,
Matkhau Varchar(50) NOT NULL,
Email Varchar(100) UNIQUE,
DiachiKH NVARCHAR(200),
DienthoaiKH Varchar(50),
Ngaysinh DATETIME
CONSTRAINT PK_Khachhang PRIMARY KEY(MaKH)
)
select *from KHACHHANG



data này lýu ? ðâu z b?n