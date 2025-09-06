using ChroCar.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class ChroCarDbContext : DbContext
{
    public ChroCarDbContext(DbContextOptions<ChroCarDbContext> options)
        : base(options)
    {
    }

    public DbSet<Brand> Brands { get; set; }
}