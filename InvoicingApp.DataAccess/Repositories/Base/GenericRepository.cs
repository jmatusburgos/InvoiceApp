using InvoicingApp.DataAccess.Contexts;
using InvoicingApp.DataAccess.Contracts.Base;
using InvoicingApp.Domain.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.DataAccess.Repositories.Base
{
    public class GenericRepository<TEntity> : BaseRepository<TEntity, MainDbContext>, IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        public GenericRepository(MainDbContext context) : base(context)
        {
        }
    }
}
