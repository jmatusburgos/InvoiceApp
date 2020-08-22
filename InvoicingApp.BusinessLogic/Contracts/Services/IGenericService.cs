using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.BusinessLogic.Contracts.Services
{
    public interface IGenericService<TEntity,TKey> : IServiceBase<TEntity,TKey>
        where TEntity : class
    {
    }
}
