# TicketUZ - Cinema Ticket Booking System

A distributed microservices-based cinema ticket booking platform built with .NET 8.0, demonstrating modern cloud-native architecture patterns including event-driven communication, JWT authentication, and database-per-service design.

## 🎯 Overview

TicketUZ is a production-ready cinema booking system that showcases microservices architecture best practices. The system allows users to browse movies, select showtimes, book seats, process payments, and receive notifications - all through a secure API Gateway with JWT authentication and role-based access control.

## 🏗️ Architecture

### Microservices
1. **API Gateway** (Port 7000) - Entry point for client requests with JWT validation and intelligent routing
2. **Auth System** (Port 5001) - User management, JWT tokens, Google OAuth 2.0 integration
3. **Movie System** (Port 5002) - Movies, showtimes, cinema halls, seat management
4. **Booking System** (Port 5003) - Reservation handling, seat booking orchestration
5. **Payment System** (Port 5004) - Payment processing and transaction management
6. **Notification System** (Port 5005) - Email/SMS notifications via event-driven messaging

### Technology Stack
- **Framework**: .NET 8.0 (ASP.NET Core Web API)
- **Database**: SQL Server 2022 with Entity Framework Core 9.0
- **Message Broker**: RabbitMQ 3 (event-driven communication)
- **Authentication**: JWT Bearer tokens with BCrypt password hashing
- **OAuth**: Google OAuth 2.0 integration
- **Containerization**: Docker & Docker Compose
- **API Documentation**: Swagger/OpenAPI

### Key Design Patterns
✅ **Microservices Architecture** - Independent, loosely-coupled services  
✅ **Database per Service** - Each service owns its data  
✅ **API Gateway Pattern** - Single entry point for all clients  
✅ **Event-Driven Architecture** - Async communication via RabbitMQ  
✅ **Repository Pattern** - Data access abstraction  
✅ **Dependency Injection** - Built-in .NET DI container

## � How It Works

### User Booking Flow
1. **Authentication**: User registers/logs in (supports Google OAuth)
2. **Browse Movies**: View available movies and showtimes
3. **Select Seats**: Choose cinema hall and seats
4. **Create Booking**: BookingSystem validates with Auth & Movie systems
5. **Process Payment**: Payment event published to RabbitMQ
6. **Send Notification**: User receives booking confirmation via email/SMS

### Admin Operations
- Manage movies (CRUD operations)
- Configure cinema halls and seating
- Set showtimes and pricing
- View all bookings and payments

### Inter-Service Communication
- **Synchronous**: HTTP/REST for direct queries (e.g., user validation)
- **Asynchronous**: RabbitMQ events for bookings, payments, notifications
- **Authentication**: JWT tokens validated at API Gateway

## 🚀 Getting Started

### Prerequisites
- Docker Desktop installed
- .NET 8.0 SDK (for local development)
- SQL Server Management Studio (optional)

### Quick Start with Docker
```bash
# Clone the repository
git clone https://github.com/your-org/TicketUZ.git
cd TicketUZ

# Start all services
docker-compose up -d

# Check service health
docker-compose ps
```

### Service URLs
- **API Gateway**: http://localhost:7000/swagger
- **Auth System**: http://localhost:5001/swagger
- **Movie System**: http://localhost:5002/swagger
- **Booking System**: http://localhost:5003/swagger
- **Payment System**: http://localhost:5004/swagger
- **Notification System**: http://localhost:5005/swagger
- **RabbitMQ Management**: http://localhost:15672 (guest/guest)

### Local Development Setup
```bash
# Navigate to a service
cd AuthSystem/src/AuthSystem.Api

# Run database migrations
dotnet ef database update

# Start the service
dotnet run
```

### Environment Configuration
Edit `docker-compose.yml` or `appsettings.json` to configure:
- SQL Server connection strings
- RabbitMQ host and credentials
- JWT secret key and expiration
- Google OAuth client ID/secret

## 📡 API Endpoints

### API Gateway (Client-Facing)
```
POST   /api/auth/register          - User registration
POST   /api/auth/login            - User login
POST   /api/auth/google-login     - Google OAuth login
GET    /api/movies                - List all movies
GET    /api/showtimes             - Get showtimes
POST   /api/bookings              - Create booking
GET    /api/bookings/{id}         - Get booking details
POST   /api/payments              - Process payment
```

