using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Audiophile_e_commerce_API.Models;

public class PaymentDetails {
    public Guid PaymentDetailsId {get;set;}
    public double Amount {get;set;}
    public StatusPayment Status {get;set;} 
    public PaymentMethod Payment {get;set;} 
    public DateTime CreatedAt {get;set;}
    public virtual OrderDetails OrderDetails {get;set;}

}

public class PaymentDetailsConfiguration : IEntityTypeConfiguration<PaymentDetails>
{   
    public void Configure(EntityTypeBuilder<PaymentDetails> builder)
    {   
            builder.ToTable("PaymentDetails");
            builder.HasKey(p => p.PaymentDetailsId);
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Payment).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
        
    }
}

public enum StatusPayment {
    Paid,
    Unpaid
}

public enum PaymentMethod {
    EMoney,
    CashOnDelivery,
    Debit,
    Visa
}