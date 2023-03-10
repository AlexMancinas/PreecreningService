using Application.Features.Certification.Commands.CreateCertificationCommand;
using Application.Features.Certification.Commands.LogicDeleteCertificationCommand;
using Application.Features.Certification.Commands.UpdateCertificationCommand;
using Application.Features.Certification.Queries.GetAllCertificationsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class CertificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CertificationController(IMediator medaitor)
        {
            _mediator = medaitor;
        }

        [HttpPost("/CreateCertification")]
        public async Task<IActionResult> CreateCertification(CreateCertificationCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("/GetAllCertifications")]
        public async Task<IActionResult> GetAllCertifications()
        {
            var response = await _mediator.Send(new GetAllCertificationsQuery());
            return Ok(response);
        }

        [HttpPut("/DeleteCertification/{id}")]
        public async Task<IActionResult> DeleteCertification(Guid id)
        {
            var response = await _mediator.Send(new LogicDeleteCertificationCommand { Id = id });
            return Ok(response);
        }

        [HttpPut("/UpdateCertification/{id}")]
        public async Task<IActionResult> UpdateCertification(Guid id, UpdateCertificationCommand command)
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
