# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/AuthSystem.Api/*.csproj", "AuthSystem.Api/"]
RUN dotnet restore "AuthSystem.Api/AuthSystem.Api.csproj"

COPY src/AuthSystem.Api/ AuthSystem.Api/
WORKDIR /src/AuthSystem.Api
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "AuthSystem.Api.dll"]
