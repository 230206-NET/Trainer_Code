# Base Image, an image we're starting our own image from
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS Build

WORKDIR /app

COPY HotOrCold.csproj ./HotOrCold.csproj
COPY Program.cs ./Program.cs

RUN dotnet publish -o dist

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS Run

WORKDIR /app
COPY --from=Build app/dist ./dist
CMD ["dist/HotOrCold"]