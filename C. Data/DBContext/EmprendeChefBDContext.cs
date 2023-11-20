using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.DBContext;

public class EmprendeChefBDContext : DbContext
{
    public EmprendeChefBDContext()
    {
    }

    public EmprendeChefBDContext(DbContextOptions<EmprendeChefBDContext> options) : base(options)
    {
    }
    
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Businessman> Businessmen { get; set; }
    public DbSet<Food> Foods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            //datos sql
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=Jose192103@19;Database=EmprendeChefDB;", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Restaurant>().ToTable("Restaurant");
        builder.Entity<Restaurant>().HasKey(p => p.Id);
        builder.Entity<Restaurant>().Property(p => p.Name_Rest).IsRequired();
        builder.Entity<Restaurant>().Property(p => p.Name_Rest).HasMaxLength(60);
        builder.Entity<Restaurant>().Property(p => p.Schedule).IsRequired();
        builder.Entity<Restaurant>().Property(p => p.Location).IsRequired();
        builder.Entity<Restaurant>().Property(p => p.Category).IsRequired();
        builder.Entity<Restaurant>()
            .Property(p => p.PaymentMethods)
            .HasConversion(
                v => string.Join(",", v),  // Convertir List<string> a string para almacenar en la base de datos
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()  // Convertir de nuevo de string a List<string>
            )
            .IsRequired();        
        builder.Entity<Restaurant>().Property(p => p.Calls).IsRequired();
        builder.Entity<Restaurant>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Restaurant>().Property(p => p.IsActive).HasDefaultValue(true);

        
        builder.Entity<Businessman>().ToTable("Businessman");
        builder.Entity<Businessman>().HasKey(b => b.Id);
        builder.Entity<Businessman>().Property(b => b.Name).IsRequired();
        builder.Entity<Businessman>().Property(b => b.Email).IsRequired();
        builder.Entity<Businessman>().Property(b => b.PhoneNumber).IsRequired();
        builder.Entity<Businessman>().Property(b => b.Address).IsRequired();
        builder.Entity<Businessman>().Property(b => b.Description).IsRequired();
        builder.Entity<Businessman>().Property(b => b.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Businessman>().Property(b => b.IsActive).HasDefaultValue(true);

        /*
        // Configuración de la relación con Businessman (de 1 a 1)
        builder.Entity<Businessman>()
            .HasOne(b => b.Restaurant)
            .WithOne(r => r.Businessman)
            .HasForeignKey<Businessman>(b => b.RestaurantId);
        */
        
        builder.Entity<Food>().ToTable("Food");
        builder.Entity<Food>().HasKey(f => f.Id);
        builder.Entity<Food>().Property(f => f.Name).IsRequired();
        builder.Entity<Food>().Property(f => f.Description).IsRequired();
        builder.Entity<Food>().Property(f => f.Price).IsRequired();
        builder.Entity<Food>().Property(f => f.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Food>().Property(f => f.IsActive).HasDefaultValue(true);

        
        // Configuración de la relación con Food (de muchos a 1)
        builder.Entity<Food>()
            .HasOne(f => f.Restaurant)
            .WithMany(r => r.Foods)
            .HasForeignKey(f => f.RestaurantId);
    }
}