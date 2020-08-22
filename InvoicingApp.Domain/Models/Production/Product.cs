using InvoicingApp.Domain.Contracts.Base;
using InvoicingApp.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.Domain.Models.Production
{
    /// <summary>
    /// Product Entity
    /// </summary>
    public class Product : CommonEntity<Guid>, IHaveCode
    {
        /// <summary>
        /// define if product apply for tax
        /// </summary>
        public bool ApplyTax { get; set; }

        /// <inheritdoc/>
        public string Code { get; set; }

        /// <summary>
        /// Price of Product
        /// 
        /// </summary>
        public decimal Price { get; set; }
    }
}
