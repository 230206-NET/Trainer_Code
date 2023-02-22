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
INSERT INTO WorkoutSessions(WorkoutName) Values ('Quads workout');
INSERT INTO Exercises(ExerciseName, ExerciseNote, WorkoutId) Values ('jog', '1mi along the creek', 2);
-- To retrieve the data use SELECT keyword
SELECT Id, WorkoutDate, WorkoutName FROM WorkoutSessions;

-- Get all the columns from the following table
SELECT WorkoutSessions.Id as wId, WorkoutDate, WorkoutName, Exercises.Id as eId, ExerciseName, ExerciseNote FROM Exercises right join WorkoutSessions on WorkoutSessions.Id = Exercises.WorkoutId;
select * from WorkoutSessions
select * from Exercises;

INSERT INTO WorkoutSessions(WorkoutName) OUTPUT INSERTED.Id Values ('evening run')
-- use Delete keyword to get rid of 1 or more specific rows
DELETE FROM WorkoutSessions WHERE Id = 1;

-- INSERT / Delete is part of Data Manipulation Language (DML) which modifies one or more rows

-- Sublanguages in SQL (DDL, DML, DQL, TCL, DCL etc.) are a way to categorize different keywords according their functionality
-- Data Definition Language : deals with the structure of the data
--     CREATE, ALTER, DROP, TRUNCATE
-- Data Manipulation Language : Modifies the rows in the table
--     INSERT, DELETE, UPDATE
-- Data Query Language : SELECT statement, use this to query your tables or find data in our tables

-- Normalization is a database design technique that helps to reduce data redundancy and improve data consistency

-- There are many normal forms that builds upon each other, but we normally use upto 3rd normal form
-- 1st Normal Form
-- All cells must have 0 or 1 data (atomicity)
-- All rows must be uniquely identifiable (aka, must have a primary key) 

-- 2nd Normal Form
-- It has to be in 1NF
-- It can't have Partial Dependency
    -- Partial Dependency is when a NON-KEY column depends on only one part of the key
-- The fastest way to achieve 2NF, is to be in 1NF, and not have a composite key

-- 3rd Normal Form
-- 2NF
-- It can't have transitive dependency between non-key columns
    -- !(if A => B and B => C then A => C)

-- The data in the table has to have a key (1NF), depend on the whole key(2NF), and nothing but the key(3NF)

-- Keys
-- When we use more than 1 column to uniquely id a row, we call that a composite key

-- The easiest way to design a db that satisfies normal forms is to start from cardinality between entities
-- Workout - Exercises
-- 1 - many 

-- Human - Pet
-- 1 - many

-- monogamous relationship
-- human - human
-- 1 - 1

-- Human - Firstname
-- 1 - 1

-- trainer - associate
-- Many - Many

-- Professor - student
-- many - many

-- In implementing 1 - Many
-- create two tables, with foreign key reference of One in the Many table
-- Workout - Exercises
-- Foreign key reference for workout table in Exercise table

-- User - Pets
-- User table and pets table
-- user table has foreign key reference to pets
drop table users;
drop table pets;


Create Table Users(
    id int primary key identity,
    name varchar(max)

)
create table pets(
    id int primary key IDENTITY,
    name varchar(max),
    userId int FOREIGN key references users(id)
);

INSERT into pets(name) values ('auryn');
select * from pets;
INSERT into Users(name) values('juniper'), ('richard');
select * from users;

insert into pets(name, userId) values ('fenris', 2), ('merry', 2), ('remington', 2), ('claude', 2);

-- 1 - 1
-- Depends on data, but if the data is directly associated with the entity, then store as column
-- if not, foreign key reference that is not null and unique

-- Person - Firstname/Lastname
-- Person - SSN

-- Person - their primary phone (in this case, where the primary phone serial # isn't directly associated with the person info itself, you might want to put it elsewhere)

-- M - M
-- Pets - Humans (in a more realistic scenario)
-- Create a separate Join / Junction table that will map the relationship


Create Table Users(
    id int primary key identity,
    name varchar(max)
);
create table pets(
    id int primary key IDENTITY,
    name varchar(max)
);

-- this join table maps pk from one table to pk in another table
Create Table userPets(
    id int primary key identity,
    userId int FOREIGN key references Users(id),
    petId int foreign key references pets(id)
)

select * from users;
select * from pets;
select * from userpets;

insert into users(name) values ('richard'), ('rachel');
insert into pets(name) values ('fenris'), ('merry'), ('remington'), ('claude');

insert into userpets(userid, petid) values (1, 1), (1, 2), (1, 3), (1, 4), (2, 1), (2, 2), (2, 3), (2, 4);