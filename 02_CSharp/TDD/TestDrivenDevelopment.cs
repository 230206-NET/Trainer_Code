namespace TDD;

/*
The gist of TDD is that you write test first to fit the spec/requirements
before you go implement anything
- This leads to higher code coverage
- Better testable code (scales/maintains better)
- Concise code (no extra fluff)

Cons:
- Overhead
*/
public class TestDrivenDevelopment
{
    // User Story: I should be able to calculate n-factorial (n!)
    public int Factorial(int n) {
        if(n == 1) return 1;
        return n * Factorial(n - 1);
    }

    [Fact]
    public void FactorialTests()
    {
        // 3! = 3 * 2 * 1 = 6
        int result = Factorial(3);

        Assert.Equal(6, result);
    }
}