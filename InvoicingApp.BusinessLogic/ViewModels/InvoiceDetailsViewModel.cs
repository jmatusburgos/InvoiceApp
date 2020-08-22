using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicingApp.ViewModels
{
    public class InvoiceDetailsViewModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }
        public decimal Tax { get; set; }

        public int Quantity { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public Guid productId { get; set; }
    }
}