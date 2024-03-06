namespace Audiophile_e_commerce_API.Models;

public class CartItem {
    public Guid CartItemId {get;set;}
     public Guid SAhoppingSessionId {get;set;}
    public Guid ProductId {get;set;}
    public int Quantity {get;set;}
    public DateTime CreatedAt {get;set;}
    public DateTime ModifiedAt {get;set;}

}