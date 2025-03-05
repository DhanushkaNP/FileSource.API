using FileSource.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FileSource.Infrastructure.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
    {
        protected Repository(AppDbContext context)
        {
            Context = context;
        }

        protected AppDbContext Context { get; set; }

        public virtual IRepository<TEntity> Add(TEntity entity)
        {
            Context.Add(entity);
            return this;
        }

        public virtual IRepository<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Context.Add(entity);
            }

            return this;
        }

        public virtual IRepository<TEntity> Update(TEntity entity)
        {
            Context.Update(entity);
            return this;
        }

        public virtual IRepository<TEntity> Remove(TEntity entity)
        {
            Context.Remove(entity);
            return this;
        }

        public virtual IRepository<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Context.Remove(entity);
            }

            return this;
        }

        public virtual void DetachEntity(object entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }

        public abstract Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
           return await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken)
        {
            return await Context.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
