using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities.BuisnessEntities.Products.Entities;


namespace Store.DataAccessLayer.EntitiesConfiguration
{
    public class ProductConfigure : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.ProductName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.ImageName).HasMaxLength(130);

            builder.HasIndex(x => x.ProductName);

        }
    }
}
