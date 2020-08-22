using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InvoicingApp.ViewModels
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Codigo")]
        public string Code { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("Direccion")]
        public string Address { get; set; }
    }
}