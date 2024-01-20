FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DataBaseMinimalApi/DataBaseMinimalApi.csproj", "DataBaseMinimalApi/"]
RUN dotnet restore "DataBaseMinimalApi/DataBaseMinimalApi.csproj"
COPY . .
WORKDIR "/src/DataBaseMinimalApi"

FROM build AS publish
RUN dotnet publish "DataBaseMinimalApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataBaseMinimalApi.dll"]

