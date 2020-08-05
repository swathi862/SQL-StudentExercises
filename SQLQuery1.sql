--CREATE TABLE Cohort (
--    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--    Name VARCHAR(55) NOT NULL
--);

--CREATE TABLE Student (
--    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--    FirstName VARCHAR(55) NOT NULL,
--    LastName VARCHAR(55) NOT NULL,
--    SlackHandle VARCHAR(55) NOT NULL,
--    CohortId INTEGER NOT NULL,
--    CONSTRAINT FK_Student_Cohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
--);

--CREATE TABLE Instructor (
--    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--    FirstName VARCHAR(55) NOT NULL,
--    LastName VARCHAR(55) NOT NULL,
--    SlackHandle VARCHAR(55) NOT NULL,
--    CohortId INTEGER NOT NULL,
--    Speciality VARCHAR(55) NOT NULL,
--    CONSTRAINT FK_Instructor_Cohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id),
--);

--CREATE TABLE Exercise (
--    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--    Name VARCHAR(55) NOT NULL,
--    Language VARCHAR(55) NOT NULL
--);

--CREATE TABLE AssignedExercise (
--    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
--    StudentId INTEGER NOT NULL,
--    ExerciseId INTEGER NOT NULL,
--    CONSTRAINT FK_AssignedExercise_Student FOREIGN KEY(StudentId) REFERENCES Student(Id),
--    CONSTRAINT FK_AssignedExercise_Exercise FOREIGN KEY(ExerciseId) REFERENCES Exercise(Id)
--);


--INSERT INTO Cohort (Name) VALUES ('Cohort 1');
--INSERT INTO Cohort (Name) VALUES ('Cohort 2');
--INSERT INTO Cohort (Name) VALUES ('Cohort 3');

--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Sydney','Wait', '@sydney', 1);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Tommy','Spurlock', '@tommy', 1);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Bobby','Fitzpatrick', '@bobby', 1);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Matt','Rowe', '@matt', 1);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Jen','Johnson', '@jen', 2);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Jacob','Perry', '@jacob', 2);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Luke','Miller', '@luke', 2);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Sarah','Brooks', '@sarah', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Mandy','Campbell', '@mandy', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Barry','Griffith', '@barry', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Dylan','Bishop', '@dylan', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Mike','Hotchkiss', '@mike', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Pat','Shaver', '@pat', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Derek','Mayse', '@derekm', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Derek','Stapleton', '@dereks', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Lindsey','Crittendon', '@lindsey', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Devin','Conroy', '@devin', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Stephen','Avila', '@stephen', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Austin','Preece', '@austin', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Ashon','Woodbury', '@ashon', 3);
--INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES ('Swathi','Mukkamala', '@swathi', 3);

--INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId, Speciality) VALUES ('Jordan','Castelloe', '@jordan', 1, 'Hoagie');
--INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId, Speciality) VALUES ('Jordan','Castelloe', '@jordan', 2, 'Cats');
--INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId, Speciality) VALUES ('Jordan','Castelloe', '@jordan', 3, 'Hoagie');
--INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId, Speciality) VALUES ('Tommy','Spurlock', '@tommy', 2, 'Dancing');
--INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId, Speciality) VALUES ('Tommy','Spurlock', '@tommy', 3, 'Motvational Speeches');
--INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId, Speciality) VALUES ('Jen','Johnson', '@jen', 3, 'Folklore by Taylor Swift');
--INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId, Speciality) VALUES ('Jacob','Perry', '@jacob', 3, 'Giving Devin a hard time');

--INSERT INTO Exercise (Name, Language) VALUES ('Student Exercises', 'SQL');
--INSERT INTO Exercise (Name, Language) VALUES ('Student Exercises', 'C#');
--INSERT INTO Exercise (Name, Language) VALUES ('Trestlebridge Farms', 'C#');
--INSERT INTO Exercise (Name, Language) VALUES ('Music History', 'SQL');
--INSERT INTO Exercise (Name, Language) VALUES ('Daily Journal', 'JavaScript');
--INSERT INTO Exercise (Name, Language) VALUES ('Nutshell', 'JavaScript');
--INSERT INTO Exercise (Name, Language) VALUES ('Capstone 2', 'SQL');

--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (8,1);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (9,1);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (10,1);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (11,1);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (12,1);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (13,1);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (14,1);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (15,1);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (16,1);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (17,1);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (18,1);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (19,1);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (20,1);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (21,1);

--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (8,7);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (9,7);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (10,7);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (11,7);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (12,7);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (13,7);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (14,7);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (15,7);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (16,7);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (17,7);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (18,7);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (19,7);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (20,7);
--INSERT INTO AssignedExercise (StudentId, ExerciseId) VALUES (21,7);

--Write a query to return student first and last names with their cohort's name only for a single cohort.
--SELECT Student.FirstName, Student.LastName, Cohort.Name FROM Student LEFT JOIN Cohort ON Student.CohortId = Cohort.Id WHERE CohortId = 3;

--Write a query to return all instructors ordered by their last name.
--SELECT * FROM Instructor ORDER BY LastName;

--Write a query to return a list of unique instructor specialties.
--SELECT DISTINCT Speciality FROM Instructor;

--Write a query to return a list of all student names along with the names of the exercises they have been assigned. If an exercise has not been assigned, it should not be in the result.
--SELECT Student.FirstName, Student.LastName, Exercise.Name FROM AssignedExercise LEFT JOIN Student ON AssignedExercise.StudentId = Student.Id LEFT JOIN Exercise ON AssignedExercise.ExerciseId = Exercise.Id;

--Return a list of student names along with the count of exercises assigned to each student.
--SELECT CONCAT(Student.FirstName, ' ', Student.LastName) AS 'Full Name', COUNT(AssignedExercise.StudentId) AS 'Number of Assigned Exercises' FROM AssignedExercise LEFT JOIN Student ON AssignedExercise.StudentId = Student.Id GROUP BY CONCAT(Student.FirstName, ' ', Student.LastName);
