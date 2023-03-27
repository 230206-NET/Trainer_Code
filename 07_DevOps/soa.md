# Service Oriented Architecture
- Web Services are services, or software offered by an electronic device to another electronic device, communicating with each other via web (REST, SOAP, etc.)
Instead of having a monolithic architecture where the relationship between ui logic and backend logic is tightly bound, we create web services that can serve many different types of devices/users/apps/programs.
Essentially more modular way to design your app, so it can be flexible in who it serves.
- BE/FE,etc. 

## SOA Principles
These are some of the guiding principles to help design your web services
- Service Contract (similar to Uniform Interface in REST)
    - Your service, should operate based on a standardized contract
- Service Composability (similar to Single Responsibility of SOLID)
    - should be small, and be composed of other services that does one thing well
- Loosely Coupled (same thing that we always do)
    - your services should not be codependent/tightly coupled/in other services business
- Abstraction (same as abstraction of OOP)
    - Your service should not display everything. instead, it should provide a simple interface for users to use

- (SOA Principles)[https://www.guru99.com/soa-principles.html]