using FileSource.Models.Entities.Licenses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FileSource.Infrastructure.Persistence.Repositories.Licenses
{
    public class LicenseRepository : Repository<License>, ILicenseRepository
    {
        public LicenseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<License>> GetAllValidLicenses(CancellationToken cancellationToken)
        {
            return await GetQueryable().Where(
                l => l.ValidTill >= DateOnly.FromDateTime(DateTime.Now) && l.IsAlreadyUsed == true && l.DeletedAt == null)
                .ToListAsync();
        }

        public override Task<License> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private IQueryable<License> GetQueryable()
        {
            return Context.License;
        }
    }
}
