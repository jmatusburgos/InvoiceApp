using InvoicingApp.Domain.Models.Customer;
using InvoicingApp.Domain.Models.Invoice;
using InvoicingApp.Domain.Models.Production;
using System.Data.Entity;

namespace InvoicingApp.DataAccess.Contexts
{
    /// <summary>
    /// Main Db Context
    /// </summary>
    public class MainDbContext : DbContext
    {
        #region Public Members

        /// <summary>
        /// Customer 
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Invoice
        /// </summary>
        public DbSet<Invoice> Invoices { get; set; }

        /// <summary>
        /// Invoice Details
        /// </summary>
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }


        #endregion

        public MainDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MainDbContext>());
        }

        /// <summary>
        /// On Model Create
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Configs.Entities.CustomerConfig());
            modelBuilder.Configurations.Add(new Configs.Entities.InvoiceConfig());
            modelBuilder.Configurations.Add(new Configs.Entities.InvoiceDetailConfig());
            modelBuilder.Configurations.Add(new Configs.Entities.ProductConfig());
        }
    }
}
