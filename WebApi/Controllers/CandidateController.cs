using Application.Features.Colaborator.Commands.CreateCandidateCommand;
using Application.Features.Colaborator.Commands.DeleteCandidateCommand;
using Application.Features.Colaborator.Commands.UpdateCandidateCommand;
using Application.Features.Colaborator.Queries.GetAllCandidates;
using Application.Features.Colaborator.Queries.GetCandidateById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Features.Colaborator.Commands.CreateCandidateCommand.CreateCandidateCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class CandidateController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService(typeof(IMediator)) as IMediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/GetAllCandidates")]
        public async Task<IActionResult> GetAllCandidates()
        {
            var response = await Mediator.Send(new GetAllCandidatesQuery());
            return Ok(response);
        }

        [HttpGet("/GetCandidateById/{id}")]
        public async Task<IActionResult> GetCandidateById(Guid id)
        {
            var response = await Mediator.Send(new GetCandidateByIdQuery { Id = id });
            return Ok(response);
        }

        /// <summary>
        /// Post a new candiate
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("/CreateCandidate")]
        public async Task<IActionResult> CreateCandidate(CreateCandidateCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }


        /// <summary>
        /// Update a candidate
        /// </summary>
        /// <param name="id">Takes the an Id parameter</param>
        /// <param name="command">Send it to UpdateCandidateCommand using Mediator</param>
        /// <returns></returns>
        [HttpPut("/UpdateCandidate/{id}")]
        public async Task<IActionResult> UpdateCandidate(Guid id, UpdateCandidateCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var response = await Mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Logic delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("/DeleteCandidate/{id}")]
        public async Task<IActionResult> DeleteCandidate(Guid id, DeleteCandidateCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
