using BowlingApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace BowlingApp.Repository;

public class BowlingContext
{
    public virtual DbSet<User> Users { get; set; }
}