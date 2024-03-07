using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Audiophile_e_commerce_API.Models;

public class User {
    public Guid UserId {get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string Email {get;set;}
    public string Password {get;set;}
    public string Telephone {get;set;}
    public string Address {get;set;}
    public DateTime CreatedAt {get;set;}
    [JsonIgnore]
    public virtual ICollection<OrderDetails>? OrderDetails {get;set;}
    public virtual ShoppingSession ShoppingSession {get;set;} 

}

public class UserConfiguration : IEntityTypeConfiguration<User>
{   
            List<User> usersInit =
        [
            new User() { UserId = Guid.Parse("afbebbde-e376-49cf-a3c9-67d321eac710"),FirstName="Arseni",LastName ="Dmitriev", Email="arseni@email", Password="Josy1", Telephone= "514-560-0334",Address="51, rue Pluton,Mercier,J6R 2G8",CreatedAt=DateTime.Now },
            new User() { UserId = Guid.Parse("afbebbde-e376-49cf-a3c9-67d321eac725"),FirstName="Josy",LastName ="Dmitrieva", Email="josy@email", Password="Josy1", Telephone= "+51-960-778-978",Address="123,calle Santa Rosa,Lima,Peru",CreatedAt=DateTime.Now },
        ];
    public void Configure(EntityTypeBuilder<User> builder)
    {
            builder.ToTable("User");
            builder.HasKey(p => p.UserId);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.Telephone).IsRequired();
            builder.Property(p => p.Address).IsRequired();
            builder.HasData(usersInit);
        
    }
}