using Audiophile_e_commerce_API.Models;
using Microsoft.EntityFrameworkCore;

public class EcommerceContext: DbContext {
    public DbSet<User> Users {get;set;}
    public DbSet<OrderDetails> OrderDetails {get;set;}
    public DbSet<PaymentDetails> PaymentDetails {get;set;}
    public DbSet<ShoppingSession> ShoppingSession {get;set;}

    public EcommerceContext(DbContextOptions<EcommerceContext> options) :base(options) {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentDetailsConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingSessionConfiguration());
    }
}