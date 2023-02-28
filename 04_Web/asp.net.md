# ASP.NET Core

- ASP.NET is a web application framework for .NET platform
- ADO.NET vs ASP.NET
- ASP.NET vs ASP.NET Core - be careful about which stackoverflow article you're reading

- ASP.NET Core provides framework to build lots of different types of web application, such as server side rendering via ASP.NET MVC (which includes things like Razor pages or Blazor) or built in template to build single page applications with angular or react. It also has built in template to build just the API without frontend attached to it.

- To Configure Swagger on your API
1. `dotnet add package Swashbuckle.ASPNetCore`
2. add the following two lines before builder.Build()
```csharp
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
```
3. Add these lines after builder.Build() but before app.Run()
```csharp
    app.UseSwagger();
    app.UseSwaggerUI();
```