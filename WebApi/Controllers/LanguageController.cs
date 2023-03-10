using Application.Features.Language.Commands.CreateLanguageCommand;
using Application.Features.Language.Commands.LogicDeleteLanguageCommand;
using Application.Features.Language.Commands.UpdateLanguageCommand;
using Application.Features.Language.Queries.GetAllCandidatesQuery;
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

        [HttpGet("/GetAllLanguages")]
        public async Task<IActionResult> GetAllLanguages()
        {
            var response = await _mediator.Send(new GetAllLanguagesQuery());
            return Ok(response);
        }

        [HttpPut("/DeleteLanguage/{id}")]
        public async Task<IActionResult> DeleteLanguage(Guid id)
        {
            var response = await _mediator.Send(new LogicDeleteLanguageCommand { Id = id });
            return Ok(response);
        }

        [HttpPut("/UpdateLanguage/{id}")]
        public async Task<IActionResult> UpdateLanguage(Guid id, UpdateLanguageCommand command)
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
