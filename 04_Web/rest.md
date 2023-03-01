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

- Uniform Interface
    - Your API should have some kind of standardized way of accessing your resource
    - HATEOAS (Hypermedia As The Engine Of Application State) (optional)
        - a curated menu
        - This is an optional feature of RESTful API where the server guides the user on what they can do based on the last request
        - In the server response, the server includes information about other endpoints the client can use based off of their current state
        - StarWars API has a good implementation of Hateoas

- Layered System
    - Each layer in your server should only know the layer beyond

- Code on Demand (Optional)
    - Your server can also serve code snippets instead of text

## Richardson Maturity Model
[RestAPI RMM](https://restfulapi.net/richardson-maturity-model/)
[Martin Fowler page](https://martinfowler.com/articles/richardsonMaturityModel.html)