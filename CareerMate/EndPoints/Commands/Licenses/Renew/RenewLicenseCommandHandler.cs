using FileSource.Infrastructure.Persistence.Repositories.Licenses;
using FileSource.Models.Entities.Licenses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FileSource.EndPoints.Commands.Licenses.Renew
{
    public class RenewLicenseCommandHandler : IRequestHandler<RenewLicenseCommand>
    {
        private readonly ILicenseRepository _licenseRepository;

        public RenewLicenseCommandHandler(ILicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }

        public async Task Handle(RenewLicenseCommand command, CancellationToken cancellationToken)
        {
            List<License> validLicenseList = await _licenseRepository.GetAllValidLicenses(cancellationToken);

            foreach (License license in validLicenseList)
            {
                license.SetTodayLimit(license.DailyLimit);
                _licenseRepository.Update(license);
            }

            await _licenseRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
