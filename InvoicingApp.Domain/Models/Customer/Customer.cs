using InvoicingApp.Domain.Contracts.Base;
using InvoicingApp.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.Domain.Models.Customer
{
    /// <summary>
    /// Customer Entity
    /// </summary>
    public class Customer : CommonEntity<Guid>, IHaveCode
    {
        /// <summary>
        /// Address of Customer
        /// </summary>
        public string Address { get; set; }
        
        /// <inheritdoc/>
        public string Code { get; set; }
    }
}
