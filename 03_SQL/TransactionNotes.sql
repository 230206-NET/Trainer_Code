-- Transaction
-- Represents unit of work that either succeeds together or fails together

-- Sublanguage: Transaction Control Language(TCL)
-- Commit
-- Rollback
-- Savepoint

-- Properties of Transaction (ACID)
-- Atomicity : All the statements in transaction needs to either succeed or fail as whole
-- Consistency : When the transaction commits, it should change the state of db
-- Isolation(*): Transaction should be isolated and free from other transaction's work
-- Durability: If transaction commits, it should still be saved in persistent storage

-- Transaction and Concurrency
-- Isolation Levels:
-- Phenomena:
        -- Dirty Read: Read Uncommitted changes from another transaction
        -- NonRepeatable Read: Read Committed changes from another transaction
        -- Phantom: See newly created rows from another transaction
    -- Isolation Levels:
        -- Read Uncommitted: allows Dirty reads, Nonrepeatable reads, phantoms
        -- Read Committed: allows Nonrepeatable reads, phantoms
        -- Repeatable Read: allows phantoms
        -- Serializable: safe from all concurrancy phenomena
    -- There is a trade off with the isolation- the more you isolate transaction, the slower your db operation will be

-- Microsoft Learn on Transaction: https://learn.microsoft.com/en-us/sql/t-sql/language-elements/transactions-transact-sql?view=sql-server-ver16
-- Writing Transaction in ADO.NET: https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/local-transactions
-- Microsoft Ref on Isolation Levels: https://learn.microsoft.com/en-us/sql/odbc/reference/develop-app/transaction-isolation-levels?view=sql-server-ver16

-- Transaction to insert workout session row as well as all the related exercises
BEGIN TRAN CreateWorkout
BEGIN TRY
    INSERT INTO WorkoutSessions (WorkoutName, WorkoutDate) Values ('2/22 quads', getdate());
    DECLARE @wId INT
    SET @wId = SCOPE_IDENTITY()
    INSERT INTO Exercises(ExerciseName, ExerciseNote) Values ('squats', '350lb'), ('deadlift', '500lb');
    COMMIT TRANSACTION
END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION
END CATCH

Select * FROM WorkoutSessions;
Select * FROM Exercises;