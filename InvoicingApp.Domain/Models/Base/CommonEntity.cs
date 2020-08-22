using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.Domain.Models.Base
{
    /// <summary>
    /// CommonEntity class base
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class CommonEntity<TKey> : Entity<TKey>
    {
        public string Name { get; set; }
    }
}
