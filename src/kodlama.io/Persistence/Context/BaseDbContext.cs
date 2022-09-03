using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context;

public class BaseDbContext : DbContext
{
    public BaseDbContext(IConfiguration configuration, DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }
    public DbSet<ProgramingLanguage> ProgramingLanguages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProgramingLanguage>(builder =>
        {
            builder.ToTable("ProgramingLanguages").HasKey(pl => pl.Id);
            builder.Property(pl => pl.Id).HasColumnName("Id");
            builder.Property(pl => pl.Name).HasColumnName("Name");
        });
    }
}