using InvoicingApp.BusinessLogic.Contracts.Services;
using InvoicingApp.DataAccess.Contracts.Base;
using InvoicingApp.Domain.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.BusinessLogic.Services
{
    public abstract class ServiceBase<TEntity,TKey> : IServiceBase<TEntity,TKey>
        where TEntity : class
    {
        #region Private Members

        private readonly IBaseRepository<TEntity> _repository;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="repository"></param>
        public ServiceBase(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> Create(TEntity entity)
        {
            if(entity is IHaveCode) 
            {
                (entity as IHaveCode).Code = $"{typeof(TEntity).Name.ToUpper()}-0{_repository.GetAll().Count() + 1}";
            }
            var record = _repository.Add(entity);
            await _repository.Save();

            return record;
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> Delete(TKey id)
        {
            var entity = await _repository.FindByKey(id);
            if(entity == null)
            {
                return null;
            }

            _repository.Delete(entity);
            await _repository.Save();

            return entity;

        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> Find(params object[] keyValues)
        => await _repository.FindByKey(keyValues);

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> expression)
        => _repository.FindBy(expression);

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> GetAll()
        => _repository.GetAll();

        /// <inheritdoc/>
        public virtual async Task Modify(TEntity entity)
        {
            _repository.Edit(entity);
            await _repository.Save();
        }

        public void SetCde(TEntity entity)
        {
            if (entity is IHaveCode)
                (entity as IHaveCode).Code = $"{typeof(TEntity).Name.ToUpper()}-0{_repository.GetAll().Count() + 1}";

        }



        #endregion
    }
}
