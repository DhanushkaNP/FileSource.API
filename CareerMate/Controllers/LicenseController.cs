using FileSource.API.Controllers;
using FileSource.EndPoints.Commands.Licenses.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FileSource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : BaseController
    {
        private readonly IMediator _mediator;

        public LicenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLicense([FromBody] CreateLicenseCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return ToActionResult(result);
        }
    }
}
