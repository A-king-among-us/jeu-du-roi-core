# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY WebApp/*.csproj ./WebApp/
COPY Library/*.csproj ./Library/
COPY TestLibrary/*.csproj ./TestLibrary/
RUN dotnet restore

# copy everything else and build app
COPY WebApp/. ./WebApp/
COPY Library/. ./Library/
COPY TestLibrary/. ./TestLibrary/
WORKDIR /source/WebApp
RUN dotnet build
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "2.WebApp.dll"]