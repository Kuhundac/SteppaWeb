using Microsoft.EntityFrameworkCore;

namespace SteppaWeb.Models;

public class SteppaDbContext : DbContext
{
    public SteppaDbContext(DbContextOptions<SteppaDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}