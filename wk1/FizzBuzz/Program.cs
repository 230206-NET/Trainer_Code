/*
- Given a positive integer, print the following:
- Start from 1 to the integer given,
- If the number is divisible by 3, print "Fizz"
- If the number is divisible by 5, print "Buzz"
- If the number is divisible by both 3 and 5, print "FizzBuzz"
- Finally, if the number is not divisible by 3 or 5, print the number itself

User Input is 15
1
2
Fizz
4
Buzz
Fizz
7
8
Fizz
Buzz
11
Fizz
13
14
FizzBuzz
*/

NumEnter:
Console.WriteLine("Enter a positive integer: ");
//Reading user input via Console.ReadLine method, which returns string
string userInput = Console.ReadLine()!;

// Exception Handling:
// Exception stand for "Exceptional Events" and they represent an extra-ordinary that is outside of normal operation of a particular methods
// It's basically telling you "something is wrong" 
// As long you handle these exceptions, they are usually not fatal (as in, will crash your program)
// Which is different from Errors (errors are usually fatal)
// We handle exceptions via Try/Catch/Finally Block
// Methods will use different exceptions to communicate what exactly is wrong
// Wrap the code that may throw exception in the try block
int parsedInput = 0;
try {
    parsedInput = int.Parse(userInput);
}
// These Catch blocks do flow down, so put them in the order you want your program to check (IE don't catch the Exception class first, since it is the parent class of all exceptions)
catch(FormatException) {
    Console.WriteLine("The input must be an integer");
    goto NumEnter;
}
catch(ArgumentNullException) {
    Console.WriteLine("You didn't input anything... :(");
}
catch(OverflowException) {
    Console.WriteLine("Why are you abusing me...");
}
finally {
    // Console.WriteLine("clean up some stuff");
    // this block runs regardless of exceptions being thrown
    //good for any code cleanups, ie, if you're connecting to external resources like DB, should close the connection here
}
// Console.WriteLine("Something");
// Garbage Collection: "automatic memory management"
// It is one of the features of the Common Language Runtime (CLR)
// The runtime automatically releases memories of variables that are out of scope

if(parsedInput <= 0) {
    Console.WriteLine("Your input must be greater than 0");
    goto NumEnter;
}

// By the time we get here, we know that the number must be a positive integer
//We are going to use a for loop to iterate until we reach the given integer
for(int i = 1; i <= parsedInput; i++) {
    // if i is divisible by 3, print Fizz
    // Using Modulus Operator to tell if i is a multiple of 3
    // a number is a multiple of 3 if the number divided by 3 has remainder of 0
    // If/ElseIf/Else block also flows top to bottom
    if(i % 3 == 0 && i % 5 == 0) {
        Console.WriteLine("FizzBuzz");
    }
    else if(i % 5 == 0) {
        Console.WriteLine("Buzz");
    }
    else if(i % 3 == 0) {
        Console.WriteLine("Fizz");
    }
    else {
        Console.WriteLine(i);
    }
}