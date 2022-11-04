create database Products

go
use Products

create table Product(
Id int identity(1,1) primary key,
name varchar(255),
price real,
brand varchar(255),
createdAt datetime,
UpdatedAt datetime
)

go
use Products
go

create procedure GetProducts
AS select * from Product
RETURN

go
use Products
go

create procedure put
@Id int,
@Name varchar(255),
@Price real,
@Brand varchar(255),
@UpdatedAt datetime
as 
update Product set Name=@Name, Price = @Price, Brand = @Brand, UpdatedAt=@UpdatedAt where Id = @Id 
return

go
use Products
go

create procedure post
(
@Name varchar(255),
@Price real,
@Brand varchar(255),
@CreatedAt datetime,
@UpdatedAt datetime)
as 
insert into Product(Name, Price,Brand,CreatedAt,UpdatedAt) values (@Name, @Price, @Brand,@CreatedAt,@UpdatedAt)
return

go
use Products
go

create procedure delet
@Id int
as delete from Product where Id = @Id
return

go
use Products
go

create procedure getbyId
@Id int
as select * from Product where Id = @Id
return