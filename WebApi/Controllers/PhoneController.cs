using Application.Features.Phone.Commands.CreatePhoneCommand;
using Application.Features.Phone.Commands.LogicDeletePhoneCommand;
using Application.Features.Phone.Commands.UpdatePhoneCommand;
using Application.Features.Phone.Queries.GetAllPhonesQuery;
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

        [HttpGet("/GetAllPhones")]
        public async Task<IActionResult> GetAllPhones()
        {
            var response = await _mediator.Send(new GetAllPhonesQuery());
            return Ok(response);
        }

        [HttpPut("/DeletePhone/{id}")]
        public async Task<IActionResult> DeletePhone(Guid id)
        {
            var response = await _mediator.Send(new LogicDeletePhoneCommand { Id = id});
            return Ok(response);
        }

        [HttpPut("/UpdatePhone/{id}")]
        public async Task<IActionResult> UpdatePhone(Guid id, UpdatePhoneCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
