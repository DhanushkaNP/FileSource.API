using FileSource.EndPoints.Commands.Licenses.Renew;
using MediatR;
using Quartz;
using System.Threading.Tasks;

namespace FileSource.API.BackgroundJobs
{
    public class RenewLicenseBackgroundJob : IJob
    {
        private readonly IMediator _mediator;

        public RenewLicenseBackgroundJob(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _mediator.Send(new RenewLicenseCommand());
        }
    }
}
