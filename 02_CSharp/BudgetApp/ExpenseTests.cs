using Xunit;
using BudgetApp;

namespace Tests;

public class ExpenseTests {
    // Let's make sure true is true
    [Fact] //This lets xunit runner know that this is a test to be executed
    public void negateBooleanShouldNegate() {

        Assert.Equal(ExpenseTests.negateBoolean(true), false);
    }
    private static bool negateBoolean(bool input) {
        return !input;
    }

    [Fact]
    public void ExpenseClassShouldInitializeDefaultValues() {
        // AAA: Arrange, Act, Assert
        //Arrange: Setup everything you need for testing
        // Act: Do the action you're intending to verify/test
        Expense exp = new Expense();

        // Assert
        Assert.Equal(exp.Description, "sample description");
        Assert.Equal(exp.Amount, 0.0m);
    }

    [Fact]
    public void ConstructorWithDescription() {
        // Arrange, Act, Assert
        // Arranging sample data to test with
        string desc = "sample amount desc";

        // Act
        Expense exp = new Expense(desc);

        // Assert
        Assert.Equal(exp.Description, desc);
    }

    [Theory]
    [InlineData("     ")]
    [InlineData("")]
    [InlineData(null)]
    public void DescriptionShouldNotAcceptInvalidInputs(string input) {
        // Arrange
        Expense exp = new Expense();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => exp.Description = input);
    }

    [Theory]
    [InlineData("valid input")]
    public void DescriptionShouldSetValidInput(string input) {
        // Arrange
        Expense exp = new Expense();
        // Act
        exp.Description = input;
        // Assert
        Assert.Equal(exp.Description, input);
    }
}