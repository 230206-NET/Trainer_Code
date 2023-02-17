# SOLID Design Principles
5 design principles to make your code more scalable, maintainable, and extensible.

## Single Responsibility
- Your class should do one thing, and one thing well
- being in charge of one specific thing -> separation of concerns

## Open/Close Principle
- Open to Extension but closed for modification
- Types should be open to extension via Interface implementation, class inheritance, extension method, but should prevent unintentional modification of already written code/existing feature

## Liskov Substitution Principle
LSP states that subtypes should be able to substitute for super types

## Interface Segregation
Don't make humongous interfaces - in other words,
Your classes/types that implement interfaces should NOT have to implement the methods they don't need

## Dependency Inversion
Instead of abstract depending on the specific definition, we'll have concrete types that depend on abstract types
- The layers of application should depend on the abstract definition and not the concrete one

## Design Pattern vs Design Principles
Design patterns are a solution to known, common problems. They provide _templates_ for you follow to address frequently occurring issues/concerns

Design Principles are more of "best practice" guidelines on designing your software