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
- Const : John
- Readonly : Artur
- Abstract : Patrick
- Virtual : Engels
- Override : Sonya
- New : Samuel
- Partial : Raj
- Sealed : Jacob
- Static : Melanie
- Async : Edwin
- Unsafe : Nick 
- Extern : Meet
- Volatile : John S
- Event : Eric
- In / Out : Georges