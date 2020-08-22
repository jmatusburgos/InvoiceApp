using InvoicingApp.Domain.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.DataAccess.Contracts.Base
{
    public interface IBaseRepository<TEntity> 
        where TEntity : class
    {
        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="entity"></param>
        TEntity Add(TEntity entity);

        /// <summary>
        ///Get true if exists Any record by expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);


        /// <summary>
        /// Edit Entity
        /// </summary>
        /// <param name="entity"></param>
        void Edit(TEntity entity);

        /// <summary>
        /// Get IQueriable by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get First record by Expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// GetAll IQueriable
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// GetDbSet
        /// </summary>
        /// <returns></returns>
        DbSet<TEntity> GetDbSet();

        /// <summary>
        /// Save repository Context
        /// </summary>
        Task Save();

        /// <summary>
        /// Find By Key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<TEntity> FindByKey(params object[] keyValues);

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

    }
}
