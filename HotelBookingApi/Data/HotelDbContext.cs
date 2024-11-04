using HotelBookingApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Data
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public HotelDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
