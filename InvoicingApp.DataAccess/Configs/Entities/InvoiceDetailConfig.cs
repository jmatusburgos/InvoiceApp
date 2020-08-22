using InvoicingApp.Domain.Models.Invoice;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InvoicingApp.DataAccess.Configs.Entities
{
    public class InvoiceDetailConfig : EntityTypeConfiguration<InvoiceDetail>
    {
        public InvoiceDetailConfig()
        {
            ToTable("InvoiceDetails", "Sales").HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(x => x.Product).WithMany().HasForeignKey(f => f.ProductId);
        }
    }
}
