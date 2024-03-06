namespace Audiophile_e_commerce_API.Models;

public class PaymentDetails {
    public Guid PaymentDetailsId {get;set;}
    public double Amount {get;set;}
    public StatusPayment Status {get;set;} 
    public PaymentMethod Payment {get;set;} 
    public DateTime CreatedAt {get;set;}
    public virtual OrderDetails OrderDetails {get;set;}

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