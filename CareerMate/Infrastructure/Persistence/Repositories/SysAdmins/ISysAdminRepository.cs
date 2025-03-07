using System.Threading.Tasks;
using System.Threading;
using System;
using FileSource.Abstractions.Repositories;
using FileSource.Models.Entities.SysAdmins;

namespace CareerMate.Infrastructure.Persistence.Repositories.SysAdmins
{
    public interface ISysAdminRepository : IRepository<SysAdmin>
    {
        Task<SysAdmin> GetSysAdminByApplicationUserId(Guid userId, CancellationToken cancellationToken);

        Task<bool> IsAnySysAdminExist();
    }
}
