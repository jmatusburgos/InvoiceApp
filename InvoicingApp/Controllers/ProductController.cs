using InvoicingApp.BusinessLogic.Contracts.Services;
using InvoicingApp.BusinessLogic.Services;
using InvoicingApp.DataAccess.Contexts;
using InvoicingApp.DataAccess.Repositories.Base;
using InvoicingApp.Domain.Models.Production;
using InvoicingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicingApp.Controllers
{
    public class ProductController : CrudControllerBase<Product, Guid>
    {
        #region Private Members

        private readonly IGenericService<Product, Guid> _service;

        #endregion

        #region Public Constructor

        public ProductController() : this(new GenericService<Product, Guid>(new GenericRepository<Product>(new MainDbContext())))
        {
        }

        public ProductController(IGenericService<Product,Guid> service) : base(service)
        {
            _service = service;
        }

        #endregion

        #region Public Controllers

        /// <inheritdoc/>
        public override ActionResult Index()
        {
            return View(_service.GetAll().OrderBy(x => x.Code).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Price = x.Price,
                ApplyTax = x.ApplyTax

            }));
        }

        #endregion

    }
}