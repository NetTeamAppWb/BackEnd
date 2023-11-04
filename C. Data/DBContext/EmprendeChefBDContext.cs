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
        builder.Entity<Restaurant>().Property(p => p.Name).IsRequired();
        builder.Entity<Restaurant>().Property(p => p.Foods).IsRequired();
        builder.Entity<Restaurant>().Property(p => p.Schedule).HasDefaultValue(DateTime.Now);
        builder.Entity<Restaurant>().Property(p => p.Location).IsRequired();
        builder.Entity<Restaurant>().Property(p => p.Owner).IsRequired();
        builder.Entity<Restaurant>().Property(p => p.Payment).IsRequired();
        builder.Entity<Restaurant>().Property(p => p.Calls).IsRequired();
        
    }
    
}