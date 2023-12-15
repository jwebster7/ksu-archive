create schema group13proj
go

create table group13proj.Genre
(
	GenreID int not null Identity(1,1) primary key,
	GenreName NVarchar(64) not null
)

create table group13Proj.Movie(
	MovieID int not null identity(1,1) primary key,
	MovieTitle NVARCHAR(100) not null,
	ReleaseDate Date not null,
	Duration int not null,
	Rating int,
	GenreID int not null foreign key references group13proj.genre(GenreID)
)


create table group13proj.Inventory
(
	InventoryID int not null identity(1,1) primary key,
	MovieID int not null foreign key references group13Proj.movie(movieID),
	Rented int not null default 0
)

create table group13proj.Account
(
	AccountID int not null identity(1,1) primary key,
	FirstName NVARCHAR(32) not null,
	LastName NVARCHAR(32) not null,
	PhoneNumber NVARCHAR(15) not null,
	Email NVARCHAR(64) not null unique
)

create table group13proj.Rental
(
	RentalID int not null identity(1,1) primary key,
	InventoryID int not null foreign key references group13proj.Inventory(InventoryID),
	RentalDate date not null,
	DueDate date not null,
	AccountID int not null foreign key references group13proj.Account(AccountID)

)