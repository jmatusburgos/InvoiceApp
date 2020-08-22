using InvoicingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.BusinessLogic.Contracts.Services
{
    public interface IInvoiceService
    {
        IEnumerable<InvoiceViewModel> GetInvoices();
    }
}
