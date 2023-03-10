using Application.Features.Skill.Commands.CreateSkillCommand;
using Application.Features.Skill.Commands.LogicDeleteSkillCommand;
using Application.Features.Skill.Commands.UpdateSkillCommand;
using Application.Features.Skill.Queries.GetAllSkillsQuery;
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

        [HttpGet("/GetAllSkills")]
        public async Task<IActionResult> GetAllSkills()
        {
            var response = await _mediator.Send(new GetAllSkillsQuery());
            return Ok(response);
        }

        [HttpPut("/DeleteSkill/{id}")]
        public async Task<IActionResult> DeleteSkill(Guid id)
        {
            var response = await _mediator.Send(new LogicDeleteSkillCommand { Id = id });
            return Ok(response);
        }

        [HttpPut("/UpdateSkill/{id}")]
        public async Task<IActionResult> UpdateSkill(Guid id, UpdateSkillCommand command)
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
