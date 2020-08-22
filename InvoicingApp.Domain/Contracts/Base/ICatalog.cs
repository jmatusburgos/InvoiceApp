using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.Domain.Contracts.Base
{
    /// <summary>
    /// Catalog interface
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface ICatalog
    {
      /// <summary>
      /// Description of entity
      /// </summary>
      string Description { get; set; }
    }
}
