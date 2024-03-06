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
        List<User> usersInit =
        [
            new User() { UserId = Guid.Parse("afbebbde-e376-49cf-a3c9-67d321eac710"),FirstName="Arseni",LastName ="Dmitriev", Email="arseni@email", Password="Josy1", Telephone= "514-560-0334",Address="51, rue Pluton,Mercier,J6R 2G8",CreatedAt=DateTime.Now },
            new User() { UserId = Guid.Parse("afbebbde-e376-49cf-a3c9-67d321eac725"),FirstName="Josy",LastName ="Dmitrieva", Email="josy@email", Password="Josy1", Telephone= "+51-960-778-978",Address="123,calle Santa Rosa,Lima,Peru",CreatedAt=DateTime.Now },
        ];
        
        modelBuilder.Entity<User>(user => {
            user.ToTable("User");
            user.HasKey(p => p.UserId);
            user.Property(p => p.FirstName).IsRequired().HasMaxLength(150);
            user.Property(p => p.LastName).IsRequired().HasMaxLength(150);
            user.Property(p => p.Email).IsRequired();
            user.Property(p => p.Password).IsRequired();
            user.Property(p => p.Telephone).IsRequired();
            user.Property(p => p.Address).IsRequired();
            user.HasData(usersInit);
        });

        List<OrderDetails> orderDetailsInit =
        [
            new OrderDetails() { UserId = Guid.Parse("afbebbde-e376-49cf-a3c9-67d321eac710"),OrderDetailsId=Guid.Parse("a5138925-9da2-4ef4-9471-077caff07234"),Total=65.87,DateOrderPlaced =DateTime.Now},
        ];


        modelBuilder.Entity<OrderDetails>(orderDetail => {
            orderDetail.ToTable("OrderDetails");
            orderDetail.HasKey(p => p.OrderDetailsId);
            orderDetail.HasOne(p =>p.User).WithMany(p =>p.OrderDetails).HasForeignKey(p => p.UserId);
            orderDetail.HasOne(p =>p.PaymentDetails).WithOne(p =>p.OrderDetails).HasForeignKey<PaymentDetails>(p => p.PaymentDetailsId).IsRequired(false);
            orderDetail.Property(p =>p.Total).IsRequired();
            orderDetail.Property(p => p.DateOrderPaid).IsRequired(false);
            orderDetail.Property(p => p.DateOrderPlaced);
            orderDetail.HasData(orderDetailsInit);

        });

        modelBuilder.Entity<PaymentDetails>(payment => {
            payment.ToTable("PaymentDetails");
            payment.HasKey(p => p.PaymentDetailsId);
            payment.Property(p => p.Amount).IsRequired();
            payment.Property(p => p.Status).IsRequired();
            payment.Property(p => p.Payment).IsRequired();
            payment.Property(p => p.CreatedAt).IsRequired();
        });

        modelBuilder.Entity<ShoppingSession>(session=> {
            session.ToTable("ShoppingSession");
            session.HasKey(p => p.ShoppingSessionId);
            session.HasOne(p => p.User).WithOne(p =>p.ShoppingSession).HasForeignKey<User>(p =>p.UserId).IsRequired();
            session.Property(p => p.CreatedAt).IsRequired();

        });
    }
}