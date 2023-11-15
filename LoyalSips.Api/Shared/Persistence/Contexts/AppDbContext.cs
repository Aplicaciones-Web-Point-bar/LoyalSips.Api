using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LoyalSips.Api.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public DbSet<Bar> Pubs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Support> Supports { get; set; }

    public DbSet<Point> Points { get; set; }
    
    public DbSet<RegistroPoint> RegistroPoints { get; set; }
    
    public DbSet<Inventory> Inventories { get; set; }
    
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    //aqui se definen los nombres de las columnas en la BD que seran de CategoryLL y TutorialLL respectivamente.
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Tabla Usuarios o User
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.email).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(30);
        
        //FK
        
        
        
        // Tabla Bares o Pubs
        builder.Entity<Bar>().ToTable("Pubs");
        builder.Entity<Bar>().HasKey(p => p.Id);
        builder.Entity<Bar>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Bar>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Bar>().Property(p => p.Description).IsRequired().HasMaxLength(200);
        builder.Entity<Bar>().Property(p => p.Logo).IsRequired().HasMaxLength(700);

        builder.Entity<Bar>().Property(p => p.Fotos)
            .HasConversion(v => string.Join(',', v), // Convertir la lista de cadenas a una sola cadena
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToList() // Convertir la cadena a una lista de cadenas
        ).HasMaxLength(1400);;
       
        
        builder.Entity<Bar>().Property(p => p.Puntaje).IsRequired();
        builder.Entity<Bar>().Property(p => p.Ubicacion).IsRequired().HasMaxLength(700);;
        
        
        // Tabla Support
        builder.Entity<Support>().ToTable("Supports");
        builder.Entity<Support>().HasKey(p => p.Id);
        builder.Entity<Support>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Support>().Property(p => p.Description).IsRequired().HasMaxLength(255);

        
        //Tabla Point
        builder.Entity<Point>().ToTable("Points");
        builder.Entity<Point>().HasKey(p => p.Id);
        builder.Entity<Point>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Point>().Property(p => p.Sale).IsRequired();
        builder.Entity<Point>().Property(p => p.Total).IsRequired();
        builder.Entity<Point>().Property(p => p.Description).IsRequired().HasMaxLength(350);
        //builder.Entity<Point>().Property(p => p.OwnerId).IsRequired();
        
        
        //Tabla registro de puntos
        builder.Entity<RegistroPoint>().ToTable("RegistroPuntos");
        builder.Entity<RegistroPoint>().HasKey(p => p.Id);
        builder.Entity<RegistroPoint>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<RegistroPoint>().Property(p => p.puntosGanados).IsRequired();
        
        
        // Tabla Inventario
        builder.Entity<Inventory>().ToTable("Inventories");
        builder.Entity<Inventory>().HasKey(p => p.Id);
        builder.Entity<Inventory>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Inventory>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Inventory>().Property(p => p.Category).IsRequired().HasMaxLength(200);
        builder.Entity<Inventory>().Property(p => p.Quantity).IsRequired().HasMaxLength(700);
        builder.Entity<Inventory>().Property(p => p.netContent).IsRequired().HasMaxLength(700);
        builder.Entity<Inventory>().Property(p => p.Price).IsRequired().HasMaxLength(700);
        
        
        // convert to snake case
        builder.UseSnakeCaseNamingConvention();
    }
}