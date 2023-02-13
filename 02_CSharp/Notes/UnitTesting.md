# Unit Testing

We've already been doing manual testing all along.
## Types of testing
- Manual testing: human tests expected behavior of the whole app
    - Pros: flexible, no additional set up required for testing, we can stress test it for edge cases
    - Cons: Takes long time to test, rate of return is low, it requires more human input (slow, expensive, prone to error)

- Automated Testing:
    - Unit Testing: Automated testing of the smallest independent units of your code
        - We test with unit testing: small modules of YOUR code
        - What we don't test: other people's code, UI logic (anything that interacts with user)
    - Integration Testing
    - Stress Testing
    - Performance Testing

## How to get started
- ensure you have the following packages: Microsoft.NET.Test.SDK, xunit, xunit.runner.visualstudio
- Install those if you have them already with `dotnet add package package-name` command
- Or you could create a new xunit testing project with `dotnet new xunit` command

- Two types of tests are available in xunit: Fact, Theory. Use Theory attribute if you are looking to run the test over multiple inputs

- We follow Arrange, Act, Assert pattern in C#.
    - Arrange: get all our necessary set up done
    - Act: conduct the behavior you're looking to verify
    - Assert: Verify that the expectation and outcome align