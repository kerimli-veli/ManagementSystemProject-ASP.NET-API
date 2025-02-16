using ManagementSystem.Application.CQRS.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryControllers(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            return Ok(await _sender.Send(request));
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Create([FromBody]           )
        {

            return Ok(await _sender)
        }
    }
}
