using FileSource.Abstractions.Models.Queries;
using FileSource.Abstractions.Repositories;
using FileSource.EndPoints.Handlers;
using FileSource.Models.Entities.Licenses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FileSource.Infrastructure.Persistence.Repositories.Licenses
{
    public interface ILicenseRepository : IRepository<License>
    {
        Task<List<License>> GetAllValidLicenses(CancellationToken cancellationToken);

        Task<PagedResponse<License>> GetLicenseList(PagedQuery pagedQuery, CancellationToken cancellationToken);
    }
}
