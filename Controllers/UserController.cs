using Audiophile_e_commerce_API.Models;
using Audiophile_e_commerce_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Audiophile_e_commerce_API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService service, EcommerceContext db) : ControllerBase
{

    readonly IUserService userService = service;
    readonly EcommerceContext dbcontext = db;

    [HttpGet(Name = "GetUser")]
    [Route("[action]")]
    public IActionResult GetUsers()
    {
        return Ok(userService.GetUsers());
    }

    [HttpPost(Name = "PostUser")]
    [Route("[action]")]
    public IActionResult PostUser([FromBody] User user)
    {
        userService.Save(user);
        return Ok();
    }


    [HttpPut("{id}", Name ="ModifyUser")]
    [Route("[action]")]
    public IActionResult ModifyUser(Guid id, [FromBody] User user)
    {
        userService.Update(id, user);
        return Ok();
    }

    [HttpDelete("{id}", Name ="DeleteUser")]
    [Route("[action]")]
    public IActionResult DeleteUser(Guid id)
    {
        userService.Delete(id);
        return Ok();
    }   

    [HttpGet(Name = "CreateDb")]
    [Route("createdb")]
    public IActionResult CreateDatabe()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}
