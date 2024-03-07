using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Audiophile_e_commerce_API.Models;

public class OrderDetails {
    public Guid OrderDetailsId {get;set;}
    public Guid UserId {get;set;}
    public double Total {get;set;}
    public DateTime DateOrderPlaced {get;set;}
    public DateTime? DateOrderPaid {get;set;}
    public Guid PaymentDetailsId {get;set;}
    public virtual User User {get;set;}
    public virtual PaymentDetails PaymentDetails {get;set;}
   
} 

public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
{   
    
        List<OrderDetails> orderDetailsInit =
        [
            new OrderDetails() { UserId = Guid.Parse("afbebbde-e376-49cf-a3c9-67d321eac710"),OrderDetailsId=Guid.Parse("a5138925-9da2-4ef4-9471-077caff07234"),Total=65.87,DateOrderPlaced =DateTime.Now},
        ];

        public void Configure(EntityTypeBuilder<OrderDetails> builder)
    {
        
            builder.ToTable("OrderDetails");
            builder.HasKey(p => p.OrderDetailsId);
            builder.HasOne(p =>p.User).WithMany(p =>p.OrderDetails).HasForeignKey(p => p.UserId);
            builder.HasOne(p =>p.PaymentDetails).WithOne(p =>p.OrderDetails).HasForeignKey<PaymentDetails>(p => p.PaymentDetailsId).IsRequired(false);
            builder.Property(p =>p.Total).IsRequired();
            builder.Property(p => p.DateOrderPaid).IsRequired(false);
            builder.Property(p => p.DateOrderPlaced);
            builder.HasData(orderDetailsInit);

        
    }
}