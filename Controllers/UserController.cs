using System.Data.Common;
using Audiophile_e_commerce_API.Models;
using Audiophile_e_commerce_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Audiophile_e_commerce_API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    IUserService userService;
    EcommerceContext dbcontext;

    public UserController( IUserService service, EcommerceContext db)
    {
        userService = service;
        dbcontext = db;
    }

    [HttpGet(Name = "GetUser")]
    [Route("[action]")]
    public IActionResult GetUsers()
    {
        return Ok(userService.GetUsers());
    }

    [HttpGet(Name = "CreateDb")]
    [Route("createdb")]
    public IActionResult CreateDatabe()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}
