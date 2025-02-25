using BowlingApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace BowlingApp.Repository;

public class AppDbContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}