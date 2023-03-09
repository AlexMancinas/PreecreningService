using Application.Features.Phone.Commands.CreatePhoneCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class PhoneController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PhoneController(IMediator medaitor)
        {
            _mediator = medaitor;
        }

        [HttpPost("/CreatePhone")]
        public async Task<IActionResult> CreatePhone(CreatePhoneCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
