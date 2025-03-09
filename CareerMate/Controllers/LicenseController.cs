using FileSource.Abstractions.Enums;
using FileSource.API.Controllers;
using FileSource.EndPoints.Commands.Licenses.Create;
using FileSource.EndPoints.Commands.Licenses.Delete;
using FileSource.EndPoints.Queries.Licenses.GetLicenses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Authorize(Policy = Policies.SysAdminOnly)]
        public async Task<IActionResult> CreateLicense([FromBody] CreateLicenseCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return ToActionResult(result);
        }

        [HttpGet]
        [Authorize(Policy = Policies.SysAdminOnly)]
        public async Task<IActionResult> GetLicenses([FromQuery] GetLicensesQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return ToActionResult(result);
        }

        [HttpDelete("{id:Guid}")]
        [Authorize(Policy = Policies.SysAdminOnly)]
        public async Task<IActionResult> DeleteLicense([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteLicenseCommand()
            {
                LicenseId = id
            };

            var result = await _mediator.Send(command, cancellationToken);
            return ToActionResult(result);
        }
    }
}
