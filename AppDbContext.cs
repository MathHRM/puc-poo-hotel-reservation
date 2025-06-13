using backend.Models;
using Microsoft.EntityFrameworkCore;
using Models;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomReservation> RoomReservations { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
