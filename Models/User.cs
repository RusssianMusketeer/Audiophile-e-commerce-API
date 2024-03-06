using System.Text.Json.Serialization;

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