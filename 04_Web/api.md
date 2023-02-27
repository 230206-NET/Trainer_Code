# HTTP & API
### Learning Objectives
- Understand different components of http request response lifecycle
- Understand what API is and the benefits of them

## HTTP (HyperText Transfer Protocol)
A protocol to communicate data over the web
### HTTP Request Response Lifecycle
1. Client Initiates HTTP Request
2. Server Receives the HTTP request
3. Server Responds with an HTTP Response, along with the resource the client asked for

#### Client
- machine that is initiating the http request
#### Server
- Machine that is processing/responding to the request

* Do note that these are not fixed roles, they change depending on the context. A server can be a client if it is sending an http request to another server.
#### Web Resource
Web Resource is any resource on the web. This can mean image, audio files, text files, json data, html page... etc. Anything and everything that we send over the web that is tied to a URL is considered resource
#### URL
    - Uniform Resource Locator: aka, a way to locate a resource on the web using uniform syntax
    - [MDN Doc on URL](https://developer.mozilla.org/en-US/docs/Learn/Common_questions/Web_mechanics/What_is_a_URL)
    - Scheme (which protocol are you using?)
    - Domain name (where is this server on the web?)
        - translated to ip by DNS
    - Port
        - which gate should we use to access this server?
        - 80 is default for http
        - 443 for https
        - 1433 is default for SQL Server
    - Path to File or resource
    - Parameters such as:  
        - Route parameter 
            - parameter that is provided as a part of the url
            - mandatory if the api expects one
            - ex. https://example.com/users/2/
        - Query parameter
            - Key value pairs that is tacked on at the end of the url, after the question mark
            - very often optional
            - ex. https://example.com/users?id=2&auth=false
#### HTTP Request
- URL (the destination)
- Request Method Verb (GET/POST/PUT/DELETE/OPTION/HEAD/etc.)
    - GET is commonly used with retrieving resources
    - PUT/POST is commonly used to write/update existing resources
    - DELETE is used to accept requests for a resource to be deleted 
- Request Header: key/value pairs describing the request itself
    - requesting content type
    - encoding
    - etc.

- Optionally, it can also have request body (common with POST/PUT requests)
#### HTTP Response
- Response Code
    - Predetermined codes to communicate a particular message
    - 5 Broad Categories
        - 100: Informational
        - 200: Success
        - 300: Redirect
        - 400: Client-side Error
        - 500: Server-side Error
- Response body
    - the content the client asked for
- Response Header
    - key/value pairs that describes the response itself

#### HTTP vs HTTPS
HTTPS = HTTP + SSL Certificate. Simply put, the SSL certificate verifies the site's identity and enables the data encryption on transit. Https is more secure version of http, and is recommended over http.

## Web 1.0
- Collection of static documents(html pages) hosted on the web
- Server serves these pages directly to the client upon request
- Monolithic construction: aka the server has been built to serve just the (human) users in one format. The logic/data is tightly bound to our UI

## Web 2.0
- Dynamic web pages, which leads to rich UX (user experience)
- Active user participation
- wide adoption of API (Application Programming Interface)

## What is API (Application Programming Interface)?

If an UI is an interface that is built for users to interact with the program, API is an interface that is meant for machines to interact and use the program. As the name suggests, it is in fact, another interface targeting a different audience (machines, instead of humans).
This means when we use someone else's api (such as github api, twitter api, etc) we're building upon other people's program/functionalities/data in our program.

This leads to incredible data/function sharing capabilities. We no longer need to re-invent the wheel every time or be sad that we don't have a certain data- We can integrate and build on top of other people's data/program to create our own application!

Separating our own backend to be an API also provides us with many benefits.
1. UI develops independently from API
    - You can have many different versions of UI (web app? mobile app? watch app?)
2. Share your functionality/data with the others on the web
    - More monetization opportunities


## Tools for sending http requests
- [`cURL`](https://curl.se/) command on bash to transfer data in all sorts of protocols, including http and https

- Postman: a popular tool to send http requests to many different apis

- Swagger UI: an interactive documentation of an api that lets you send sample requests and play around with the api

- HTTPClient class (belongs in System.Net.Http namespace) to send http requests in .NET
