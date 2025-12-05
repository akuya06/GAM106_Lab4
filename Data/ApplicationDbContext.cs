using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System;

namespace WebApplication1.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<GameLevel> GameLevels { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<GameResult> GameResults { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.UserId);

            entity.Property(u => u.UserName).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Email).HasMaxLength(255);

            entity.Property(u => u.RegionId).HasColumnName("RegionId");
            entity.Property(u => u.RoleId).HasColumnName("RoleId");

            entity.HasOne(u => u.Region)
                  .WithMany() // or .WithMany(r => r.Users) if you add collection
                  .HasForeignKey(u => u.RegionId)
                  .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(u => u.Role)
                  .WithMany()
                  .HasForeignKey(u => u.RoleId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        // GameLevel
        modelBuilder.Entity<GameLevel>(entity =>
        {
            entity.HasKey(e => e.levelId);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);

            entity.HasMany(l => l.Questions)
                  .WithOne(q => q.Level)
                  .HasForeignKey(q => q.LevelId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(l => l.GameResults)
                  .WithOne(gr => gr.Level)
                  .HasForeignKey(gr => gr.LevelId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Question
        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.questionId);
            entity.Property(e => e.ContentQuestion).IsRequired();
            entity.Property(e => e.Answer).IsRequired();
            entity.Property(e => e.Option1).HasMaxLength(500);
            entity.Property(e => e.Option2).HasMaxLength(500);
            entity.Property(e => e.Option3).HasMaxLength(500);
            entity.Property(e => e.Option4).HasMaxLength(500);
        });

        // GameResult
        modelBuilder.Entity<GameResult>(entity =>
        {
            entity.HasKey(e => e.resultId);
            entity.Property(e => e.Score);
            entity.Property(e => e.CompletionDate);
        });

        // Seed data (use the actual property names defined in the model classes)
        modelBuilder.Entity<Role>().HasData(
            new Role { roleId = 1, Name = "Cleric" },
            new Role { roleId = 2, Name = "Warrior" },
            new Role { roleId = 3, Name = "Knight" },
            new Role { roleId = 4, Name = "Mage" },
            new Role { roleId = 5, Name = "Ranger" }
        );

        modelBuilder.Entity<Region>().HasData(
            new Region { regionId = 1, regionName = "Vietnam" },
            new Region { regionId = 2, regionName = "United States" },
            new Region { regionId = 3, regionName = "Japan" },
            new Region { regionId = 4, regionName = "South Korea" },
            new Region { regionId = 5, regionName = "China" },
            new Region { regionId = 6, regionName = "United Kingdom" },
            new Region { regionId = 7, regionName = "France" },
            new Region { regionId = 8, regionName = "Germany" },
            new Region { regionId = 9, regionName = "Canada" },
            new Region { regionId = 10, regionName = "Australia" },
            new Region { regionId = 11, regionName = "Brazil" },
            new Region { regionId = 12, regionName = "India" },
            new Region { regionId = 13, regionName = "Thailand" },
            new Region { regionId = 14, regionName = "Singapore" },
            new Region { regionId = 15, regionName = "Netherlands" },
            new Region { regionId = 16, regionName = "Switzerland" },
            new Region { regionId = 17, regionName = "Sweden" },
            new Region { regionId = 18, regionName = "Italy" },
            new Region { regionId = 19, regionName = "Spain" },
            new Region { regionId = 20, regionName = "Russia" }
        );

        modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, UserName = "john_doe", Email = "john@example.com", RegionId = 1, RoleId = 2, LinkAvatar = "avt1.png", OTP = "123456" },
            new User { UserId = 2, UserName = "jane_smith", Email = "jane@example.com", RegionId = 2, RoleId = 2, LinkAvatar = "avt2.png", OTP = "654321" }
        );

        modelBuilder.Entity<GameLevel>().HasData(
            new GameLevel { levelId = 1, Title = "Easy", Description = "Basic questions" },
            new GameLevel { levelId = 2, Title = "Medium", Description = "Intermediate questions" }
        );

        modelBuilder.Entity<Question>().HasData(
            new Question
            {
                questionId = 1,
                ContentQuestion = "What is 2 + 2?",
                Option1 = "3",
                Option2 = "4",
                Option3 = "5",
                Option4 = "22",
                Answer = "4",
                LevelId = 1
            },
            new Question
            {
                questionId = 2,
                ContentQuestion = "Which planet is known as the Red Planet?",
                Option1 = "Earth",
                Option2 = "Mars",
                Option3 = "Jupiter",
                Option4 = "Venus",
                Answer = "Mars",
                LevelId = 1
            }
        );

        modelBuilder.Entity<GameResult>().HasData(
            new GameResult { resultId = 1, UserId = 1, LevelId = 1, Score = 100, CompletionDate = new DateTime(2025,11,12) },
            new GameResult { resultId = 2, UserId = 2, LevelId = 2, Score = 85, CompletionDate = new DateTime(2025,11,12) }
        );
    }
}
