# -------------------- Build stage --------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["BookingSystem.Api.csproj", "./"]
RUN dotnet restore "BookingSystem.Api.csproj"

COPY . .
RUN dotnet publish "BookingSystem.Api.csproj" -c Release -o /app/publish

# -------------------- Runtime stage --------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "BookingSystem.Api.dll"]
