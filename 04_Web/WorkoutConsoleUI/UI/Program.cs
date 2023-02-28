using UI;
using Serilog;

/*
Download appropriate packages for serilog
dotnet add package serilog
dotnet add package serilog.sinks.console (for logging to console)
dotnet add package serilog.sinks.file (for logging to file)
*/

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("../logs/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try {
    Log.Information("Application Starting...");

    // How to inject dependencies upon instantiation
    // new MainMenu(new WorkoutService(new FileStorage())).Start();

    // new DBRepository().GetExercisesByWorkoutId(1);

    MainMenu menu = new MainMenu();
    await menu.StartAsync();
}
catch(Exception ex) {
    Log.Error("Something fatal happened, {0}", ex);
}
finally {
    Log.CloseAndFlush();
}
