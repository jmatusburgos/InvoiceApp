using InvoicingApp.Domain.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.Domain.Models.Base
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}
