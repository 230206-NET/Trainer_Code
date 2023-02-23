using Models;
using System.Data;
using System.Data.SqlClient;
using Serilog;
namespace DataAccess;

// ADO.NET
/*
ADO.NET is a collection of tools and types for accessing databases in uniform fashion
They offer different types to handle different db's but they all inherit from the same supertype, which makes the usage about the same
*/
// To set up,
// make sure you have System.Data.SqlClient package installed on DataAccess project
// and include System.Data.SqlClient namespace

/*
Reading/writing to DB
1. Connect to DB
2. Assemble/Write the query
3. Execute it
4. Process the data or check that it's been successful
*/

/*
ADO.NET has two types of retrieving the data:

Connected architecture
    - We stay connected to the DB the entire time we're working
    - and utilize classes such as sqlCommand, SqlDatareader, etc.

Disconnected Architecture
    - Where we get all the data at once
    - and we can work with them w/o being connected to the db.

*/

public class DBRepository : IRepository
{

    /// <summary>
    /// Retrieves all workout sessions
    /// </summary>
    /// <returns>a list of workout sessions</returns>
    public List<WorkoutSession> GetAllWorkouts()
    {
        List<WorkoutSession> allWorkouts = new();
        // Equivalent to opening Azure Data Studio and filling out the new connection form
        using SqlConnection connection = new SqlConnection(Secrets.getConnectionString()); 

        // Click the "Connect" button
        connection.Open();

        using SqlCommand cmd = new SqlCommand("SELECT WorkoutSessions.Id as wID, WorkoutDate, WorkoutName, Exercises.Id as eID, ExerciseName, ExerciseNote FROM WorkoutSessions Left Join Exercises on WorkoutSessions.Id = Exercises.WorkoutId;", connection);
        using SqlDataReader reader = cmd.ExecuteReader();
        WorkoutSession workout = new();
        while(reader.Read()) {
            int wId = (int) reader["wID"];
            int? eId = reader.IsDBNull(3) ? null : (int) reader["eID"];
            if(allWorkouts.Count == 0 || wId != allWorkouts.Last().Id)
            {
                workout = new WorkoutSession {
                    Id = wId,
                    WorkoutDate = (DateTime) reader["WorkoutDate"],
                    WorkoutName = (string) reader["WorkoutName"],
                };
                allWorkouts.Add(workout);
            }
            if(eId != null) {
                workout.WorkoutExercises.Add(new Exercise {
                    Id = (int) eId,
                    Name = (string) reader["ExerciseName"],
                    Notes = (string)reader["ExerciseNote"]
                });
            }
        }

        return allWorkouts;
    }

// Connected Architecture
    // public List<Exercise> GetExercisesByWorkoutId(int id) {
    //     List<Exercise> exercises = new();
        
    //     // using statements automatically garbage collects the unmanaged resources like these once it goes out of scope
    //     // This is DIFFERENT from using Directive which is used at the top of your file to import namespaces
    //     using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());

    //     connection.Open();

    //     // Don't ever concatenate or use string interpolation for sql command, as it is vulnerable to SQL Injection
    //     // Instead use parameters
    //     using SqlCommand cmd = new SqlCommand("Select * From Exercises Where Id = @id", connection);

    //     // Parameterizing your variables will help protect against SQL injection 
    //     cmd.Parameters.AddWithValue("@id", id);

    //     using SqlDataReader reader = cmd.ExecuteReader();

    //     while(reader.Read()) {
    //         exercises.Add(new Exercise {
    //             Id = reader.GetInt32(0), //(int) reader["Id"]
    //             Name = (string) reader["ExerciseName"],
    //             Notes = (string) reader["ExerciseNote"]
    //         });
    //     }

    //     return exercises;
    // }

    // Disconnected Architecture
    public List<Exercise> GetExercisesByWorkoutId(int id) {
        Log.Information($"Getting Exericses by workout id: {id}");
    // 1. Create a DataSet to act as a container for my data
    // 2. Create a Data Adapter and configure it with our connection and initial query
    // 3. Go find your data in your dataset and translate it accordingly.

        DataSet exercisesSet = new DataSet();
        List<Exercise> exerciseList = new();
        SqlDataAdapter exerciseAdapter = new SqlDataAdapter("Select * From Exercises WHERE WorkoutId = @id", Secrets.getConnectionString());
        exerciseAdapter.SelectCommand.Parameters.AddWithValue("@id", id);

        exerciseAdapter.Fill(exercisesSet, "exerciseTable");

        DataTable? exerciseTable = exercisesSet.Tables["exerciseTable"];

        if(exerciseTable != null) {
            foreach(DataRow row in exerciseTable.Rows) {
                exerciseList.Add(new Exercise{
                    Id = (int) row["Id"],
                    Name = (string) row["ExerciseName"],
                    Notes = (string) row["ExerciseNote"]
                });
            }
        }
        return exerciseList;
    }

