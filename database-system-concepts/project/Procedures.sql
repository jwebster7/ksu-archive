--procedures that create new entries in tables
--Add movies:
--1. Adding a movie to the moviesTable: title, year, rating, genre, star rating, duration
drop procedure if exists AddMovie
go
CREATE PROCEDURE AddMovie
   @MovieName nvarchar(256),
   @Year int,
   @duration int,
   @rating float,
   @genreID nvarchar(100)

AS
Insert group13proj.Movie(MovieTitle, ReleaseYear, Duration, Rating, GenreID)
values(@MovieName, @Year, @duration, @rating,@genreID)
GO

--Create account:
--1. EMployee enters in the fname, lname, email, phone
Drop Procedure if exists CreateAccount
go
CREATE PROCEDURE CreateAccount
   @FirstName nvarchar(32),
   @LastName NVARCHAR(32),
   @PhoneNumber NVARCHAR(15),
   @Email NVARCHAR(64)
AS
Insert group13proj.Account(FirstName, LastName, PhoneNumber, Email)
values(@FirstName, @LastName, @PhoneNumber, @Email)
GO


--Modify account:
--1. look up the account using the email and modify the optional parameters: fname, lname, email, phone
drop procedure if exists ModifyAccount
go
create procedure ModifyAccount
@OldEmail nvarchar(64),
@NewEmail nvarchar(64),
@FirstName nvarchar(256)= null,
@LastName NVARCHAR(32) =null,
@PhoneNumber NVARCHAR(15) =null
AS
update group13proj.Account
set FirstName = Coalesce(@FirstName, FirstName),
    LastName = Coalesce(@LastName, LastName),
	PhoneNumber = Coalesce(@PhoneNumber, PhoneNumber),
	Email = Coalesce(@NewEmail, email)
where Email = @OldEmail
go

--Delete account:
--1. ask for email and check if any rentals are due. if yes, dont delete, otherwise delete from database
drop procedure if exists DeleteAccount
go
CREATE PROCEDURE DeleteAccount
   @Email NVARCHAR(64)
AS
Delete A
from group13proj.Account A
where A.Email = @Email and A.AccountID not in(select R.AccountID from group13proj.Rental R )
go



--This is the initial display for the rental window, only displays the name of the movie and the number of available copies we have
drop procedure if exists initDispRental
go

create procedure initDispRental As
Select M.MovieTitle, count(distinct i.InventoryID) as [copies]
from group13proj.Inventory I
	inner join group13proj.Movie M on m.MovieID = i.MovieID
where i.Rented = 0
group by M.MovieTitle
go




--summary of account's rentals to be displayed 
drop procedure if exists acctRentals
go
create procedure acctRentals
@email nvarchar(64)
as
select m.MovieTitle, r.RentalDate, r.DueDate
from group13proj.Rental R
	inner join group13proj.Account A on A.Email=@email
	inner join group13proj.Inventory I on i.InventoryID = r.InventoryID
	inner join group13proj.Movie m on m.MovieID = i.MovieID
where R.AccountID=A.AccountID
go


--looks up a customers information to be displayed in the modify account window
drop procedure if exists modAcctLookup
go
create procedure modAcctLookup
@email Nvarchar(64)
as
select a.Email, a.PhoneNumber, a.FirstName, A.LastName
from group13proj.Account A
where a.Email = @email
go



--used to check if a movie already exists in the database when being added.
-- this currently doesn not work which means it cannot properly check the db, i need to sleep on it
drop procedure if exists checkMovie
go
create procedure checkMovie
@Title NvarChar(255),
@Year int
as
Select m.MovieTitle
from group13proj.Movie M
where m.ReleaseYear = @year and m.MovieTitle=@Title
go

--Adds the movie to the inventory table based on the given title and year
drop procedure if exists AddInventory
go
create procedure AddInventory
@Title NvarChar(255),
@Year int
as
Insert group13proj.Inventory(MovieID)
Select m.MovieID
from group13proj.Movie M
where m.MovieTitle = @Title and m.ReleaseYear = @Year
go

--Adds a new line to the Rental table based on the given email and movie title
drop procedure if exists rentMovie
go
create procedure rentMovie
@title NVarChar(255), @email NvarChar(64)
as
Insert group13proj.Rental(InventoryID, AccountID)
Select Top(1)
	    I.InventoryID, a.AccountID
from group13proj.Movie M
	inner join group13proj.Inventory I on I.MovieID = M.MovieID and i.Rented = 0
	inner join group13proj.Account A on a.Email = @email
where M.MovieTitle = @title;
declare @rID int = Scope_Identity();
select r.DueDate
from group13proj.Rental r
where r.RentalID = @rID
go
--trigger that updates the inventory table to reflect when a movie has been rented
DROP TRIGGER IF EXISTS group13proj.tr_InsertingRentals;
GO
CREATE TRIGGER group13proj.tr_InsertingRentals ON group13proj.Rental
AFTER insert
AS
update group13proj.Inventory
set 
rented = 1
from group13proj.Inventory i
where i.InventoryID = ( select top 1 i.InventoryID
					  from inserted ins
					  inner join group13proj.Inventory i on ins.InventoryID = i.InventoryID
					  order by ins.RentalID desc
					 )
