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
    public DbSet<Technology> Technologies { get; set; }

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
            builder.HasMany(pl => pl.Technologies).WithOne(t => t.ProgramingLanguage)
                .HasForeignKey(t => t.ProgramingLanguageId);
        });

        modelBuilder.Entity<Technology>(builder =>
        {
            builder.ToTable("Technologies").HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Name).HasColumnName("Name");
            builder.Property(t => t.ProgramingLanguageId).HasColumnName("ProgramingLanguageId");
            builder.HasOne(t => t.ProgramingLanguage).WithMany(pl => pl.Technologies)
                .HasForeignKey(t => t.ProgramingLanguageId);
        });

        Technology[] technologyEntitySeeds = { new(1, "Spring", 1), new(2, "Jsp", 1) };
        modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);
    }
}