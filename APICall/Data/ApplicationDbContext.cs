using Microsoft.EntityFrameworkCore;
using APICall.Models; // Assuming your model classes are in this namespace

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Translation> YourEntities { get; set; } // DbSet for each of your model classes
}
