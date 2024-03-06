using Audiophile_e_commerce_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Audiophile_e_commerce_API.Services;

public class OrderDetailsService(EcommerceContext dbcontext) : IOrderDetailsService {
    readonly EcommerceContext context = dbcontext;

    public IEnumerable<OrderDetails> GetOrderDetails() {
        return context.OrderDetails;
    }

    public async Task Save(OrderDetails orderDetails) {
        orderDetails.DateOrderPlaced= DateTime.Now;
        context.Add(orderDetails);
        await context.SaveChangesAsync();
    }

        public async Task Update(Guid id, OrderDetails orderDetails)
    {
        var orderDetailsActual = context.OrderDetails.Find(id);

        if(orderDetailsActual != null)
        {
            orderDetailsActual.Total  = orderDetails.Total;
            await context.SaveChangesAsync();
        }
    }

        public async Task Delete(Guid id)
    {
        var orderDetailsActual = context.OrderDetails.Find(id);

        if(orderDetailsActual != null)
        {
            context.Remove(orderDetailsActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface IOrderDetailsService {
    IEnumerable<OrderDetails> GetOrderDetails();
    Task Save(OrderDetails orderDetails);
    Task Update(Guid id, OrderDetails orderDetails);
    Task Delete(Guid id);
}