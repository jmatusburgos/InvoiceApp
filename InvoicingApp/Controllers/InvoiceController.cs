using InvoicingApp.BusinessLogic.Contracts.Services;
using InvoicingApp.BusinessLogic.Services;
using InvoicingApp.DataAccess.Contexts;
using InvoicingApp.DataAccess.Repositories.Base;
using InvoicingApp.Domain.Models.Customer;
using InvoicingApp.Domain.Models.Invoice;
using InvoicingApp.Domain.Models.Production;
using InvoicingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InvoicingApp.Controllers
{
    public class InvoiceController : CrudControllerBase<Invoice, Guid>
    {
        #region private Members

        private readonly InvoiceService _service;
        private readonly IGenericService<Customer,Guid> _customerService;
        private readonly IGenericService<Product, Guid> _productService;
        private readonly MainDbContext _db;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="service"></param>
        public InvoiceController() : this(new InvoiceService(new GenericRepository<Invoice>(new DataAccess.Contexts.MainDbContext()),
                                                             new GenericRepository<InvoiceDetail>(new DataAccess.Contexts.MainDbContext())))
        {
            _db = new MainDbContext();
            _customerService = new GenericService<Customer, Guid>(new GenericRepository<Customer>(_db));
            _productService = new GenericService<Product, Guid>(new GenericRepository<Product>(_db));
        }

        public InvoiceController(InvoiceService service) : base(service)
        {
            _service = service;
        }

        #endregion

        public override ActionResult Index()
        {
            
            return View(_service.GetInvoices());
        }

        public override ActionResult Create()
        {
            ViewBag.products = _productService.GetAll().Select(x => new SelectListItem {  Text = x.Name , Value = x.Id.ToString()});
            ViewBag.customer = _customerService.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View();
        }

        public async override Task<ActionResult> Create(Invoice entity)
        {
            await _service.Create(entity);
            return Json("Registro Guardado");

        }

        [HttpGet]
        public async Task<ActionResult> GetInvoiceDetail(string productId, string quantity)
        {
            var id = Guid.Parse(productId);
            var cantidad = Convert.ToInt32(quantity);

            var result = await _productService.FindBy(x => x.Id == id).Select(x => new InvoiceDetailsViewModel
            {

                ProductName = x.Name,
                productId = x.Id,
                Price = x.Price,
                ProductCode = x.Code,
                Quantity = cantidad,
                Tax = x.ApplyTax ? 15 : 0,
                Total = cantidad * x.Price

            }).FirstOrDefaultAsync();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}