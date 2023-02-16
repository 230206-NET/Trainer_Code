# Object Oriented Programming Pillars

## 4 Pillars
### Abstraction
- is hiding the complex implementation details away from the user and providing them with a simplified interface to use
- "black box"
- How is abstraction implemented in C#?
    - They are not meant to provide implementation details but to define characteristics and behaviors of classes that implement/inherit from them

    - Abstract (or Virtual) Classes
        - not meant to be directly instantiated and used, but to be inherited and implemented
        - Difference between abstract and virtual method is that virtual has implementation body that can be overridden by children classes, but abstract methods cannot have method body
        - We can only inherit one class
        ```csharp
        abstract class Animal {
            //do not have method bodies with abstract methods
            // not meant to be implemented
            abstract void Move();
        }

        class Mammal : Animal {
            public void Move() {
                Console.WriteLine("I'm moving");
            }
        }
        ```
    - Interface
        - Methods on interfaces also don't have implementation body- they are implicitly abstract- which means they need to be implemented by the concrete class that implements the interface
        - Interfaces usually don't have properties/traits that describe classes
        - Interface is a collection of *public* behaviors that a class needs to have 
        - By convention, we name interfaces starting with capital "I" + the actionName
        - Classes can implement *multiple* interfaces, and this is how we can simulate "Multiple inheritance"
    - 
    ```csharp
        interface IWalkable 
        {
            //Implicitly, methods in interface are abstract and public 
            void Walk();
        }

        interface ITalkable
        {
            void Talk();

            void Yell();
        }

        class Cat : IWalkable, ITalkable
        {
            private void WalkHelper() {}
            public void Walk() {
                WalkHelper();
                Console.WriteLine("Cat slinks");
            }

            public void Talk() {
                Console.WriteLine("meow");
            }

            public void Yell() {
                Console.WriteLine("MERRROW");
            }
        }
    ```
### Polymorphism
    - "Poly" means many, "morph" means form, polymorphism stands for "many forms"
    - Describes ability for code to act differently upon various circumstances 
    - Method Overloading
        - when we have "multiple versions" of the same method within ONE class
        - The parameter must be different
    - Another form of polymorphism covariance and contravariance
    ```csharp
        class Animal {}
        class Cat : Animal {}

        Animal a = new Cat();
        Cat c = new Animal();
    ```
    - Method Overriding is also a form of polymorphism
    - Operator Overloading
    - Generic Class can also be considered a form of polymorphism

### Inheritance
    - Inheritance can be referred to as IS-A relationship
        - Cat IS-A(n) Animal
        - Car IS-A vehicle
    - is a way of relating two classes by inheritance chain and reusing super type's data in subtypes
    - Is when a child class inherits methods from its parent class

    - Benefits:
        - Code Reuse / single source of truth
    - Method Overriding
        - a child class (or subtype) "overrides" the inherited (parent's) implementation with its own implementation
        - the parent method must have keyword "virtual"(or abstract which is implicitly virtual) and the overriding method must have keyword "override"

### Encapsulation

    - "Data Hiding": Restricting full access to data
        - Getters and Setters
        - [Access modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers) (Public, Private, Protected, Internal, Private Protected, Protected Internal)
            - Public : Everyone has access to this
            - Private: Only inside the declared class (Default for type member)
            - Internal: Within the same project (Default for Types)
            - Protected: Within the inheritance chain 
            - Private Protected : Must be in same project(assembly) + in inheritance chain (Protected Intersect Internal)
            - Protected Internal: Either within the same assembly OR within the inheritance chain (Protected Union Internal)
    - "Data Wrapping": Bundling of related data
        - Define a class to hold relevant data
        - Namespace
    - Popular QC Question: "What's the difference between encapsulation and abstraction?"
        - Abstraction is properties of object and Encapsulation is functionalities
        - Abstraction is hiding of implementation, encapsulation is hiding of data
        - Encapsulation is more about security Abstraction is hiding specific implementation and just revealing simple functionalities 
        - "abstraction is the black box. encapsulation is the workings of the black box"
        - "Abstraction and encapsulation are complementary concepts: abstraction focuses on the observable behavior of an object...encapsulation focuses on the implementation that gives rise to this behavior“
            - Object-Oriented Analysis and Design, Grady Booch


## Non-Access Modifier
- *Const* : John R
    - "constant" value
    - applied to fields and properties
    - once you assign them, you cannot change them
    - Compile time constant

- *Readonly* : Artur
    - similar to const, but can be assigned during declaration and in constructor, but once out of that context, cannot be modified further
    - Can be used as runtime constant

- *Abstract* : Patrick
    - Abstract indicates that object is missing implementation, and is incomplete. 
    - Abstract types cannot be instantiated and abstract methods cannot be invoked
    - Abstract types and type members must be derived and be implemented by concrete types and type members
    - Abstract type members are implicitly virtual
    - Abstract method is only permitted in abstract classes

- *Virtual* : Engels
    - Used on method, property, index, event, etc.
    - Allows child to override the default implementation
    - cannot be used with static, abstract, or override modifiers
    - ex: override ToString()

- *Override* : Sonya
    - When child class has the same method signature with the parent class, and providing their own implementation to the parent's behavior

- New : Samuel
    - keyword to create instance object
    - used to provide new implementation/value and Hide the inherited implementation/value from the parent class

- Partial : Raj
    - Use partial keyword to spread a type over multiple files
    - isn't allowed on constructors, finalizers, overloaded operator, property and event

- *Sealed* : Jacob
    - To a class, you cannot inherit from the class any further
    - Applied to method/properties, cannot be overridden 
        - cant seal a base implementation
- *Static* : Melanie
    - They belong with the type itself instead of the instances
    - Static classes cannot have instance members
    - Useful for utility type functionality
    - Static classes are Sealed, cannot be inherited

- *Async* : Edwin
    - is paired with await, to signal that the method utilizes asynchronous functions
    - when your method uses any asynchronous methods, you have to mark your method as async keyword, otherwise the program will not check back

- Unsafe : Nick
    - Not a common modifier. Used to indicate unsafe context
    - Required for any operations involving pointer
    - Can't use this unless you tell the compiler about allowing unsafe blocks.

- Extern : Meet
    - signifies that it's an external method
    - to use code written in language other than C#
    - has to be used with DllImport attribute

- Volatile : John S
    - Used to indicate use with multiple threads
    - promise to compiler and runtime to skip a certain optimizations
    - Fields, classes, structs
    - can't apply it to long, double, strings

- Event : Eric
    - used to signify that a delegate is an event
    - used to declare a custom event
    - Events are a way for classes to notify other classes and objects that an event has occurred.

- In / Out : Georges
    - Both used Pass by reference
    - With In, you have to initialize them before passing in, and you cannot modify the value within the method body
    - With out, you don't have to initialize them, but the method body must assign a value before returning