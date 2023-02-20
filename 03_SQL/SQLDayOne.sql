-- SQL
-- Structured Query Language
-- In SQL, we use tables and rows to organize our data
-- SQL is considered a declarative language, which means we tell them what we want
-- instead of how to exactly do something

-- Declarative vs Imperative

-- To create a table, use Create keyword
-- Create Table TABLE_NAME (
-- configure our columns here
-- );
-- CREATE keyword is part of Data Definition Language(DDL) which contains keywords to define your data
-- use DROP keyword to completely remove the resource (table, etc) with no trace remaining 
Drop Table Exercises;
Drop Table WorkoutSessions;
Truncate Table WorkoutSessions;

-- Primary Key is a set of one or more columns we use to uniquely identify a row in a table
-- They can't be duplicates nor they can be left empty

-- Constraints further define the valid dataset in your table
-- some examples of constraints are: primary key, foreign key, not null, unique, default, check, etc.
Create Table WorkoutSessions (
    Id int PRIMARY KEY IDENTITY(1, 1),
    WorkoutDate datetime default getdate(),
    WorkoutName nvarchar(50) default getdate()
);

Create Table Exercises (
    Id int PRIMARY KEY IDENTITY(1, 1),
    ExerciseName varchar(100) not null,
    ExerciseNote varchar(255),
    WorkoutId int FOREIGN KEY REFERENCES WorkoutSessions(Id)
);

-- To add a row to table, use INSERT keyword
INSERT INTO WorkoutSessions(WorkoutDate) Values (getdate());
INSERT INTO Exercises(ExerciseName, ExerciseNote, WorkoutId) Values ('jog', '1mi along the creek', 2);
-- To retrieve the data use SELECT keyword
SELECT Id, WorkoutDate, WorkoutName FROM WorkoutSessions;

-- Get all the columns from the following table
SELECT * FROM WorkoutSessions;
select * from Exercises;
-- use Delete keyword to get rid of 1 or more specific rows
DELETE FROM WorkoutSessions WHERE Id = 1;

-- INSERT / Delete is part of Data Manipulation Language (DML) which modifies one or more rows

-- Sublanguages in SQL (DDL, DML, DQL, TCL, etc.) are a way to categorize different keywords according their functionality
-- Data Definition Language : deals with the structure of the data
--     CREATE, ALTER, DROP, TRUNCATE
-- Data Manipulation Language : Modifies the rows in the table
--     INSERT, DELETE, UPDATE
-- Data Query Language : SELECT statement, use this to query your tables or find data in our tables