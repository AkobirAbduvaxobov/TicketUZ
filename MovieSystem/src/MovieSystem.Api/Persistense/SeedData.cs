using Microsoft.EntityFrameworkCore;
using MovieSystem.Api.Entities;

namespace MovieSystem.Api.Persistense;

public static class SeedData
{
    public static async Task SeedAsync(AppDbContext db)
    {
        // Only seed if DB is empty
        if (await db.Movies.AnyAsync()) return;

        var now = DateTime.UtcNow;
        var startDate = now.AddDays(20);

        // ─── Movies ───────────────────────────────────────────
        var movies = new List<Movie>
        {
            new Movie
            {
                Title = "Panox",
                Description = "O'zbekiston milliy kinematografiyasining eng yaxshi filmi. Vatanparvarlik va do'stlik haqida.",
                DurationMinutes = 110,
                Language = "Uzbek",
                Genre = "Drama",
                ReleaseDate = new DateTime(2024, 3, 1),
                Rating = 8.5m,
                CreatedAt = now,
                UpdatedAt = now
            },
            new Movie
            {
                Title = "Jannat onalar ayog'i ostida",
                Description = "Ona sevgisi va farzand burchini aks ettiruvchi ta'sirchan drama filmi.",
                DurationMinutes = 125,
                Language = "Uzbek",
                Genre = "Drama",
                ReleaseDate = new DateTime(2023, 5, 15),
                Rating = 9.1m,
                CreatedAt = now,
                UpdatedAt = now
            },
            new Movie
            {
                Title = "Xudo asrasin",
                Description = "Hayotiy vaziyatlar va insoniy qadriyatlar haqidagi komediya-drama.",
                DurationMinutes = 95,
                Language = "Uzbek",
                Genre = "Comedy",
                ReleaseDate = new DateTime(2024, 1, 20),
                Rating = 7.8m,
                CreatedAt = now,
                UpdatedAt = now
            }
        };

        await db.Movies.AddRangeAsync(movies);
        await db.SaveChangesAsync();

        // ─── Cinema Halls ──────────────────────────────────────
        var halls = new List<CinemaHall>
        {
            new CinemaHall { Name = "Drujba narodov", CreatedAt = now, UpdatedAt = now },
            new CinemaHall { Name = "Xumo arena",     CreatedAt = now, UpdatedAt = now },
            new CinemaHall { Name = "Magic hall",     CreatedAt = now, UpdatedAt = now }
        };

        await db.CinemaHalls.AddRangeAsync(halls);
        await db.SaveChangesAsync();

        // ─── Showtimes ─────────────────────────────────────────
        // 5 showtimes per movie = 15 total
        // Times: 09:00, 11:30, 14:00, 17:30, 20:00
        var times = new[] {
            TimeSpan.FromHours(9),
            TimeSpan.FromHours(11.5),
            TimeSpan.FromHours(14),
            TimeSpan.FromHours(17.5),
            TimeSpan.FromHours(20)
        };

        var showtimes = new List<Showtime>();
        var hallIndex = 0;

        foreach (var movie in movies)
        {
            for (int i = 0; i < 5; i++)
            {
                var hall = halls[hallIndex % halls.Count];
                var showDate = startDate.Date + times[i];

                showtimes.Add(new Showtime
                {
                    MovieId     = movie.MovieId,
                    CinemaHallId = hall.CinemaHallId,
                    StartTime   = showDate,
                    EndTime     = showDate.AddMinutes(movie.DurationMinutes),
                    MinPrice    = 25000m,
                    MaxPrice    = 60000m,
                    MaxRow      = 10,
                    MaxColumn   = 10
                });
                hallIndex++;
            }
        }

        await db.Showtimes.AddRangeAsync(showtimes);
        await db.SaveChangesAsync();

        // ─── Seats ────────────────────────────────────────────
        // Auto-generate seats for every showtime
        var seats = new List<Seat>();
        foreach (var showtime in showtimes)
        {
            var decreasePrice = (showtime.MaxPrice - showtime.MinPrice) / showtime.MaxRow;
            for (int row = 1; row <= showtime.MaxRow; row++)
            {
                for (int col = 1; col <= showtime.MaxColumn; col++)
                {
                    seats.Add(new Seat
                    {
                        ShowtimeId  = showtime.ShowtimeId,
                        Row         = row,
                        Column      = col,
                        IsAvailable = true,
                        Price       = showtime.MaxPrice - (decreasePrice * (row - 1))
                    });
                }
            }
        }

        await db.Seats.AddRangeAsync(seats);
        await db.SaveChangesAsync();

    }
}
