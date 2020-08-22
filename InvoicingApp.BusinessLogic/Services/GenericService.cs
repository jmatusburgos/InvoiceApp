using InvoicingApp.BusinessLogic.Contracts.Services;
using InvoicingApp.DataAccess.Contracts.Base;
using InvoicingApp.Domain.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.BusinessLogic.Services
{
    public class GenericService<TEntity, TKey> : ServiceBase<TEntity, TKey>, IGenericService<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public GenericService(IGenericRepository<TEntity> repository) : base(repository)
        {
        }
    }
}
