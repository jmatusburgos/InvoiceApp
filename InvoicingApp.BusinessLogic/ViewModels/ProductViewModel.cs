using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InvoicingApp.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Codigo")]
        public string Code { get; set; }
        
        [DisplayName("Aplica Tax")]
        public bool ApplyTax { get; set; }
        
        [DisplayName("Precio")]
        public decimal Price { get; set; }
    }
}