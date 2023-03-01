# REST
A Design guideline to designing API's

[RESTful API](https://restfulapi.net/)
[MsDoc REST Best Practice](https://learn.microsoft.com/en-us/azure/architecture/best-practices/api-design)

- REpresentational State Transfer

## Guiding Principles
- Client-Server
    - they should be isolated from each other and develop independently

- Stateless
    - the server should not be storing client's state

- Cacheable
    - Certain high demand server resources can be cached for quicker access
    - clients also cache commonly used resources in its side
    - Resources should be noted whether they are cacheable or not

- Uniform Interface
    - Your API should have some kind of standardized way of accessing your resource
        - Identification of resources – The interface must uniquely identify each resource involved in the interaction between the client and the server.
        - Manipulation of resources through representations – The resources should have uniform representations in the server response. API consumers should use these representations to modify the resources state in the server.
        - Self-descriptive messages – Each resource representation should carry enough information to describe how to process the message. It should also provide information of the additional actions that the client can perform on the resource.
        - Hypermedia as the engine of application state – The client should have only the initial URI of the application. The client application should dynamically drive all other resources and interactions with the use of hyperlinks.

- Layered System
    - Each layer in your server should only know the layer beyond

- Code on Demand (Optional)
    - Your server can also serve code snippets instead of text

## Richardson Maturity Model
[RestAPI RMM](https://restfulapi.net/richardson-maturity-model/)
[Martin Fowler page](https://martinfowler.com/articles/richardsonMaturityModel.html)