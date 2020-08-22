using InvoicingApp.Domain.Models.Production;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InvoicingApp.DataAccess.Configs.Entities
{
    public class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            ToTable("Products", "Production").HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
