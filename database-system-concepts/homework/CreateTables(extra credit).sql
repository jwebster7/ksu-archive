/* Editor: Joseph Webster
 * Author: John Keller
 * Assignment: Extra Credit
 */
IF SCHEMA_ID(N'Person') IS NULL
   EXEC(N'CREATE SCHEMA Person');
GO

DROP TABLE IF EXISTS Person.Student;
DROP TABLE IF EXISTS Person.Instructor;
DROP TABLE IF EXISTS Person.Person;
DROP TABLE IF EXISTS Person.PersonType;
GO

CREATE TABLE Person.PersonType
(
   PersonTypeId TINYINT NOT NULL,
   [Name] NVARCHAR(16) NOT NULL,

   CONSTRAINT PK_Person_PersonType_PersonTypeId PRIMARY KEY CLUSTERED
   (
      PersonTypeId ASC
   ),

   CONSTRAINT UK_Person_PersonType_Name UNIQUE NONCLUSTERED
   (
      [Name] ASC
   )
);

CREATE TABLE Person.Person
(
   PersonId INT NOT NULL IDENTITY(1, 1),
   Email NVARCHAR(128) NOT NULL,
   PersonTypeId TINYINT NOT NULL,
   FirstName NVARCHAR(32) NOT NULL,
   LastName NVARCHAR(32) NOT NULL,

   CONSTRAINT PK_Person_Person_PersonId PRIMARY KEY CLUSTERED
   (
      PersonId ASC
   ),

   CONSTRAINT UK_Person_Person_Email UNIQUE NONCLUSTERED
   (
      Email ASC
   ),

   CONSTRAINT FK_Person_Person_Person_PersonType FOREIGN KEY
   (
      PersonTypeId
   )
   REFERENCES Person.PersonType
   (
      PersonTypeId
   )
);

CREATE TABLE Person.Instructor
(
   PersonId INT NOT NULL,
   PersonTypeId TINYINT NOT NULL,
   Department NVARCHAR(64) NOT NULL,
   Phone NVARCHAR(16) NOT NULL,
   Building NVARCHAR(32) NOT NULL,
   Room NVARCHAR(8) NOT NULL,

   CONSTRAINT PK_Person_Instructor_PersonId PRIMARY KEY CLUSTERED
   (
      PersonId ASC
   ),

   CONSTRAINT FK_Person_Instructor_Person_Person FOREIGN KEY
   (
      PersonId
   )
   REFERENCES Person.Person
   (
      PersonId
   ),
   -- added constraint to check if the person type is correct. 
   -- Insert/Update should fail if it has the incorrect PersonTypeId
   CONSTRAINT InstructorCheck CHECK 
   (
	  PersonTypeId = 1
   )
);

CREATE TABLE Person.Student
(
   PersonId INT NOT NULL,
   PersonTypeId TINYINT NOT NULL,
   ExpectedGraduation NVARCHAR(12) NOT NULL,
   Degree NVARCHAR(32) NOT NULL,

   CONSTRAINT PK_Person_Student_PersonId PRIMARY KEY CLUSTERED
   (
      PersonId ASC
   ),

   CONSTRAINT FK_Person_Student_Person_Person FOREIGN KEY
   (
      PersonId
   )
   REFERENCES Person.Person
   (
      PersonId
   ),
   -- added constraint to check if the person type is correct. 
   -- Insert/Update should fail if it has the incorrect PersonTypeId
   CONSTRAINT StudentCheck CHECK 
   (
	  PersonTypeId = 2
   )
);
GO

INSERT Person.PersonType(PersonTypeId, [Name])
VALUES
   (1, N'Instructor'),
   (2, N'Student');

-- Checking my Check Constraints
INSERT Person.Person(Email, PersonTypeId, FirstName, LastName)
VALUES 
	(N'jwebster7@ksu.edu', 1, N'Joseph', N'Webster');

INSERT Person.Student(PersonId, PersonTypeId, ExpectedGraduation, Degree)
VALUES 
	(1, 1, N'May-2019', N'Computer Science');

INSERT Person.Instructor(PersonId, PersonTypeId, Department, Building, Room, Phone)
VALUES 
	(1, 1, N'Computer Science', N'Durland', N'1118', N'785-555-5555');

SELECT *
FROM Person.Instructor

SELECT *
FROM Person.Student
