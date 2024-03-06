namespace Audiophile_e_commerce_API.Models;

public class ShoppingSession {
    public Guid ShoppingSessionId {get;set;}
    public Guid UserId {get;set;}
    public double Total {get;set;}
    public DateTime CreatedAt {get;set;}
    public DateTime ModifiedAt {get;set;}
    public virtual User User {get;set;}
}