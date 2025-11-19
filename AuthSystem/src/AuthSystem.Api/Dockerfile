# -------------------- Build stage --------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY ["AuthSystem.Api.csproj", "./"]
RUN dotnet restore "AuthSystem.Api.csproj"

# Copy all source code
COPY . .

# Publish
RUN dotnet publish "AuthSystem.Api.csproj" -c Release -o /app/publish

# -------------------- Runtime stage --------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published app
COPY --from=build /app/publish .

# Expose port
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "AuthSystem.Api.dll"]
