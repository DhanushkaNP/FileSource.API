using System.Threading.Tasks;
using System.Threading;
using System;
using FileSource.Abstractions.Repositories;
using FileSource.Models.Entities.SysAdmins;
using CareerMate.EndPoints.Queries.Users.SysAdmins;
using FileSource.Abstractions.Models.Queries;
using FileSource.EndPoints.Handlers;

namespace CareerMate.Infrastructure.Persistence.Repositories.SysAdmins
{
    public interface ISysAdminRepository : IRepository<SysAdmin>
    {
        Task<SysAdmin> GetSysAdminByApplicationUserId(Guid userId, CancellationToken cancellationToken);

        Task<bool> IsAnySysAdminExist();

        Task<PagedResponse<GetSysAdminUsersListQueryItem>> GetSysAdminList(PagedQuery pagedQuery, CancellationToken cancellationToken);
    }
}
