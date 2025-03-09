using FileSource.Abstractions.Models.Queries;
using FileSource.EndPoints.Handlers;
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
            return GetQueryable()
                .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
        }

        public async Task<PagedResponse<License>> GetLicenseList(PagedQuery pagedQuery, CancellationToken cancellationToken)
        {
            IQueryable<License> query = GetQueryable().Where(s => s.DeletedAt == null).AsNoTracking();

            if (!string.IsNullOrEmpty(pagedQuery.Search))
            {
                query = query
                    .Where(l => l.Id ==  new Guid(pagedQuery.Search));
            }

            int count = await query.CountAsync();

            query = query.OrderByDescending(sa => sa.CreatedAt)
                 .Skip(pagedQuery.Offset)
                 .Take(pagedQuery.Limit);

            List<License> licenseList = await query.ToListAsync();

            return new PagedResponse<License>
            {
                Items = licenseList,
                Meta = new PagedResponseMetaData()
                {
                    Offset = pagedQuery.Offset,
                    Count = count
                }
            };

        }

        private IQueryable<License> GetQueryable()
        {
            return Context.License;
        }
    }
}
