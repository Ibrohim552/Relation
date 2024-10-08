using Microsoft.EntityFrameworkCore;
using Relations.Entities;

namespace Relations.DataContext;

public sealed class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }

    //public DbSet<Company> Companies { get; set; }
    //public DbSet<Employee> Employees { get; set; }

    //public DbSet<Student> Students { get; set; }
    //public DbSet<Group> Courses { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql("Server=localhost;Port=5432;Database=relations_db;Username=postgres;Password=123456;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<User>()
            .HasOne(x => x.Profile)
            .WithOne(x => x.User)
            .HasForeignKey<Profile>(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Profile>()
            .HasAlternateKey(x => x.UserId);
        
        

        modelBuilder.Entity<Company>()
            .HasMany(x => x.Employees)
            .WithOne(x => x.Company)
            .HasForeignKey(x => x.CompanyId)
            .IsRequired();
        

        modelBuilder.Entity<Student>()
            .HasMany(x => x.StudentGroups)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId)
            .IsRequired();

        modelBuilder.Entity<Group>()
            .HasMany(x => x.StudentGroups)
            .WithOne(x => x.Group)
            .HasForeignKey(x => x.GroupId)
            .IsRequired();

    }
}