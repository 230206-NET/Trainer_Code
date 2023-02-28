using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DataAccess;
using Services;
using Models;

var builder = WebApplication.CreateBuilder(args);

// AddSingleton => The same instance is shared across the entire app over the lifetime of the application
// AddScoped => The instance is created every new request
// AddTransient => The instance is created every single time it is required as a dependency 
builder.Services.AddScoped<IRepository, DBRepository>(ctx => new DBRepository(builder.Configuration.GetConnectionString("workoutDB")));
builder.Services.AddScoped<WorkoutService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

// Query parameters don't get defined in the route it self, but you look for it in the argument/parameter of the lambda exp that is handling this request
app.MapGet("/greet", (string? name, string? region) => {
        if(string.IsNullOrWhiteSpace(name)) {
            return Results.BadRequest("Name must not be empty or white spaces");
        }
        else
        {
            return Results.Ok($"Hello {name ?? "humans"} from {region ?? "a mysterious location"}!");
        }
    }
);

// Route params
app.MapGet("/greet/{name}", (string name) => $"Hello {name} from route param!");


// ToDo: Fix why searching by workout doesn't work
app.MapGet("/workouts", ([FromQuery] string? search, [FromServices] WorkoutService service) => {
    if(search != null) {
        return service.SearchWorkoutsByExercise(search);
    }
    return service.GetAllWorkouts();
});

app.MapPost("/workouts", ([FromBody] WorkoutSession session, WorkoutService service) => {
    return Results.Created("/workouts", service.CreateNewSession(session));
});

app.Run();
