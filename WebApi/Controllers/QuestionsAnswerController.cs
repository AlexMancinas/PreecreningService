using Application.Features.QuestionsAnswer.Commands.CreateQuestionsAnswerCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class QuestionsAnswerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionsAnswerController(IMediator medaitor)
        {
            _mediator = medaitor;
        }

        [HttpPost("/CreateQuestionsAnswer")]
        public async Task<IActionResult> CreateQuestionsAnswer(CreateQuestionsAnswerCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
