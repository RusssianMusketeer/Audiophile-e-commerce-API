namespace Audiophile_e_commerce_API.Models;

public class Product {
    public Guid ProductId {get;set;}
    public double Price {get;set;}
    public string Name {get;set;}
    public string Description {get;set;}
    public DateTime CreatedAt {get;set;}
}