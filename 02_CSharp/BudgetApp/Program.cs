namespace BudgetApp;

public class MainMenu {
    public void Start() {
        Console.WriteLine("Budget App");

        decimal initialBudget;
        List<Expense> expenseList = new();
        decimal totalSpending = 0;
        while(true) {
            Console.WriteLine("Enter your initial Budget: ");

            bool parseSuccess = decimal.TryParse(Console.ReadLine(), out initialBudget);
            if(parseSuccess) break;
        }

        while(true) {
            Console.WriteLine("Enter Expenses: ");
            Console.WriteLine("Expense Description: ");
            string description = Console.ReadLine();
            decimal amount;

            while(true) {
                Console.WriteLine("Expense Amount: ");
                string amountStr = Console.ReadLine();
                bool amountParseSuccess = decimal.TryParse(amountStr, out amount);

                if(!amountParseSuccess) {
                    Console.WriteLine("The amount must be numeric value");
                }
                else {
                    break;
                }
            }
            //I'm invoking the constructor of this class
            // What is constructor? It's a special method used to create a copy(or an instance) of that class
            // Expense newExpenseToAdd = new Expense(description, amount);

            // Object Initializer, just another syntactic shortcut
            Expense newExpenseToAdd = new Expense {
                Description = description,
                Amount = amount
            };
            // Expense newExpenseToAdd = new Expense();
            // newExpenseToAdd.Description = description;
            // newExpenseToAdd.Amount = amount;
            expenseList.Add(newExpenseToAdd);
            totalSpending += newExpenseToAdd.Amount;

            for(int i = 0; i < expenseList.Count; i++) {
                Console.WriteLine(expenseList[i]);
                // Console.WriteLine(expenseList[i].DescriptionDisplay());
                // Console.WriteLine(expenseList[i].Amount);
                // Console.WriteLine(expenseList[i].Description);
            }
            Console.WriteLine("Your Budget Remainder: {0}", initialBudget - totalSpending);

            // foreach(Expense exp in expenseList) {
                // Console.WriteLine(exp);
            //     Console.WriteLine(exp.Description);
            // }
            Console.WriteLine("Add another?");
            string userInput = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(userInput)) {
                continue;
            }
            else {
                // The following line takes the user input, converts it into lower case, and plucks the first letter
                // This is possible because string are represented as collection of characters and we can access individual character in a string via its index
                // This means, I don't have to worry about all the variations of no, such as n, no, NO, No, etc, as long as the response start with n
                char response = userInput.ToLower()[0];
                if(response == 'n') {
                    break;
                }
            }
        }

        /* Reference vs Value Types: the Stack and the Heap
        - Both value and reference types are two main categories of data we have in C#. The main difference is that with value types such as int, double, float, and char, the value of the variable is stored *directly* in stack along with the variable name and what type of data it is. On the other hand, with reference types, such as classes, the data is stored in heap, and the address to the memory location in heap is instead stored in the stack, alongside the data type and variable name. Reference types tend to be more complex and heavier compared to value types. 
        */
    }
}