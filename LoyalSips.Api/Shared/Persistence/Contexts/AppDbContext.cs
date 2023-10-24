using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LoyalSips.Api.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public DbSet<Bar> Pubs { get; set; }
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    //aqui se definen los nombres de las columnas en la BD que seran de CategoryLL y TutorialLL respectivamente.
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.email).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(30);
        
        //FK
    
        
        
        builder.Entity<Bar>().ToTable("Pubs");
        builder.Entity<Bar>().HasKey(p => p.Id);
        builder.Entity<Bar>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Bar>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Bar>().Property(p => p.Description).IsRequired().HasMaxLength(200);
        builder.Entity<Bar>().Property(p => p.Logo).IsRequired().HasMaxLength(700);
        
        
        builder.UseSnakeCaseNamingConvention();
    }
}