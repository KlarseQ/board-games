FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build
WORKDIR /source
EXPOSE 8080
EXPOSE 8081

COPY /DataBaseMinimalApi/*.csproj ./DataBaseMinimalApi/
COPY /Models/*.csproj ./Models/
RUN dotnet restore "DataBaseMinimalApi/DataBaseMinimalApi.csproj"

COPY ["DataBaseMinimalApi/*", "DataBaseMinimalApi/"]
COPY ["Models/*", "Models/"]
WORKDIR "/source/DataBaseMinimalApi"
RUN dotnet publish -o /app

FROM mcr.microsoft.com/dotnet/nightly/aspnet:8.0-jammy-chiseled-composite
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["./DataBaseMinimalApi"]