### Auth System
```
POST   /api/auth/register         - Register new user
POST   /api/auth/login            - Login with credentials
POST   /api/auth/google-login     - Google OAuth authentication
GET    /api/users                 - Get all users (Admin)
GET    /api/users/{id}            - Get user by ID
PUT    /api/users/{id}            - Update user
DELETE /api/users/{id}            - Delete user (Admin)
```

### Movie System
```
GET    /api/movies                - List all movies
POST   /api/movies                - Create movie (Admin)
PUT    /api/movies/{id}           - Update movie (Admin)
DELETE /api/movies/{id}           - Delete movie (Admin)
GET    /api/cinemahalls           - List cinema halls
POST   /api/showtimes             - Create showtime (Admin)
```

### Booking System
```
GET    /api/bookings              - Get all bookings
GET    /api/bookings/{id}         - Get booking by ID
POST   /api/bookings              - Create new booking
PUT    /api/bookings/{id}         - Update booking status
```

### Payment System
```
GET    /api/payments              - Get all payments
GET    /api/payments/{id}         - Get payment by ID
POST   /api/payments              - Process payment
```

### Notification System
```
GET    /api/notifications         - Get user notifications
```

## 🗄️ Database Schema

### AuthDB
- **Users**: Id, Email, PasswordHash, Role, CreatedAt

### MovieDB
- **Movies**: Id, Title, Description, Duration, Genre, ReleaseDate
- **CinemaHalls**: Id, Name, TotalSeats, Location
- **Showtimes**: Id, MovieId, CinemaHallId, StartTime, Price
- **Seats**: Id, CinemaHallId, SeatNumber, Row

### BookingDB
- **Bookings**: Id, UserId, ShowtimeId, SeatIds, Status, TotalPrice, BookingDate

### PaymentDB
- **Payments**: Id, BookingId, Amount, Status, PaymentMethod, TransactionDate

### NotificationDB
- **Notifications**: Id, UserId, Message, Type, SentAt, IsRead

## 🔒 Authentication & Authorization

### JWT Configuration
- **Algorithm**: HS256
- **Token Lifetime**: 24 hours
- **Claims**: UserId, Email, Role
- **Header**: `Authorization: Bearer {token}`

### Roles
- **Admin**: Full access to all CRUD operations
- **User**: Can browse movies, create bookings, process payments

### Google OAuth Flow
1. Frontend redirects to Google login
2. User authenticates with Google
3. Frontend receives Google ID token
4. POST to `/api/auth/google-login` with ID token
5. Backend validates token and creates/returns JWT

## 🐰 RabbitMQ Events

### Published Events
**BookingSystem**:
- `BookingCreated` - When user creates a booking

**PaymentSystem**:
- `PaymentCompleted` - After successful payment
- `PaymentFailed` - If payment fails

### Consumed Events
**PaymentSystem**:
- Listens to `BookingCreated` → Initiates payment

**NotificationSystem**:
- Listens to `BookingCreated` → Sends booking confirmation
- Listens to `PaymentCompleted` → Sends payment receipt
- Listens to `PaymentFailed` → Sends failure notification

## 🧪 Testing

### Using Swagger
1. Navigate to API Gateway Swagger: http://localhost:7000/swagger
2. Register a new user via `/api/auth/register`
3. Login to get JWT token
4. Click "Authorize" and enter: `Bearer {your-token}`
5. Test protected endpoints

### Sample Request Flow
```bash
# 1. Register
curl -X POST http://localhost:7000/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{"email":"user@test.com","password":"Test123!","role":"User"}'

# 2. Login
curl -X POST http://localhost:7000/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"email":"user@test.com","password":"Test123!"}'

# 3. Get Movies (with token)
curl -X GET http://localhost:7000/api/movies \
  -H "Authorization: Bearer {your-token}"
```

