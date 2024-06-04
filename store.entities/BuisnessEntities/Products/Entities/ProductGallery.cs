using Store.Entities.Common.baseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entities.BuisnessEntities.Products.Entities
{
    public class ProductGallery : BaseEntity
    {
        public string ImageName { get; set; }

        public long ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
