using FileSource.Infrastructure.Persistence;
using FileSource.Infrastructure.Persistence.Repositories;
using FileSource.Models.Entities.SysAdmins;
using Microsoft.EntityFrameworkCore;
using System;
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
    }
}
