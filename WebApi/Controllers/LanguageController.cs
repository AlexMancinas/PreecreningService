using Application.Features.Language.Commands.CreateLanguageCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class LanguageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LanguageController(IMediator medaitor)
        {
            _mediator = medaitor;
        }

        [HttpPost("/CreateLangugae")]
        public async Task<IActionResult> CreateLanguage(CreateLanguageCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
