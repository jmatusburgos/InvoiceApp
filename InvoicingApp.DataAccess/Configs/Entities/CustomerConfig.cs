using InvoicingApp.Domain.Models.Customer;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InvoicingApp.DataAccess.Configs.Entities
{
    /// <summary>
    /// class for customer entity
    /// </summary>
    public class CustomerConfig : EntityTypeConfiguration<Customer>
    {
        public CustomerConfig()
        {
            ToTable("Customers", "Customer").HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
