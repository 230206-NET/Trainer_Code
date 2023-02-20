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
Drop Table WorkoutSessions;
Truncate Table WorkoutSessions;
Create Table WorkoutSessions (
    WorkoutDate datetime,
    WorkoutName nvarchar(50)
);

Create Table Exercises (
    ExerciseName varchar(100),
    ExerciseNote varchar(255)
);

-- To add a row to table, use INSERT keyword
INSERT INTO WorkoutSessions(WorkoutDate, WorkoutName) VALUES ('2/19/23 1pm', 'mt tabor hike');

-- To retrieve the data use SELECT keyword
SELECT WorkoutDate, WorkoutName FROM WorkoutSessions;

-- Get all the columns from the following table
SELECT * FROM WorkoutSessions;

-- use Delete keyword to get rid of 1 or more specific rows
DELETE FROM WorkoutSessions WHERE WorkoutName = 'mt tabor hike';

-- INSERT / Delete is part of Data Manipulation Language (DML) which modifies one or more rows

-- Sublanguages in SQL (DDL, DML, DQL, TCL, etc.) are a way to categorize different keywords according their functionality
-- Data Definition Language : deals with the structure of the data
--     CREATE, ALTER, DROP, TRUNCATE
-- Data Manipulation Language : Modifies the rows in the table
--     INSERT, DELETE, UPDATE
-- Data Query Language : SELECT statement, use this to query your tables or find data in our tables