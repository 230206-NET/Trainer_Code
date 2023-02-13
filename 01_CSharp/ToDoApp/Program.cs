

Console.WriteLine("ToDo App: helping you stay organized");

/*
To Do App:

It should be able to...
- Accept tasks from users
- It should also display them
- It should know when a task is complete or not

*/


//We are going to use an array to collect strings, or other related data types under one name
// Characterizing feature of array is that array is an contiguous collection of same type of data
// We can only have one type of data (ie string, int, double, etc.), and they all live right next to each other in memory
// Accessing element by its index is the strength of array
// Con: Array itself is immutable, once we declare and initialize the array with a set length, there is no such thing as dynamically increasing the size of it. 
// Instead, we make a new array with longer length, and copy everything over.
Console.WriteLine("How many tasks do you have to complete for today?");
int numTasks = int.Parse(Console.ReadLine()!);

Task[] taskArr = new Task[numTasks];
int taskCounter = 0;

while(true) {
    Console.WriteLine("Input Task:");
    string inputTask = Console.ReadLine()!;
    Task taskToCreate = new Task();
    taskToCreate.Description = inputTask;
    if(taskCounter == taskArr.Length) {
        // If we make it here, we know that the array is full,
        // and attempting to add another element will trigger IndexOutOfRangeException
        // So we create a new array of double the length, and replace the old array with
        taskArr = ResizeArray(taskArr);
        // finally, we'll make the newArr the taskArr
    }
    Console.WriteLine("Did you finish it? [y/n]");
    string done = Console.ReadLine()!;

    if(done == "y") {
        // we'll mark the item done
        taskToCreate.Status = "done";
    }
    else {
        // default to not done
        taskToCreate.Status = "in progress";
    }
    taskArr[taskCounter] = taskToCreate;

    taskCounter++;
    Console.WriteLine("Add another one?");
    string response = Console.ReadLine()!;
    if(response == "n") {
        // Immediately break out of the loop
        break;
    }
}

// Method(function) is a reusable block of code that take in 0 or more inputs and have 0 or 1 outputs
// f(x) = 2x; f(2) = 4; f(x, y) = 2x + y + 1; f(1, 2) = 2(1) + 2 + 1 = 5
// The first line of the method is called "method signature"
// return type, the method name, and arguments
/// <summary>
/// Takes in an array and doubles its size and returns the newly resized array
/// </summary>
/// <param name="stringArr">string array to be resized</param>
/// <returns>the resized array with double its capacity</returns>
Task[] ResizeArray(Task[] arrToResize) {
    Task[] newArr = new Task[arrToResize.Length * 2];
    for(int i = 0; i < arrToResize.Length; i++) {
        // And then, we'll traverse the taskArr (the old one), and copy over all the items in old array to the new array
        newArr[i] = arrToResize[i];
    }
    return newArr;
}

// Because arrays don't resizes themselves and we have better things to do
// we normally use different data structure to store sequential data 
// In C#, they are called List<T>
// Lists are more practical arrays. They dynamically resize themselves as they fill up
// and have other utility methods (More on MSDoc)

// List<string> taskList = new List<string>();

// while(true) {
//     Console.WriteLine("Input Task:");
//     string inputTask = Console.ReadLine()!;

//     taskList.Add(inputTask);
    
//     Console.WriteLine("Add another one?");

//     // question mark at the end of the data type means it's a nullable datatype aka it could be either the datatype or null
//     // Use this kind of tactic if you actually want to ensure something is not null before using it
//     // string? response = Console.ReadLine();
//     // if(response != null) {
//     //     int.Parse(response);
//     // }

//     // Null forgiving operator to suppress the nullable warning
//     string response = Console.ReadLine()!;

//     if(response == "n") {
//         // Immediately break out of the loop
//         break;
//     }
// }


for(int i = 0; i < taskArr.Length; i++) {
    Console.WriteLine("Description: {0}, Status: {1}", taskArr[i].Description, taskArr[i].Status);
}

// Record is a newer type that was introduced in C#9 (.NET 5)
// It is used for a simple data wrapping
public record Task
{
    public string Description { get; set; } = "";
    public string Status { get; set; } = "";
};