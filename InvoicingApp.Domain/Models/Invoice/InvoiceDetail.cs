using InvoicingApp.Domain.Models.Base;
using InvoicingApp.Domain.Models.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.Domain.Models.Invoice
{
    public class InvoiceDetail: Entity<Guid>
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Invoice Id
        /// </summary>
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Price of product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity of products on detail
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Tax applied
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// SubTotal of detail without taxes
        /// </summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Total of Detail
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Virtual property of Invoice
        /// </summary>
        public virtual Invoice Invoice { get; set; }

        /// <summary>
        /// Virtual Property of Product
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
