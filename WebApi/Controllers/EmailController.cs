using Application.Features.Email.Commands.CreateEmailCommnad;
using Application.Features.Email.Queries.GetAllEmailsQuery;
using Application.Features.Email.Queries.GetEmailsByCanidateIdQyery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class EmailController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService(typeof(IMediator)) as IMediator;
        

        [HttpPost("/createEmail")]
        public async Task<IActionResult> CreateEmail(CreateEmailCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("/GetAllEmails")]
        public async Task<IActionResult> GetAllEmails()
        {
            var response = await Mediator.Send(new GetAllEmailsQuery());
            return Ok(response);
        }

        [HttpGet("/GetEmailsByCandidate/{CanidateId}")]
        public async Task<IActionResult> GetEmailsByCandidate(Guid CanidateId)
        {
            var query = new GetEmailsByCandidateIdQuery { CandidateId = CanidateId };
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