GO

--removes a line from the Rental table based on the given email and movie title, also updates the inventory table to reflect that the movie rented was returned
drop procedure if exists returnRental
go
create procedure returnRental
@movieTitle nvarchar(255),
@email nvarchar(150)
as
update top (1) I
set Rented = 0
from group13proj.Inventory I
inner join group13proj.Movie M on M.MovieTitle=@movieTitle
where I.MovieID= M.MovieID;
delete top (1) R
from group13proj.Rental R
inner join group13proj.Account A on A.Email=@email
inner join group13proj.Movie M on M.MovieTitle=@movieTitle 
inner join group13proj.Inventory I on I.MovieID=M.MovieID 
where R.AccountID=A.AccountID and R.InventoryID=I.InventoryID
go


/************************************************************************************************************************/
--Filtering stuff
--filtering for the movie name is going to be done on the front end

--*********************************************************************************************************************
--final filtering procedures
 --*********************************************************************************************************
--helper procedure; filters the movie table on duration
drop procedure if exists durationFilter
go
create procedure durationFilter
@durationL int =null,
@durationG int =null,
@doperatorL nchar(1)=null,
@doperatorG nchar(1)=null
as
if (@durationL is not null and @durationG is not null and @doperatorG is not null and @doperatorL is not null)
select *
from group13proj.Movie M where M.Duration>=@durationG
intersect
select * from group13proj.Movie M where M.Duration<=@durationL
else if (@durationL is not null and @durationG is null and @doperatorG is null and @doperatorL is not null)
select *
from group13proj.Movie M where M.Duration<=@durationL
else if(@durationL is null and @durationG is not null and @doperatorG is not null and @doperatorL is null)
select * from group13proj.Movie M where M.Duration>=@durationG
go
--Helper Procedure; filters the movie table on rating
drop procedure if exists ratingFilter
go
create procedure ratingFilter
@ratingL int =null,
@ratingG int = null,
@roperatorL nchar(1)=null,
@roperatorG nchar(1)=null
as
if (@ratingL is not null and @ratingG is not null and @roperatorG is not null and @roperatorL is not null)
select *
from group13proj.Movie M where M.rating>=@ratingG
intersect
select * from group13proj.Movie M where M.rating<=@ratingL
else if (@ratingL is not null and @ratingG is null and @roperatorG is null and @roperatorL is not null)
select *
from group13proj.Movie M where M.rating<=@ratingL
else if(@ratingL is null and @ratingG is not null and @roperatorG is not null and @roperatorL is null)
select * from group13proj.Movie M where M.rating>=@ratingG
go

--Helper procedure; filters the movie table on the release year
drop procedure if exists yearFilter
go
create procedure yearFilter
@yearL int =null,
@yearG int = null,
@yoperatorL nchar(1)=null,
@yoperatorG nchar(1)=null
as
if (@yearL is not null and @yearG is not null and @yoperatorG is not null and @yoperatorL is not null)
select *
from group13proj.Movie M where M.ReleaseYear>=@yearG
intersect
select * from group13proj.Movie M where M.ReleaseYear<=@yearL
else if (@yearL is not null and @yearG is null and @yoperatorG is null and @yoperatorL is not null)
select *
from group13proj.Movie M where M.ReleaseYear<=@yearL
else if(@yearL is null and @yearG is not null and @yoperatorG is not null and @yoperatorL is null)
select * from group13proj.Movie M where M.ReleaseYear>=@yearG
go

--helper procedure; filters the movie table by genre
drop procedure if exists GenresFilter
go
create procedure GenresFilter
@id nvarchar(100)=null
as
if(@id is not null )
select *
from group13proj.Movie M
where M.GenreID like '%, '+@id+',%' or M.GenreID like '%, '+ @id or M.GenreID like @id+',%'
    
go




--Overall filter procedure, takes in all the parameters and decides which of the helper functions to call, returns the result of all the applied filters.
drop procedure if exists allFilters2
go
create procedure allfilters2
@dG int=null,
@dL int=null,
@doG nchar(1)=null,
@doL nchar(1)=null,
@rG int=null,
@rL int=null,
@roG nchar(1)=null,
@roL nchar(1)=null,
@yG int=null,
@yL int=null,
@yoG nchar(1)=null,
@yoL nchar(1)=null,
@genreId nvarchar(100)=null
as


