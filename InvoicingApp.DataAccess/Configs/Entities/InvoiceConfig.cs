using InvoicingApp.Domain.Models.Invoice;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InvoicingApp.DataAccess.Configs.Entities
{
    /// <summary>
    /// Invoice Config
    /// </summary>
    public class InvoiceConfig : EntityTypeConfiguration<Invoice>
    {
        public InvoiceConfig()
        {
            ToTable("Invoices", "Sales").HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(x => x.InvoiceDetails).WithRequired(x => x.Invoice).HasForeignKey(f => f.InvoiceId);
            HasRequired(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);
        }
    }
}
