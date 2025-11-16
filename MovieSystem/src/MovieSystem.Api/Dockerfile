# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/MovieSystem.Api/*.csproj", "MovieSystem.Api/"]
RUN dotnet restore "MovieSystem.Api/MovieSystem.Api.csproj"

COPY src/MovieSystem.Api/ MovieSystem.Api/
WORKDIR /src/MovieSystem.Api
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Run HTTP on port 80 inside container
ENV ASPNETCORE_URLS=http://+:80

COPY --from=build /app/publish .
EXPOSE 80

ENTRYPOINT ["dotnet", "MovieSystem.Api.dll"]
