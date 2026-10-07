using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SteppaWeb.Models;

public class SteppaDbContext : IdentityDbContext
{
    public SteppaDbContext(DbContextOptions<SteppaDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}