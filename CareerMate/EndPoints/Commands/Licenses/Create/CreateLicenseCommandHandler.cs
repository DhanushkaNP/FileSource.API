using FileSource.EndPoints.Handlers;
using FileSource.Infrastructure.Persistence.Repositories.Licenses;
using FileSource.Models.Entities.Licenses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileSource.EndPoints.Commands.Licenses.Create
{
    public class CreateLicenseCommandHandler : IRequestHandler<CreateLicenseCommand, BaseResponse>
    {
        private readonly ILicenseRepository _licenseRepository;

        public CreateLicenseCommandHandler(ILicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }

        public async Task<BaseResponse> Handle(CreateLicenseCommand command, CancellationToken cancellationToken)
        {
            License newLicense = new License(
                command.Type,
                command.DailyLimit,
                command.ValidDays,
                DateOnly.FromDateTime(DateTime.Today.AddDays(command.ValidDays)),
                command.DailyLimit);

            _licenseRepository.Add(newLicense);

            await _licenseRepository.SaveChangesAsync(cancellationToken);

            return new SuccessResponse();
        }
    }
}
