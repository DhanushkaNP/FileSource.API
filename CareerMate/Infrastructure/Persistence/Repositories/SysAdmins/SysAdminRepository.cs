using CareerMate.EndPoints.Handlers;
using CareerMate.EndPoints.Queries.Users.SysAdmins;
using FileSource.Abstractions.Models.Queries;
using FileSource.Infrastructure.Persistence;
using FileSource.Infrastructure.Persistence.Repositories;
using FileSource.Models.Entities.SysAdmins;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CareerMate.Infrastructure.Persistence.Repositories.SysAdmins
{
    public class SysAdminRepository : Repository<SysAdmin>, ISysAdminRepository
    {
        public SysAdminRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<SysAdmin> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Context.SysAdmin.Include(s => s.ApplicationUser).FirstOrDefaultAsync(s => s.Id == id && s.DeletedAt == null, cancellationToken);
        }

        public async Task<SysAdmin> GetSysAdminByApplicationUserId(Guid userId, CancellationToken cancellationToken)
        {
            IQueryable<SysAdmin> query = Context.SysAdmin.Where(c => c.ApplicationUserId == userId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> IsAnySysAdminExist()
        {
            return await Context.SysAdmin.AnyAsync(c => c.DeletedAt == null);
        }

        public async Task<PagedResponse<GetSysAdminUsersListQueryItem>> GetSysAdminList(PagedQuery pagedQuery, CancellationToken cancellationToken)
        {
            IQueryable<SysAdmin> query = Context.SysAdmin.Include(s => s.ApplicationUser).Where(s => s.DeletedAt == null);

            if (!string.IsNullOrEmpty(pagedQuery.Search))
            {
                query = query
                    .Include(sa => sa.ApplicationUser)
                    .Where(sa => sa.ApplicationUser.FirstName.ToLower().Contains(pagedQuery.Search.ToLower()) ||
                        sa.ApplicationUser.LastName.ToLower().Contains(pagedQuery.Search.ToLower()) ||
                        string.Concat(sa.ApplicationUser.FirstName.ToLower(), " ", sa.ApplicationUser.LastName.ToLower()).Contains(pagedQuery.Search.ToLower()) ||
                        sa.ApplicationUser.Email.ToLower().Contains(pagedQuery.Search.ToLower()));
            }

            int count = await query.CountAsync();

            query = query.OrderByDescending(sa => sa.CreatedAt)
                 .Skip(pagedQuery.Offset)
                 .Take(pagedQuery.Limit);

            List<SysAdmin> sysAdminList = await query.ToListAsync();

            IEnumerable<GetSysAdminUsersListQueryItem> responseItems = sysAdminList.Select(s => new GetSysAdminUsersListQueryItem(
                    s.ApplicationUser.FirstName,
                    s.ApplicationUser.LastName,
                    s.ApplicationUser.Email,
                    s.CreatedAt,
                    s.Id));

            return new PagedResponse<GetSysAdminUsersListQueryItem>()
            {
                Items = responseItems,
                Meta = new PagedResponseMetaData()
                {
                    Offset = pagedQuery.Offset,
                    Count = count
                }
            };
        }
    }
}
