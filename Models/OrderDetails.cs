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