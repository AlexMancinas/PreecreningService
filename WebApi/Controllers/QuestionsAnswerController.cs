using Application.Features.QuestionsAnswer.Commands.CreateQuestionsAnswerCommand;
using Application.Features.QuestionsAnswer.Commands.LogicDeleteQuestionsAnswerCommand;
using Application.Features.QuestionsAnswer.Commands.UpdateQuestionsAnswerCommand;
using Application.Features.QuestionsAnswer.Queries.GetAllQuestionsAnswerQuery;
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

        [HttpGet("/GetAllQuestionsAnswers")]
        public async Task<IActionResult> GetAllQuestionsAnswers()
        {
            var response = await _mediator.Send(new GetAllQuestionsAnswerQuery());
            return Ok(response);
        }

        [HttpPut("/DeleteQuestionsAnswer/{id}")]
        public async Task<IActionResult> DeleteQuestionsAnswer(Guid id)
        {
            var response = await _mediator.Send(new LogicDeleteQuestionsAnswerCommand { Id = id });
            return Ok(response);
        }

        [HttpPut("/UpdateQuestionsAnswer/{id}")]
        public async Task<IActionResult> UpdateQuestionsAnswer(Guid id, UpdateQuestionsAnswerCommand command)
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
