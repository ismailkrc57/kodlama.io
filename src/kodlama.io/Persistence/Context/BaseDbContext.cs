using Core.Security.Entities;
using Core.Security.Hashing;
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
    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<GithubAccount> GithubAccounts { get; set; }

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

        modelBuilder.Entity<User>(builder =>
        {
            builder.ToTable("Users").HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.FirstName).HasColumnName("FirstName");
            builder.Property(u => u.LastName).HasColumnName("LastName");
            builder.Property(u => u.Email).HasColumnName("Email");
            builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
            builder.Property(u => u.Status).HasColumnName("Status");
            builder.HasMany(u => u.RefreshTokens).WithOne(rt => rt.User).HasForeignKey(rt => rt.UserId);
        });


        modelBuilder.Entity<OperationClaim>(builder =>
        {
            builder.ToTable("OperationClaims").HasKey(oc => oc.Id);
            builder.Property(oc => oc.Id).HasColumnName("Id");
            builder.Property(oc => oc.Name).HasColumnName("Name");
        });

        modelBuilder.Entity<UserOperationClaim>(builder =>
        {
            builder.ToTable("UserOperationClaims").HasKey(uoc => new { uoc.UserId, uoc.OperationClaimId });
            builder.Property(uoc => uoc.UserId).HasColumnName("UserId");
            builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId");
        });
        modelBuilder.Entity<RefreshToken>(builder =>
        {
            builder.ToTable("RefreshTokens").HasKey(rt => rt.Id);
            builder.Property(rt => rt.Id).HasColumnName("Id");
            builder.Property(rt => rt.Token).HasColumnName("Token");
            builder.Property(rt => rt.Expires).HasColumnName("Expires");
            builder.Property(rt => rt.UserId).HasColumnName("UserId");
            builder.Property(rt => rt.Created).HasColumnName("Created");
            builder.Property(rt => rt.CreatedByIp).HasColumnName("CreatedByIp");
            builder.Property(rt => rt.Revoked).HasColumnName("Revoked");
            builder.Property(rt => rt.RevokedByIp).HasColumnName("RevokedByIp");
            builder.Property(rt => rt.ReplacedByToken).HasColumnName("ReplacedByToken");
            builder.Property(rt => rt.ReasonRevoked).HasColumnName("ReasonRevoked");
            builder.HasOne(rt => rt.User).WithMany(u => u.RefreshTokens).HasForeignKey(rt => rt.UserId);
        });
        modelBuilder.Entity<GithubAccount>(builder =>
        {
            builder.ToTable("GithubAccounts").HasKey(ga => ga.Id);
            builder.Property(ga => ga.Id).HasColumnName("Id");
            builder.Property(ga => ga.UserId).HasColumnName("UserId");
            builder.Property(ga => ga.Username).HasColumnName("Username");
            builder.Property(ga => ga.Url).HasColumnName("Url");
            builder.HasOne(ga => ga.User);
        });

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash("123456", out passwordHash, out passwordSalt);

        User[] users =
        {
            new()
            {
                Id = 1, FirstName = "Admin", LastName = "Admin", Email = "",
                PasswordHash = passwordHash, PasswordSalt = passwordSalt,
                Status = true
            },
            new()
            {
                Id = 2, FirstName = "User", LastName = "User", Email = "",
                PasswordHash = passwordHash, PasswordSalt = passwordSalt,
                Status = true
            }
        };
        OperationClaim[] operationClaims =
        {
            new() { Id = 1, Name = "Admin" },
            new() { Id = 2, Name = "User" }
        };
        UserOperationClaim[] userOperationClaims =
        {
            new() { UserId = 1, OperationClaimId = 1 },
            new() { UserId = 2, OperationClaimId = 2 }
        };
        GithubAccount[] githubAccounts =
        {
            new()
            {
                Id = 1, UserId = 1, Username = "admin", Url = ""
            },
            new()
            {
                Id = 2, UserId = 2, Username = "user", Url = ""
            }
        };
        Technology[] technologyEntitySeeds = { new(1, "Spring", 1), new(2, "Jsp", 1) };
        modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);
        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<OperationClaim>().HasData(operationClaims);
        modelBuilder.Entity<UserOperationClaim>().HasData(userOperationClaims);
        modelBuilder.Entity<GithubAccount>().HasData(githubAccounts);
    }
}