## 📊 Project Statistics
- **Total Services**: 6 microservices + 1 API Gateway
- **REST Endpoints**: 40+ APIs
- **Database Tables**: 10+ entities across 5 databases
- **NuGet Packages**: Entity Framework Core, RabbitMQ.Client, BCrypt, Google.Apis.Auth
- **Lines of Code**: ~5,000+ lines (excluding generated files)

## 🛠️ Development

### Project Structure
```
TicketUZ/
├── APIGateway/          # API Gateway service
├── AuthSystem/          # Authentication service
├── MovieSystem/         # Movie catalog service
├── BookingSystem/       # Booking management
├── PaymentSystem/       # Payment processing
├── NotificationSystem/  # Notification handling
├── docker-compose.yml   # Docker orchestration
└── README.md           # This file
```

### Adding New Features
1. Identify the service responsible for the feature
2. Add DTOs in `Dtos/` folder
3. Implement business logic in `Services/`
4. Add controller endpoints in `Controllers/`
5. Update database with EF migrations
6. Test with Swagger

### Common Commands
```bash
# Rebuild specific service
docker-compose up -d --build authsystem

# View logs
docker-compose logs -f bookingsystem

# Stop all services
docker-compose down

# Clean volumes (database reset)
docker-compose down -v

# Create migration
dotnet ef migrations add MigrationName

# Update database
dotnet ef database update
```

## 🔍 Troubleshooting

**Services won't start**:
- Check if ports are available (7000, 5001-5005, 1433, 5672, 15672)
- Ensure Docker Desktop is running

**Database connection errors**:
- Wait 30 seconds for SQL Server container to fully start
- Check connection string in `docker-compose.yml`

**RabbitMQ not receiving events**:
- Verify RabbitMQ is running: http://localhost:15672
- Check queue bindings in RabbitMQ management UI

**JWT token expired**:
- Tokens last 24 hours - login again to get new token

## 🤝 Contributing
1. Fork the repository
2. Create feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Open Pull Request

---

**Made with ❤️ for learning microservices architecture**
    User->>Gateway: Register/Login
    Gateway->>Auth: Authenticate User
    Auth-->>Gateway: JWT Token
    Gateway-->>User: Access Token
    
    Note over User,Notification: Browse Movies
    User->>Gateway: Get Movies List
    Gateway->>Movie: Fetch Movies & Schedules
    Movie-->>Gateway: Movies Data
    Gateway-->>User: Display Movies
    
    Note over User,Notification: Seat Selection & Booking
    User->>Gateway: Select Movie & Show Time
    Gateway->>Movie: Get Available Seats
    Movie-->>Gateway: Seat Map
    Gateway-->>User: Display Available Seats
    
    User->>Gateway: Select Seats & Create Booking
    Gateway->>Booking: Create Reservation
    Booking->>Movie: Validate Seats Availability
    Movie-->>Booking: Seats Available
    Booking->>Auth: Validate User Token
    Auth-->>Booking: User Valid
    Booking-->>Gateway: Booking Created (Pending)
    Gateway-->>User: Booking ID & Payment Required
    
    Note over User,Notification: Payment Processing
    User->>Gateway: Initiate Payment
    Gateway->>Payment: Process Payment
    Payment->>Booking: Get Booking Details
    Booking-->>Payment: Booking Info
    Payment->>Payment: Process Transaction
    
    alt Payment Successful
        Payment-->>Gateway: Payment Success
        Payment->>Booking: Confirm Booking
        Booking-->>Payment: Booking Confirmed
        Payment->>Notification: Send Payment Receipt
        Booking->>Notification: Send Booking Confirmation
        Notification->>User: Email/SMS Confirmation
        Gateway-->>User: Booking Confirmed
    else Payment Failed
        Payment-->>Gateway: Payment Failed
        Payment->>Booking: Cancel Reservation
        Booking->>Movie: Release Seats
        Movie-->>Booking: Seats Released
        Payment->>Notification: Send Failure Notice
        Notification->>User: Email/SMS Payment Failed
        Gateway-->>User: Booking Cancelled
    end
    
    Note over User,Notification: View Booking History
    User->>Gateway: Get My Bookings
    Gateway->>Booking: Fetch User Bookings
    Booking-->>Gateway: Bookings List
    Gateway-->>User: Display Bookings
```

