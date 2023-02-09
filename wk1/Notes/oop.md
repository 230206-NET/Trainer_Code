# OOP: Object Oriented Programming

Object Oriented Programming is a way of organizing the code and treating everything as an object. 
Object: it's something with a state/data/property that describes it, and the behavior that is associated to it. 
Object is also a fundamental building block of objected oriented programming.

Instead of starting from the scratch every single time we want to create an object, we create a blueprint for a certain type of object. Ex. "Person" blueprint might have things like, walk behavior, ID number, first name, last name, etc. "Animal" Blueprint might have traits like species, size, weight, etc. This way, if you want to create an object to represent your pet, you don't have to go my pet's name is "titan" his specie is Golden Retriver,  

Object is an instance of a class
Class, simply speaking is a form representing a certain type of object. Classes have things like, this type of object will have "first name"
We also use classes to "encapsulate" the data, aka, hold the related data in one place
So instead of toting three different variables, we create a convenient tote/box to hold it all in one place
```csharp
// Instead of this...
string firstNameForJuniper = "Juniper"
string lastNameForJuniper = "Song"
int numberOfPetsForJuniper = 1

//we can do this
class human {
    string firstName { get; set; }
    string lastName {get; set; }
    int numberOfPets { get; set;}
}

human juniper = new human();
juniper.firstName = "Juniper"
juniper.lastName = "Song"
juniper.numberOfPets = 1

human john = new human();
john.firstName = "John";
```

## 4 Pillars
Abstraction
Encapsulation
Inheritance
Polymorphism