using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace FileSource.Abstractions.Repositories
{
    public interface IRepository<TEntity>
    {
        IRepository<TEntity> Add(TEntity entity);

        IRepository<TEntity> AddRange(IEnumerable<TEntity> entities);

        IRepository<TEntity> Update(TEntity entity);

        IRepository<TEntity> Remove(TEntity entity);

        IRepository<TEntity> RemoveRange(IEnumerable<TEntity> entities);

        void DetachEntity(object entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken);
    }
}