    /// <summary>
    /// Persists a new workout session to storage
    /// </summary>
    // public WorkoutSession CreateNewSession(WorkoutSession sessionToCreate)
    // {
    //     /*
    //     basic steps are still the same here
    //         1. connect to db
    //         2. write your query
    //         3. run your query
    //         4. hope it works
    //     */
    //     try 
    //     {
    //         using SqlConnection conn = new SqlConnection(Secrets.getConnectionString());
    //         conn.Open();

    //         using SqlCommand cmd = new SqlCommand("INSERT INTO WorkoutSessions(WorkoutName, WorkoutDate) OUTPUT INSERTED.Id Values (@wName, @wDate)", conn);
    //         cmd.Parameters.AddWithValue("@wName", sessionToCreate.WorkoutName);
    //         cmd.Parameters.AddWithValue("@wDate", sessionToCreate.WorkoutDate);

    //         int createdId = (int) cmd.ExecuteScalar();

    //         // you might want to do something if rowsAffected == 0;
    //         sessionToCreate.Id = createdId;

    //         foreach(Exercise ex in sessionToCreate.WorkoutExercises)
    //         {
    //             using SqlCommand ecmd = new SqlCommand("INSERT INTO Exercises(ExerciseName, ExerciseNote, WorkoutId) OUTPUT INSERTED.Id Values (@eName, @eNote, @wId)", conn);

    //             ecmd.Parameters.AddWithValue("@eName", ex.Name);
    //             ecmd.Parameters.AddWithValue("@eNote", ex.Notes);
    //             ecmd.Parameters.AddWithValue("@wId", createdId);


    //             int eId = (int) ecmd.ExecuteScalar();
    //             ex.Id = eId;
    //         }

    //         return sessionToCreate;
    //     }
    //     catch (SqlException ex) {
    //         Log.Warning("Caught SQL Exception trying to create new workout {0}", ex);
    //         throw ex;
    //     }
    // }

    public WorkoutSession CreateNewSession(WorkoutSession sessionToCreate)
    {
        // Even when only persisting data, with data adapters, we need to "fill" it first, because that's how it gets the structure of the table
        try {

            DataSet workoutSet = new();
            SqlDataAdapter workoutAdapter = new SqlDataAdapter("Select * FROM WorkoutSessions where Id = -1", Secrets.getConnectionString());
            workoutAdapter.Fill(workoutSet, "workoutTable");
            DataTable? wTable = workoutSet.Tables["workoutTable"];

            if(wTable != null) {
                DataRow newRow = wTable.NewRow();

                newRow["WorkoutName"] = sessionToCreate.WorkoutName;
                newRow["WorkoutDate"] = sessionToCreate.WorkoutDate;

                wTable.Rows.Add(newRow);

                using SqlCommand cmd = new SqlCommand("INSERT INTO WorkoutSessions(WorkoutName, WorkoutDate) OUTPUT INSERTED.Id Values (@wName, @wDate)", new SqlConnection(Secrets.getConnectionString()));
                cmd.Parameters.Add("@wName", SqlDbType.VarChar, 50, "WorkoutName");
                cmd.Parameters.Add("@wDate", SqlDbType.DateTime, 4, "WorkoutDate");
                workoutAdapter.InsertCommand = cmd;

                workoutAdapter.Update(wTable);

                sessionToCreate.Id = (int) newRow["Id"];
            }

            SqlDataAdapter exerciseAdapter = new SqlDataAdapter("Select * From Exercises Where Id = -1", Secrets.getConnectionString());
            exerciseAdapter.Fill(workoutSet, "exerciseTable");

            DataTable? eTable = workoutSet.Tables["exerciseTable"];

            if(eTable != null) {
                foreach(Exercise e in sessionToCreate.WorkoutExercises)
                {
                    DataRow newRow = eTable.NewRow();

                    newRow["ExerciseName"] = e.Name;
                    newRow["ExerciseNote"] = e.Notes;
                    newRow["WorkoutId"] = sessionToCreate.Id;
                    eTable.Rows.Add(newRow);
                }
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(exerciseAdapter);
                SqlCommand cmd = cmdBuilder.GetInsertCommand();
                exerciseAdapter.InsertCommand = cmd;

                exerciseAdapter.Update(eTable);
            }
            return sessionToCreate;
        }
        catch(SqlException ex)
        {
            Log.Warning($"SQL Exception while creating new workout record: {ex}");
            throw;
        }
    }
}