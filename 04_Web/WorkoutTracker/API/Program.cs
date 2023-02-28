using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Services;
using Models;

var builder = WebApplication.CreateBuilder(args);

// AddSingleton => The same instance is shared across the entire app over the lifetime of the application
// AddScoped => The instance is created every new request
// AddTransient => The instance is created every single time it is required as a dependency 
builder.Services.AddScoped<IRepository, DBRepository>();
builder.Services.AddScoped<WorkoutService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

// Query parameters don't get defined in the route it self, but you look for it in the argument/parameter of the lambda exp that is handling this request
app.MapGet("/greet", ([FromQuery]string? name, [FromQuery] string? region) => $"Hello {name ?? "humans"} from {region ?? "a mysterious location"}!");

// Route params
app.MapGet("/greet/{name}", (string name) => $"Hello {name} from route param!");


// ToDo: Fix why searching by workout doesn't work
app.MapGet("/workouts", ([FromQuery] string? search, WorkoutService service) => {
    if(search != null) {
        return service.SearchWorkoutsByExercise(search);
    }
    return service.GetAllWorkouts();
});

app.MapPost("/workouts", ([FromBody] WorkoutSession session, WorkoutService service) => {
    service.CreateNewSession(session);
});

app.Run();
