/******************
 * Question 1
 ******************/

SELECT S.LastName, S.FirstName, S.StudentID, C.Name AS CourseName
FROM Term T
   INNER JOIN ScheduledCourse SC ON SC.TermID = T.TermID
   INNER JOIN Course C ON C.CourseID = SC.CourseID
   INNER JOIN EnrolledStudent ES ON ES.ScheduledCourseID = SC.ScheduledCourseID
   INNER JOIN Student S ON S.StudentID = ES.StudentID
WHERE T.Name = N'Fall 2018'
   AND C.Name IN (N'CIS 560', N'CIS 562')
ORDER BY S.LastName ASC, S.FirstName ASC, S.StudentID ASC;


/******************
 * Question 2
 ******************/

SELECT I.InstructorID, I.LastName, I.FirstName
FROM Instructors I
   LEFT JOIN ScheduledCourse SC ON SC.InstructorID = I.InstructorID
   LEFT JOIN Term T ON T.TermID = SC.TermID
      AND T.Name = N'Fall 2018'
WHERE T.TermID IS NULL
ORDER BY I.LastName ASC, I.FirstName ASC, I.InstructorID ASC;

/******************
 * Question 3
 ******************/

-- Solution with self-contained subquery

SELECT I.InstructorID, I.LastName, I.FirstName
FROM Instructors I
WHERE I.InstructorID NOT IN
   (
      SELECT SC.InstructorID
      FROM Term T
         INNER JOIN ScheduledCourse SC ON SC.TermID = T.TermID
      WHERE T.Name = N'Fall 2018'
   )
ORDER BY I.LastName ASC, I.FirstName ASC, I.InstructorID ASC;

-- Solution with correlated subquery 

SELECT I.InstructorID, I.LastName, I.FirstName
FROM Instructors I
WHERE NOT EXISTS
   (
      SELECT *
      FROM ScheduledCourse SC
         INNER JOIN Term T ON T.TermID = SC.TermID
      WHERE SC.InstructorID = I.InstructorID
         AND T.Name = N'Fall 2018'
   )
ORDER BY I.LastName ASC, I.FirstName ASC, I.InstructorID ASC;


/******************
 * Question 4
 ******************/

WITH StudentCountCte(TermID, TermName, TermFirstDate, CourseID, InstructorID, StudentCount, PassingStudentCount) AS
   (
      SELECT T.TermID, T.Name, T.FirstDate, SC.CourseID, SC.InstructorID, COUNT(*),
         SUM(IIF(ES.FinalGrade >= 70, 1, 0))
      FROM Term T
         INNER JOIN ScheduledCourse SC ON SC.TermID = T.TermID
         INNER JOIN EnrolledStudent ES ON ES.ScheduledCourseID = SC.ScheduledCourseID
      WHERE T.FirstDate >= '2014-08-01'
      GROUP BY SC.CourseID, SC.InstructorID, T.TermID, T.Name, T.FirstDate
   )
SELECT SC.TermName, I.InstructorID, I.LastName + N', ' + I.FirstName AS InstructorName, C.Name AS CourseName,
   100.0 * SC.PassingStudentCount / SC.StudentCount AS PassingPercent,
   100.0 * SUM(SC.PassingStudentCount) OVER(PARTITION BY SC.CourseID, SC.InstructorID)
      / SUM(SC.StudentCount) OVER(PARTITION BY SC.CourseID, SC.InstructorID) AS CourseAndInstructorPassingPercent,
   100.0 * SUM(SC.PassingStudentCount) OVER(PARTITION BY SC.CourseID)
      / SUM(SC.StudentCount) OVER(PARTITION BY SC.CourseID) AS CoursePassingPercent
FROM StudentCountCte SC
   INNER JOIN Course C ON C.CourseID = SC.CourseID
   INNER JOIN Instructor I ON I.InstructorID = SC.InstructorID
ORDER BY SC.TermFirstDate ASC, C.Name ASC;


/******************
 * Question 5
 ******************/

DECLARE @StudentID INT = 1;

SELECT T.[Name] AS TermName, C.[Name] AS CourseName, SCG.FinalGrade, SCG.FinalLetterGrade,
   LAG(SCG.FinalGrade) OVER(PARTITION BY C.CourseID ORDER BY T.FirstDate ASC) AS PriorGrade,
   LAG(SCG.FinalLetterGrade) OVER(PARTITION BY C.CourseID ORDER BY T.FirstDate ASC) AS PriorLetterGrade
FROM
      (
         SELECT ES.ScheduledCourseID, ES.FinalGrade,
            CASE
               WHEN ES.FinalGrade >= 90.0 THEN N'A'
               WHEN ES.FinalGrade >= 80.0 THEN N'B'
               WHEN ES.FinalGrade >= 70.0 THEN N'C'
               WHEN ES.FinalGrade >= 60.0 THEN N'D'
               ELSE N'F'
            END AS FinalLetterGrade
         FROM EnrolledStudent ES
         WHERE ES.StudentID = @StudentID
      ) SCG
   INNER JOIN ScheduledCourse SC ON SC.ScheduledCourseID = SCG.ScheduledCourseID
   INNER JOIN Term T ON T.TermID = C.TermID
   INNER JOIN Course C ON C.CourseID = SC.CourseID
ORDER BY T.FirstDate ASC, C.[Name] ASC;
