using InvoicingApp.BusinessLogic.Contracts.Services;
using InvoicingApp.DataAccess.Contracts.Base;
using InvoicingApp.Domain.Models.Invoice;
using InvoicingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.BusinessLogic.Services
{
    public class InvoiceService : ServiceBase<Invoice, Guid>, IInvoiceService
    {
        #region Private Members

        private readonly IGenericRepository<Invoice> _repository;
        private readonly IGenericRepository<InvoiceDetail> _invoiceDetailRespository;

        #endregion
        public InvoiceService(IGenericRepository<Invoice> repository, IGenericRepository<InvoiceDetail> invoiceDetailRepository) : base(repository)
        {
            _repository = repository;
            _invoiceDetailRespository = invoiceDetailRepository;
        }

        public IEnumerable<InvoiceViewModel> GetInvoices()
        {
            return _repository.GetDbSet().Select(x => new InvoiceViewModel
            {
                Id = x.Id,
                Code = x.Code,
                CustomerName = x.Customer.Name,
                SubTotal = x.SubTotal,
                Total = x.Total,
                InvoiceDetails = x.InvoiceDetails.Select(i => new InvoiceDetailsViewModel { 
                  Price = i.Price,
                  ProductCode = i.Product.Code,
                  ProductName = i.ProductName,
                  Quantity = i.Quantity,
                  Tax = i.Tax,
                  SubTotal = i.SubTotal,
                  Total = i.Total
                }).ToList()
            }).OrderBy(x=>x.Code);
        }

        public async override Task<Invoice> Create(Invoice entity)
        {
            SetCde(entity);

            foreach (var item in entity.InvoiceDetails)
            {
                item.SubTotal = item.Price * item.Quantity;
                item.Total = (item.Price * item.Quantity) + (item.Tax / 100 * (item.Price * item.Quantity));
            }
            entity.SubTotal = entity.InvoiceDetails.Any() ? entity.InvoiceDetails.Select(x => x.SubTotal).Sum() : default;
            entity.Total = entity.InvoiceDetails.Any() ? entity.InvoiceDetails.Select(x => x.Total).Sum() : default;

            _repository.Add(entity);
            await _repository.Save();
            return entity;

        }
    }
}
