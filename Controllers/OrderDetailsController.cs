using Audiophile_e_commerce_API.Models;
using Audiophile_e_commerce_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Audiophile_e_commerce_API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderDetailsController(IOrderDetailsService service, EcommerceContext db) : ControllerBase
{

    readonly IOrderDetailsService orderDetailsService = service;
    readonly EcommerceContext dbcontext = db;

    [HttpGet(Name = "GetOrderDetails")]
    [Route("[action]")]
    public IActionResult GetOrderDetails()
    {
        return Ok(orderDetailsService.GetOrderDetails());
    }

    [HttpPost(Name = "PostOrderDetails")]
    [Route("[action]")]
    public IActionResult PostOrderDetails([FromBody] OrderDetails orderDetails)
    {
        orderDetailsService.Save(orderDetails);
        return Ok();
    }


    [HttpPut("{id}", Name = "ModifyOrderDetails")]
    [Route("[action]")]
    public IActionResult ModifyOrderDetails(Guid id, [FromBody] OrderDetails orderDetails)
    {
        orderDetailsService.Update(id, orderDetails);
        return Ok();
    }

    [HttpDelete("{id}", Name = "DeleteOrderDetails")]
    [Route("[action]")]
    public IActionResult DeleteOrderDetails(Guid id)
    {
        orderDetailsService.Delete(id);
        return Ok();
    }   
}
