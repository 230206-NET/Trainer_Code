# Non-Access Modifiers
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