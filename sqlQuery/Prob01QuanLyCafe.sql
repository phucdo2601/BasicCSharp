create table TableFood (
	id int identity primary key,
	name nvarchar(255) not null default N'Bàn chưa có tên',
	status  nvarchar(255) not null default N'Trống'
)
go

create table Account (
	UserName nvarchar(255) Primary key,
	DisplayName nvarchar(255) not null default N'Pdn-Disp-Name',
	PassWord nvarchar(255) not null default 0,
	Type int not null default 0,
)
go

create table FoodCategory (
	id int identity primary key,
	name nvarchar(255) not null default N'Chưa đặt tên',
)
go

create table Food (
	id int identity primary key,
	name nvarchar(255) not null default N'Chưa đặt tên',
	idCategory int not null,
	price float not null default 0,

	FOREIgn key (idCategory) references FoodCategory(id)
)
go

create table Bill (
	id int identity primary key,
	DateCheckIn date not null default GETDATE(),
	DateCheckOut date,
	idTable int not null,
	status int not null DEFAULT 0,

	FOREIgn key (idTable) references TableFood(id)
)
go

create table BillInfo (
	id int identity primary key,
	idBill int not null,
	idFood int not null,
	count int not null default 0,

)
go

insert into Account(
	UserName,
	DisplayName,
	PassWord,
	Type
) values (
	N'testStaff01',
	N'testDisName01',
	N'1',
	0
)

select * from Account
go


DROP PROCEDURE IF EXISTS USP_GetAccountByUserName
go
Create PROC USP_GetAccountByUserName
@username nvarchar(100)
as
begin
	select * from Account where UserName = @username

end

exec USP_GetAccountByUserName @username = ' '

go

select * from Account where UserName = N'testStaff01' AND PassWord = N'' OR 1=1

go

DROP PROCEDURE IF EXISTS dbo.USP_Login
go
create Proc dbo.USP_Login 
@username nvarchar(100), @password nvarchar(100)
as
begin
	select * 
	from Account
	where UserName = @username and PassWord = @password
end
go

declare @i int = 0
while @i <= 10
Begin 
	INSERT INTO TableFood(name) values (N'Bàn ' + CAST(@i as  nvarchar(100)))
	set @i = @i +1
end

insert TableFood
(name, status) 
values (N'Bàn 1')

DBCC CHECKIDENT ('[TableFood]', RESEED, 0);
GO