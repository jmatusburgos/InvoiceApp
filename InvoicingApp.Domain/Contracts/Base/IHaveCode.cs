using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingApp.Domain.Contracts.Base
{
    /// <summary>
    /// Interface for Entities with code
    /// </summary>
    public interface IHaveCode
    {
        /// <summary>
        /// Unique Code for Entity
        /// </summary>
        string Code { get; set; }
    }
}
