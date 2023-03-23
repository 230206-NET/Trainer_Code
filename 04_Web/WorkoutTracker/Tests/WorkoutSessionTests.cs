using Models;
using Models.CustomException;

namespace Tests;

public class WorkoutSessionTests
{
    // [Fact]
    // public void WorkoutShouldCreate()
    // {
    //     WorkoutSession s = new();

    //     Assert.NotNull(s);
    //     Assert.NotNull(s.WorkoutDate);
    //     Assert.False(string.IsNullOrEmpty(s.WorkoutName));
    // }

    [Fact]
    public void WorkoutNameShouldSetValidName() {
        WorkoutSession s = new();

        s.WorkoutName = "TestName";

        Assert.Equal("TestName", s.WorkoutName);
    } 

    // [Fact]
    // public void WorkoutNameLengthValidation() {
    //     WorkoutSession s = new();

    //     string invalidName = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";

    //     Assert.Throws<ArgumentLengthException>(() => s.WorkoutName = invalidName);
    // }
}