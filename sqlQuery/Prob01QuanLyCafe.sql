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