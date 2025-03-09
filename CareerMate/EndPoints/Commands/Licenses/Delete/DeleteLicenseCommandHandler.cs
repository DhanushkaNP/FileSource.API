using FileSource.EndPoints.Handlers;
using FileSource.Infrastructure.Persistence.Repositories.Licenses;
using FileSource.Models.Entities.Licenses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FileSource.EndPoints.Commands.Licenses.Delete
{
    public class DeleteLicenseCommandHandler : IRequestHandler<DeleteLicenseCommand, BaseResponse>
    {
        private readonly ILicenseRepository _licenseRepository;

        public DeleteLicenseCommandHandler(ILicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }

        public async Task<BaseResponse> Handle(DeleteLicenseCommand command, CancellationToken cancellationToken)
        {
            License license = await _licenseRepository.GetByIdAsync(command.LicenseId, cancellationToken);

            if (license == null)
            {
                return new NotFoundResponse<License>();
            }

            license.Delete();

            _licenseRepository.Update(license);

            await _licenseRepository.SaveChangesAsync(cancellationToken);

            return new SuccessResponse();
        }
    }
}
