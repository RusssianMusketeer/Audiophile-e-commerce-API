namespace Audiophile_e_commerce_API.Models;

public class OrderItems {
    public Guid OrderItemsId {get;set;}
    public Guid OrderDetailsId {get;set;}
    public Guid ProductId {get;set;}
    public int Quantity {get;set;}
    public DateTime CreatedAt {get;set;}
}