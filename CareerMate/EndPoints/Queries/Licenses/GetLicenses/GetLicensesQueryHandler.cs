using FileSource.EndPoints.Handlers;
using FileSource.Infrastructure.Persistence.Repositories.Licenses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FileSource.EndPoints.Queries.Licenses.GetLicenses
{
    public class GetLicensesQueryHandler : IRequestHandler<GetLicensesQuery, BaseResponse>
    {
        private readonly ILicenseRepository _licenseRepository;

        public GetLicensesQueryHandler(ILicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }

        public async Task<BaseResponse> Handle(GetLicensesQuery query, CancellationToken cancellationToken)
        {
            return await _licenseRepository.GetLicenseList(query, cancellationToken);
        }
    }
}
