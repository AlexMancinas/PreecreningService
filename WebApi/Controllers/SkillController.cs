using Application.Features.Skill.Commands.CreateSkillCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class SkillController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillController(IMediator medaitor)
        {
            _mediator = medaitor;
        }

        [HttpPost("/CreateSkill")]
        public async Task<IActionResult> CreateSkill(CreateSkillCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
