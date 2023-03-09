using Application.Features.Certification.Commands.CreateCertificationCommand;
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


    }
}
