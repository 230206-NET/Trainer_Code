-- SQL (structured query language) vs T-SQL
-- T-SQL is an extension of SQL that brings programmatic functionalities to SQL
-- IF/ELSE, WHILE, TRY/CATCH, Variable, etc.
-- Transact-SQL is used by default in SQL Server

-- https://www.sqlservertutorial.net/

-- User Defined Functions
-- Custom function you can build to suit your own need
-- Ave(), Count(), Upper(), these are built-in functions

-- A function must have a name and a function name can never start with a special character such as @, $, #, and so on.
-- Functions only work with select statements. (No DML statements such as insert, update, delete)
-- Functions can be used anywhere in SQL, like AVG, COUNT, SUM, MIN, DATE and so on with select statements.
-- Functions compile every time.
-- Functions must return a value or result set.
-- Functions only work with input parameters.
-- Try and catch statements are not used in functions.

-- Two categories of user defined functions
-- Table valued function
-- CREATE Function CustomerAndEmployee()
-- Returns Table
-- As
-- Return (
-- SELECT CustomerId as Id, FirstName, LastName From Customer
-- UNION
-- Select EmployeeId as Id, FirstName, LastName From Employee
-- )

-- SELECT * FROM CustomerAndEmployee() as cne 
-- public List<Tickets> getAllTickets();
-- Scalar Function
-- CREATE Function CityStateConcat
-- (
--     @city nvarchar(100),
--     @state nvarchar(100)
-- )
-- Returns NVARCHAR(200)
-- As
-- BEGIN
-- return (select @city + ' ' + @state)
-- END

-- SELECT CityStateConcat(FirstName) from Customer;
-- public int numOfOpenTix()

-- Stored Procedures
-- https://learn.microsoft.com/en-us/sql/relational-databases/stored-procedures/create-a-stored-procedure?view=sql-server-ver16

-- It works with all DML/DQL statements (Select, INSERT, Delete, Update)
-- It is a prepared sql code that can be saved in db as db object
-- Control flow functionality (if/else, while, try/catch)
-- You can return something, or many things, or nothing

-- you can use functions in stored procedures
-- but you can't use stored procedures in functions

-- CREATE Procedure sp_allCustomers
-- AS
-- SELECT * FROM Customer

-- exec dbo.sp_allCustomers;

-- Stored procedure with input parameter
-- CREATE Procedure sp_filterCustomerbyFirstName @fname nvarchar(50)
-- AS
-- SELECT * FROM Customer Where Firstname like @fname

-- exec sp_filterCustomerbyFirstName @fname = '%d%'

-- CREATE Procedure sp_customerbyFirstName (
--     @fname nvarchar(50),
--     @customerCount int OUTPUT
--     )
-- AS
-- BEGIN
-- SELECT * FROM Customer Where Firstname like @fname
-- SELECT @customerCount = @@ROWCOUNT;
-- END

-- declare @customerwithACount int

-- exec sp_customerByFirstName @fname = '%a%', @customerCount = @customerwithACount OUTPUT

-- select @customerwithACount as 'numCustomers';
-- DROP PROCEDURE sp_createWorkoutTran;
-- CREATE Procedure sp_createWorkoutTran
-- AS
-- BEGIN TRAN CreateWorkout
-- BEGIN TRY
--     INSERT INTO WorkoutSessions (WorkoutName, WorkoutDate) Values ('2/22 quads', getdate());
--     DECLARE @wId INT
--     SET @wId = SCOPE_IDENTITY()
--     INSERT INTO Exercises(ExerciseName, ExerciseNote, WorkoutId) Values ('squats', '350lb', @wId), ('deadlift', '500lb', @wId);
--     COMMIT TRANSACTION
-- END TRY

-- BEGIN CATCH
--     ROLLBACK TRANSACTION
-- END CATCH

-- exec sp_createWorkoutTran

-- select * from workoutsessions
-- select * from exercises

