using InvoicingApp.BusinessLogic.Contracts.Services;
using InvoicingApp.Domain.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InvoicingApp.Controllers
{
    public class CrudControllerBase<TEntity,TKey> : Controller
        where TEntity : class , IEntity
    {
        #region Private Members

        private readonly IServiceBase<TEntity, TKey> _service;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service"></param>
        public CrudControllerBase(IServiceBase<TEntity,TKey> service)
        {
            _service = service;
        }

        #endregion

        #region Public Methods

        // GET: Customer
        public virtual ActionResult Index()
        => View(_service.GetAll().ToList());

        /// <summary>
        /// Edit Record
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual async Task<ActionResult> Edit(TKey Id)
        => View(await _service.Find(Id));


        /// <summary>
        /// Save Record
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<ActionResult> Edit(TEntity entity)
        {
            await _service.Modify(entity);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Create View
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Create()
        => View();

        [HttpPost]
        public async virtual Task<ActionResult> Create(TEntity entity)
        {
            await _service.Create(entity);
            return RedirectToAction("Index");
        }


        #endregion


    }
}