using Audiophile_e_commerce_API.Models;
using Microsoft.EntityFrameworkCore;

public class EcommerceContext: DbContext {
    public DbSet<User> Users {get;set;}

    public EcommerceContext(DbContextOptions<EcommerceContext> options) :base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<User> usersInit =
        [
            new User() { UserId = Guid.Parse("afbebbde-e376-49cf-a3c9-67d321eac710"),Name="Arseni", Email="arseni@email", Password="Josy1"},
            new User() { UserId = Guid.Parse("afbebbde-e376-49cf-a3c9-67d321eac732"),Name="Josy", Email="Josy@email", Password="Josy2"},
        ];
        
        modelBuilder.Entity<User>(user => {
            user.ToTable("User");
            user.HasKey(p => p.UserId);
            user.Property(p => p.Name).IsRequired().HasMaxLength(150);
            user.Property(p => p.Email).IsRequired();
            user.Property(p => p.Password).IsRequired();
            user.HasData(usersInit);
        });
    }
}