-- Triggers
-- A trigger is a stored procedure in database which automatically invokes whenever a special event in the database occurs. For example, a trigger can be invoked when a row is inserted into a specified table or when certain table columns are being updated. 
    -- https://learn.microsoft.com/en-us/sql/t-sql/statements/create-trigger-transact-sql
    -- https://www.sqlservertutorial.net/sql-server-triggers/
    -- DML Triggers
        -- For and/or After, Instead Of
        -- Insert, Update, Delete
    -- DDL Triggers
        -- https://learn.microsoft.com/en-us/sql/relational-databases/triggers/ddl-triggers?view=sql-server-ver16 
        -- For events such as DROP_TABLE, ALTER_TABLE
    -- Logon triggers

-- Create Trigger workout_delete
--     on WorkoutSessions After DELETE
--     AS
--     BEGIN
--         Declare @id int;
--         Declare @wName varchar(100);
--         DECLARE @wDate DateTime;
--         SELECT @id = Id from DELETED
--         SELECT @wName = WorkoutName from DELETED
--         SELECT @wDate = WorkoutDate from Deleted
--         INSERT INTO DeletedWorkout (Id, WorkoutName, WorkoutDate) VALUES (@id, @wName, @wDate)
--     END;

Create Table DeletedWorkout (
    Id int PRIMARY KEY,
    WorkoutDate datetime not null,
    WorkoutName nvarchar(50) not null
);

-- delete from workoutsessions where id = 4

-- select * from workoutsessions
-- select * from DeletedWorkout
-- select * from exercises

-- CREATE TRIGGER safety   
-- ON DATABASE   
-- FOR DROP_TABLE, ALTER_TABLE   
-- AS   
--     PRINT 'You must disable Trigger "safety" to drop or alter tables!'   
--     ROLLBACK;

Disable Trigger safety on database
-- Enable Trigger safety on database

-- DROP Table Exercises

-- Cascade (foreign key constraints)
-- on delete cascade
-- on update cascade

Select * FROM WorkoutSessions;
delete from workoutsessions where id = 1
SELECT * FROM EXERCISES
select * from deletedworkout
insert into exercises(exerciseName, exerciseNote, workoutId) values('one', 'one', 1),('two', 'two', 2),('two2', 'two2', 2),('three2', 'three2', 3),('three2', 'three2', 3),('one', 'one', 1),('one', 'one', 1),('one', 'one', 1)
Drop Table Exercises
Create Table Exercises (
    Id int PRIMARY KEY IDENTITY(1, 1),
    ExerciseName varchar(100) not null,
    ExerciseNote varchar(255),
    WorkoutId int not null FOREIGN KEY REFERENCES WorkoutSessions(Id) on delete cascade
);


-- Views
-- virtual table based on the result-set of an SQL statement
-- Always shows up-to-date information
-- Useful for saving frequently used select statements

Create View CustomerPurchaseView AS
    select Customer.FirstName,Customer.LastName, Genre.GenreId, Genre.Name, I.InvoiceId, InvoiceDate, Total, Track.[Name] as TrackName, Composer from Invoice as I
    JOIN InvoiceLine ON I.InvoiceId = InvoiceLine.InvoiceId
    JOIN Track ON InvoiceLine.TrackId = Track.TrackId
    JOIN Customer ON I.CustomerId = Customer.CustomerId
    JOIN Genre ON Genre.GenreId = Track.GenreId 

select * from CustomerPurchaseView

-- Indexes
-- Database Search Optimization

-- TLDR;
-- They make searching faster*

-- Best Practices
-- Reserve using index only with big tables that gets queried a lot
-- don't use them on tables that are inserted/updated very frequently

-- Primary Key is a Clustered Index
-- columns with Unique constraint is a Non-clustered index

-- Clustered Index : Each table can only have 1
-- Non-clustered Index : Because it doesn't physically order the data, you can have many within a table

-- https://www.tutorialspoint.com/sql/sql-indexes.htm
-- https://www.geeksforgeeks.org/difference-between-clustered-and-non-clustered-index/
-- https://www.youtube.com/watch?v=ITcOiLSfVJQ