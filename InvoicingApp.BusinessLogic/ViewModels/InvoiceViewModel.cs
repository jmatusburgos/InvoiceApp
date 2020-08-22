using InvoicingApp.Domain.Models.Invoice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InvoicingApp.ViewModels
{
    public class InvoiceViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Cliente")]
        public string CustomerName { get; set; }

        [DisplayName("Factura")]
        public string Code { get; set; }

        /// <summary>
        /// SubTotal
        /// </summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Total of invoice
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Invoice Details
        /// </summary>
        public ICollection<InvoiceDetailsViewModel> InvoiceDetails { get; set; }


    }
}