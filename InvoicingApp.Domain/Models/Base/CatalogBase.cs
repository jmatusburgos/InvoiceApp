using InvoicingApp.Domain.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.Domain.Models.Base
{
    /// <summary>
    /// abstract class for catalog class base
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class CatalogBase<TKey> : CommonEntity<TKey>,  ICatalog
    {
        public string Description { get; set; }
    }
}
