using ManagementSystem.Application.CQRS.Users.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static ManagementSystem.Application.CQRS.Users.Handlers.GetByEmail;

namespace ManagementSystemProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet]
    [Route("GetByEmail")]

    public async Task<IActionResult> GetByEmail([FromQuery] Query request)
    {
        return Ok(await _sender.Send(request));


    }
    [HttpGet]
    public async Task<IActionResult> GetById(GetById.Query request)
    {

    }

}
