// By convention, we use PascalCaseForClasses   
// This is our blue print for all our expenses
// the "public" is what we call "access modifier"
// The access modifiers describes "how accessible it is" or "who can use this?"
// there are 4 simple access modifiers and 2 combination ones 
// 4 simple ones are: Public, private, internal, and protected
// Public: Anyone and every one have access to public resources
// Private: it is available to the owner of that particular property/method/etc. Often used in class members (things that belong in a class) when you want to keep things to yourself
// Internal: Everyone in my PROJECT has access to this
// Protected: Me and my Children (the inherited classes) have access to this
internal class Expense {
    // Constructor: The default one goes away as soon as we provide our own. Add the your custom empty constructor back if you want it.
    
    // What we are doing here, having multiple different versions of the same method, is called method overloading
    // Overloading happens within the same class
    // You have to keep the method name same
    // but your parameter must be different
    // Return type can also be different
    public Expense() {
        // This is where you can do a lot of initial set up behavior for each object
        this.Description = "sample description";
        this.Amount = 0.0m;
    }

// Constructor chaining
    public Expense(string descriptionToSet) : this() {
        this.Description = descriptionToSet;
    }

    public Expense(decimal amountToSet) : this() {
        this.Amount = amountToSet;
    }

// A way to provide default values;
    public Expense(string descriptionToSet = "", decimal amountToSet = 0.0m) {
        this.Description = descriptionToSet;
        this.Amount = amountToSet;
    }

    // What did you spend your money for
    // These are fields
    // Field are the state/characteristic of the object we're trying to describe 
    // Having a public field is considered a bad practice
    // public string description;
    private string description = "";
    // // Instead, we have getters and setters so we can control how we dispense and manipulate the data
    // public string GetDescription() {
    //     return this.description;
    // }
    // /// <summary>
    // /// sets the description field
    // /// throws FormatException if the string is null or empty
    // /// </summary>
    // /// <param name="inputVal">input string to set it</param>
    // public void SetDescription(string inputVal) {
    //     // input validations here
    //     if(string.IsNullOrWhiteSpace(inputVal)) {
    //         throw new ArgumentNullException("input value must not be empty");
    //     }
    //     this.description = inputVal;
    // }

    // Automatic Properties, or just "properties"
    // Which is a bundle of a field, getter/setter
    // this is just a syntactic shortcut
    // but this what we all use in C#
    internal string Description { 
        get {
            return this.description;
        } 
        set {
            // when the user of this class sets Description to a certain string, that string  value is passed as the name "value"
            if(string.IsNullOrWhiteSpace(value)) {
            throw new ArgumentNullException("input value must not be empty");
            }
            this.description = value;
        } 
    }


    // if you don't need any validation, but just need getters and setters because it's a good practice, this is something you'll see often
    internal string Prop { get; set; }

    // How much did you spend?
    // we have multiple options here: double float int decimal
    public decimal Amount { get; set; } = 0.0m;

    // Write Getter/Setter using Property syntax for the amount field here 
    // This is a method
    // Method describes a behavior that is associated with the class
    private void exampleMethod() {

    }

    // Method signature is the first line in method definition
    // usually has things like access modifier, the return type, method name, and parameters
    private void IncrementInterest(int interestRate) {
        // The this keyword refers to a particular instance and not the class itself 
        this.Amount *= (1 + interestRate);
    }

    public string DescriptionDisplay() {
        return $"Description: {this.Description} \nAmount:{this.Amount}";
    }

// When we want to customize the behavior of the method we inherit from our parent classes, we can override them.
// You can only override following methods:
// The ones you inherit from your parent AND
// are marked with "virtual" non-access modifier
// With overriding, you cannot modify the method signature
// But you override the method body to provide your own implementation
    public override string ToString()
    {
        return $"Description: {this.Description} \nAmount:{this.Amount}";
    }
}

