using InvoicingApp.DataAccess.Contracts.Base;
using InvoicingApp.Domain.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.DataAccess.Repositories.Base
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        #region Private Members

        private readonly TContext _context;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(TContext context)
        {
            _context = context;
        }

        #endregion

        /// <inheritdoc/>
        public virtual TEntity Add(TEntity entity)
        {
            GetDbSet().Add(entity);
            return entity;
        }

        /// <inheritdoc/>
        public virtual async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        => await GetDbSet().AnyAsync(predicate);

        /// <inheritdoc/>
        public void Delete(TEntity entity)
        {
            GetDbSet().Attach(entity);
            GetDbSet().Remove(entity);
        }

        /// <inheritdoc/>
        public virtual void Edit(TEntity entity)
        => _context.Entry(entity).State = EntityState.Modified;

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        => GetDbSet().Where(predicate);

        /// <inheritdoc/>
        public async Task<TEntity> FindByKey(params object[] keyValues)
        => await GetDbSet().FindAsync(keyValues);

        /// <inheritdoc/>
        public virtual Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        => GetDbSet().FirstOrDefaultAsync(predicate);

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> GetAll()
        => GetDbSet();

        /// <inheritdoc/>
        public virtual DbSet<TEntity> GetDbSet()
        => _context.Set<TEntity>();

        /// <inheritdoc/>
        public virtual async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex )
            {
                throw;
            }
        }
    }
}