drop table if exists #yTable
create table #yTable(
	MovieID int not null identity(1,1) ,
	MovieTitle NVARCHAR(255) not null,
	ReleaseYear int not null,
	Duration int null,
	Rating float,
	GenreID nvarchar(100)  null
);
drop table if exists #rTable
create table #rTable(
	MovieID int not null identity(1,1),
	MovieTitle NVARCHAR(255) not null,
	ReleaseYear int not null,
	Duration int null,
	Rating float,
	GenreID nvarchar(100)  null
);
drop table if exists #dTable
create table #dTable(
	MovieID int not null identity(1,1) ,
	MovieTitle NVARCHAR(255) not null,
	ReleaseYear int not null,
	Duration int null,
	Rating float,
	GenreID nvarchar(100)  null
);
drop table if exists #gTable
create table #gTable(
	MovieID int not null identity(1,1) ,
	MovieTitle NVARCHAR(255) not null,
	ReleaseYear int not null,
	Duration int null,
	Rating float,
	GenreID nvarchar(100)  null
);




if(@yG is null and @yoG is null and @yL is not null and @yoL is not null)
insert into #yTable(MovieID, MovieTitle, ReleaseYear, Duration, Rating, GenreID)
exec yearFilter @yearL=@yL, @yoperatorL=yoL
else if (@yG is not null and @yoG is not null and @yL is null and @yoL is null)
insert into #yTable(MovieID, MovieTitle, ReleaseYear, Duration, Rating, GenreID)
exec yearFilter @yearG=@yG, @yoperatorG=yoG
else if (@yG is not null and @yoG is not null and @yL is  not null and @yoL is not null)
insert into #yTable(MovieID, MovieTitle, ReleaseYear, Duration, Rating, GenreID)
exec yearFilter @yearG=@yG, @yoperatorG=yoG, @yearL=@yL, @yoperatorL=yoL
else if (@yG is null and @yoG is null and @yL is null and @yoL is null)
insert into #yTable(MovieTitle, ReleaseYear, Duration, Rating, GenreID)
select M.MovieTitle, M.ReleaseYear,M.Duration, M.Rating, M.GenreID from group13proj.Movie M;

if(@rG is null and @roG is null and @rL is not null and @roL is not null)
insert into #rTable(MovieID, MovieTitle, ReleaseYear, Duration, Rating, GenreID)
exec ratingFilter @ratingL=@rL, @roperatorL=roL
else if (@rG is not null and @roG is not null and @rL is null and @roL is null)
insert into #rTable(MovieID, MovieTitle, ReleaseYear, Duration, Rating, GenreID)
exec ratingFilter @ratingG=@rG, @roperatorG=roG
else if (@rG is not null and @roG is not null and @rL is  not null and @roL is not null)
insert into #rTable(MovieID, MovieTitle, ReleaseYear, Duration, Rating, GenreID)
exec ratingFilter @ratingG=@rG, @roperatorG=roG, @ratingL=@rL, @roperatorL=roL
else if (@rG is null and @roG is null and @rL is null and @roL is null)
insert into #rTable(MovieTitle, ReleaseYear, Duration, Rating, GenreID)
select M.MovieTitle, M.ReleaseYear,M.Duration, M.Rating, M.GenreID from group13proj.Movie M;

if(@dG is null and @doG is null and @dL is not null and @doL is not null)
insert into #dTable(MovieID, MovieTitle, ReleaseYear, Duration, Rating, GenreID)
exec durationFilter @durationL=@dL, @doperatorL=doL
else if (@dG is not null and @doG is not null and @dL is null and @doL is null)
insert into #dTable(MovieID, MovieTitle, ReleaseYear, Duration, Rating, GenreID)
exec durationFilter @durationG=@dG, @doperatorG=doG
else if (@dG is not null and @doG is not null and @dL is  not null and @doL is not null)
insert into #dTable(MovieID, MovieTitle, ReleaseYear, Duration, Rating, GenreID)
exec durationFilter @durationG=@dG, @doperatorG=doG, @durationL=@dL, @doperatorL=doL
else if (@dG is null and @doG is null and @dL is null and @doL is null)
insert into #dTable(MovieTitle, ReleaseYear, Duration, Rating, GenreID)
select M.MovieTitle, M.ReleaseYear,M.Duration, M.Rating, M.GenreID from group13proj.Movie M;


if(@genreId is not null)
insert into #gTable(MovieID, MovieTitle, ReleaseYear, Duration, Rating, GenreID)
exec GenresFilter @genreId
else if (@genreId is null)
insert into #gTable(MovieTitle, ReleaseYear, Duration, Rating, GenreID)
select  M.MovieTitle, M.ReleaseYear, M.Duration, M.Rating, M.GenreID from group13proj.Movie M;

select * from #yTable
intersect
select* from #dTable
intersect
select* from #rTable
intersect
select * from #gTable
go

--Used to find customers with overdue rentals
drop procedure if exists OverdueRentals
go 
create procedure OverDueRentals
as
select a.Email, m.MovieTitle, r.DueDate
from group13proj.Rental r
inner join group13proj.Account a on r.AccountID = a.AccountID
inner join group13proj.Inventory i on r.InventoryID = i.InventoryID
inner join group13proj.Movie m on m.MovieID = i.MovieID
where  r.DueDate <= getDate()
go
