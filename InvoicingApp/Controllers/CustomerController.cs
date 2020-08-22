using InvoicingApp.BusinessLogic.Contracts.Services;
using InvoicingApp.BusinessLogic.Services;
using InvoicingApp.DataAccess.Contexts;
using InvoicingApp.DataAccess.Contracts.Base;
using InvoicingApp.DataAccess.Repositories.Base;
using InvoicingApp.Domain.Models.Customer;
using InvoicingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicingApp.Controllers
{
    public class CustomerController : CrudControllerBase<Customer, Guid>
    {
        #region 

        private readonly IGenericService<Customer, Guid> _service;

        #endregion

        #region Public Constructor

        #endregion
        public CustomerController() : this(new GenericService<Customer, Guid>(new GenericRepository<Customer>(new MainDbContext())))
        {
        }

        #region Public Controllers

        public CustomerController(IGenericService<Customer, Guid> service) : base(service)
        {
            _service = service;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public override ActionResult Index()
        {
            return View(_service.GetAll().OrderBy(x => x.Code).Select(x => new CustomerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Code = x.Code
            }));
        }

        #endregion

    }
}