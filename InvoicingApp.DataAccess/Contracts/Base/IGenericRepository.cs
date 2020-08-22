using InvoicingApp.Domain.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.DataAccess.Contracts.Base
{
    public interface IGenericRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity: class, IEntity
    {
    }
}
