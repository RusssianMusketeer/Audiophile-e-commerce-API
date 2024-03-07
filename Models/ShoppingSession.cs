using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Audiophile_e_commerce_API.Models;

public class ShoppingSession {
    public Guid ShoppingSessionId {get;set;}
    public Guid UserId {get;set;}
    public double Total {get;set;}
    public DateTime CreatedAt {get;set;}
    public DateTime ModifiedAt {get;set;}
    public virtual User User {get;set;}
}

public class ShoppingSessionConfiguration : IEntityTypeConfiguration<ShoppingSession>
{   
    public void Configure(EntityTypeBuilder<ShoppingSession> builder)
    {
            builder.ToTable("ShoppingSession");
            builder.HasKey(p => p.ShoppingSessionId);
            builder.HasOne(p => p.User).WithOne(p =>p.ShoppingSession).HasForeignKey<User>(p =>p.UserId).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
        
    }
}