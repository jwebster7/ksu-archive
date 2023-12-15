-- Author: Joe Webster
-- Instructor: John Keller
-- Date: October 17th, 2018
-- Homework 4
use jwebster7

drop table if exists Homework4.MeetingAttendee;
drop table if exists Homework4.Meeting;
drop table if exists Homework4.Club;
drop table if exists Homework4.Attendee;

-- Question 1 --
create table Homework4.Attendee (
	AttendeeId int not null identity(1,1) primary key,
	Email nvarchar(128) not null unique,
	FirstName nvarchar(128) not null,
	LastName nvarchar(128) not null,
	CreatedOn datetimeoffset not null default(sysdatetimeoffset()),
	UpdatedOn datetimeoffset not null default(sysdatetimeoffset())
)

create table Homework4.Club (
	ClubId int not null identity(1,1) primary key,
	Name nvarchar(128) not null unique,
	Purpose nvarchar(256) not null,
	CreatedOn datetimeoffset not null default(sysdatetimeoffset()),
	UpdatedOn datetimeoffset not null default(sysdatetimeoffset())
)

create table Homework4.Meeting (
	MeetingId int not null identity(1,1) primary key,
	ClubId int not null foreign key references Homework4.Club(ClubId),
	MeetingTime DateTime2(0),
	Location nvarchar(128) not null,
	CreatedOn datetimeoffset not null default(sysdatetimeoffset()),
	UpdatedOn datetimeoffset not null default(sysdatetimeoffset()),

	unique 
	(
		ClubId,
		MeetingTime
	)
)

create table Homework4.MeetingAttendee (
	MeetingId int not null foreign key references Homework4.Meeting(MeetingId),
	AttendeeId int not null foreign key references Homework4.Attendee(AttendeeId),
	CreatedOn datetimeoffset not null default(sysdatetimeoffset()),

	primary key
	(
		MeetingId,
		AttendeeId
	)
)

-- Question 2 --
insert Homework4.Club([Name], Purpose)
values 
	(N'ACM', N'The Association for Computing Machinery is the professional organization for computer scientists.'),
	(N'MIS Club', N'The Kansas State MIS Club is a student driven organization focused on the management of information systems.');
insert Homework4.Meeting([ClubId], [Location], [MeetingTime])
select club.ClubId as [ClubId], location_name.Location as [Location], location_name.MeetingTime as [MeetingTime]
from 
(
	values
		(N'ACM', N'Engineering Building 1114', 'October 9, 2018 6:30pm'),
		(N'ACM', N'Engineering Building 1114', 'November 13, 2018 6:30pm'),
		(N'MIS Club', N'Business Building 2116', 'November 6, 2018 6:00pm'),
		(N'MIS Club', N'Business Building 2116', 'December 4, 2018 6:00pm')
) as location_name([ClubName], [Location], [MeetingTime])
inner join Homework4.Club club on club.Name = location_name.ClubName;

-- Question 3 --
insert Homework4.Attendee([Email], [FirstName], [LastName])
values (N'jwebster7@ksu.edu', N'Joseph', N'Webster')
declare @ArbitraryID int = ident_current(N'Homework4.Attendee');
insert Homework4.MeetingAttendee([MeetingId], [AttendeeId])
select  m.MeetingId as [MeetingId],
		@ArbitraryID as [AttendeeId]	
from Homework4.Club as c
inner join Homework4.Meeting as m on m.ClubId = c.ClubId and c.Name = 'ACM' and m.MeetingTime = 'October 9, 2018 6:30pm'

-- Question 4 --
update m
set
	m.Location = N'Business Building 4001',
	UpdatedOn = SYSDATETIMEOFFSET()
from Homework4.Meeting m
	inner join Homework4.Club c on m.ClubId = c.ClubId
where m.MeetingTime = 'December 4, 2018 6:00pm' and c.Name = 'MIS Club'