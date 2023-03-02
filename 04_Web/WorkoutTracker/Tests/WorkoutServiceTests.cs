using Models;
using Services;
using DataAccess;
using Moq;

namespace Tests;

internal class FakeRepo : IRepository
{
    public WorkoutSession CreateNewSession(WorkoutSession sessionToCreate)
    {
        sessionToCreate.Id = 2;

        return  sessionToCreate;
    }

    public List<WorkoutSession> GetAllWorkouts()
    {
        return new List<WorkoutSession> {
            new WorkoutSession {
                WorkoutName = "Test Workout",
                WorkoutDate = DateTime.Now,
                Id = 1,
                WorkoutExercises = new List<Exercise> {
                    new Exercise {
                        Name = "One",
                        Notes = "some notes"
                    }
                }
            },
            new WorkoutSession {
                WorkoutName = "Test Workout 2",
                WorkoutDate = DateTime.Now,
                Id = 2,
                WorkoutExercises = new List<Exercise> {
                    new Exercise {
                        Name = "Exercise 2",
                        Notes = "some notes"
                    }
                }
            },
            new WorkoutSession {
                WorkoutName = "Test Workout 3",
                WorkoutDate = DateTime.Now,
                Id = 3,
                WorkoutExercises = new List<Exercise> {
                    new Exercise {
                        Name = "Exercise 3",
                        Notes = "some notes"
                    }
                }
            }
        };
    }

    public List<Exercise> GetExercisesByWorkoutId(int id)
    {
        return new List<Exercise> {
            new Exercise {
                Id = 1,
                Name = "sample exercise 1",
                Notes = "it was hard"
            },
            new Exercise {
                Id = 2,
                Name = "sample exercise 2",
                Notes = "it was hard"
            }
        };
    }
}

public class WorkoutServiceTests {
    [Fact]
    public void WorkoutServiceShouldCreate() {
        WorkoutService testService = new WorkoutService(new FakeRepo());

        Assert.NotNull(testService);
    }

    [Fact]
    public void GetAllWorkoutsShouldReturnWorkouts() {
        // AAA

        // Arrange
        WorkoutService testService = new WorkoutService(new FakeRepo());

        // Act
        List<WorkoutSession> workouts = testService.GetAllWorkouts();

        //Assert
        Assert.NotNull(workouts);
        Assert.Equal(3, workouts.Count);
        Assert.Equal("Test Workout", workouts[0].WorkoutName);
    }

    [Fact]
    public void SearchWorkoutsByExercise() {
        // Arrange
        WorkoutService testService = new WorkoutService(new FakeRepo());

        // Act
        List<WorkoutSession> workouts = testService.SearchWorkoutsByExercise("Exercise");

        //Assert
        Assert.Equal(2, workouts.Count);
        Assert.Equal("Test Workout 2", workouts[0].WorkoutName);
    }

    [Fact]
    public void CreateNewSessionShouldCreate() {
        // Arrange
        // Spin up a new mock class that implements IRepository Interface
        Mock<IRepository> mockedRepo = new Mock<IRepository>();
        WorkoutSession session = new WorkoutSession {
            WorkoutName = "Test Workout",
            WorkoutDate = DateTime.Now
        };

        // Asking the mock to return a canned response when CreateNewSession gets called with session object
        mockedRepo.Setup(repo => repo.CreateNewSession(session)).Returns(new WorkoutSession {
            Id = 1,
            WorkoutName = "Test Workout",
            WorkoutDate = DateTime.Now
        });

        // Instantiate service class with the mocked repository
        WorkoutService service = new WorkoutService(mockedRepo.Object);

        // Act
        WorkoutSession created = service.CreateNewSession(session);

        // Assert
        Assert.Equal(1, created.Id);
        // Verify using Moq that this repo method has been called exactly once
        mockedRepo.Verify(repo => repo.CreateNewSession(session), Times.Exactly(1));
    }

    [Fact]
    public void CreateNewSessionShouldNotCreateEmptyName() {
        // Arrange
        // Spin up a new mock class that implements IRepository Interface
        Mock<IRepository> mockedRepo = new Mock<IRepository>();
        WorkoutSession session = new WorkoutSession {
            WorkoutName = "",
            WorkoutDate = DateTime.Now
        };

        // Asking the mock to return a canned response when CreateNewSession gets called with session object
        mockedRepo.Setup(repo => repo.CreateNewSession(session)).Throws<Exception>();

        // Instantiate service class with the mocked repository
        WorkoutService service = new WorkoutService(mockedRepo.Object);

        // Act
        // Assert
        Assert.Throws<Exception>(() => service.CreateNewSession(session));
    }
}