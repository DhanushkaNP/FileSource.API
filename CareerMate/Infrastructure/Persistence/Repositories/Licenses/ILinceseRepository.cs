using FileSource.Abstractions.Repositories;
using FileSource.Models.Entities.Licenses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FileSource.Infrastructure.Persistence.Repositories.Licenses
{
    public interface ILicenseRepository : IRepository<License>
    {
        Task<List<License>> GetAllValidLicenses(CancellationToken cancellationToken);
    }
}
