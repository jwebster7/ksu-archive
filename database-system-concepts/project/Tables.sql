

drop table if exists group13proj.rtable
drop table if exists group13proj.gtable
drop table if exists group13proj.ytable
drop table if exists group13proj.dtable
drop table if exists group13proj.Rental
drop table if exists group13proj.Account
drop table if exists group13proj.Inventory
drop table if exists group13Proj.Movie
drop table if exists group13proj.Genre

drop schema if exists group13proj
go
create schema group13proj
go
create table group13proj.Genre
(
	GenreID int not null identity(1,1) primary key,
	GenreName NVarchar(64) not null
)

--Populating the group13proj.Genre table
insert group13proj.Genre(GenreName)
select Genre
from dbo.GenreTable
select * from group13proj.Genre
order by GenreID asc

create table group13Proj.Movie(
	MovieID int not null identity(1,1) primary key,
	MovieTitle NVARCHAR(255) not null,
	ReleaseYear int not null,
	Duration int null,
	Rating float,
	GenreID nvarchar(100)  null,
	unique(MovieTitle, ReleaseYear)
)




--populating the group13proj.Movie table
insert group13Proj.Movie(MovieTitle, ReleaseYear, Duration, Rating, GenreID)
select MovieTitle, CAST(ReleaseYear AS INT), Duration, Rating, Genre_ID_ForMovie
from dbo.MovieDatabase


create table group13proj.Inventory
(
	InventoryID int not null identity(1,1) primary key,
	MovieID int not null foreign key references group13Proj.movie(movieID),
	Rented int not null default 0
)
--populating the inventory table
insert group13proj.Inventory(MovieID)
select M.MovieID
from group13proj.Movie M
create table group13proj.Account
(
	AccountID int not null identity(1,1) primary key,
	FirstName NVARCHAR(32) not null,
	LastName NVARCHAR(32) not null,
	PhoneNumber NVARCHAR(15) not null,
	Email NVARCHAR(64) not null unique
)
--populating Account
insert group13proj.Account(FirstName, LastName, PhoneNumber, Email)
select FirstName, LastName, Phone, Email
from dbo.Accounts
select* from group13proj.Account

create table group13proj.Rental
(
	RentalID int not null identity(1,1) primary key,
	InventoryID int not null foreign key references group13proj.Inventory(InventoryID),
	RentalDate dateTime not null default getdate() ,
	DueDate dateTime not null default ( getdate()+5),
	AccountID int not null foreign key references group13proj.Account(AccountID),
);
--inserting multiple copies
drop procedure if exists createDuplicates
go
create procedure createDuplicates
as
declare @movieIndex int = 0;
while @movieIndex<=931
begin
insert group13proj.Inventory(MovieID, Rented)
select M.MovieID, 0
from group13proj.Movie M
where M.MovieID=@movieIndex
set @movieIndex= @movieIndex+6
end;
go

exec createDuplicates 
