using InvoicingApp.Domain.Contracts.Base;
using InvoicingApp.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.Domain.Models.Invoice
{
    public class Invoice : Entity<Guid>, IHaveCode
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <inheritdoc/>
        public string Code { get; set; }

        /// <summary>
        /// Sub Total of invoice
        /// </summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Total of Invoice
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Virtual property
        /// </summary>
        public virtual Customer.Customer Customer { get; set; }

        /// <summary>
        /// Public virtual invoices details
        /// </summary>
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
