using Store.Entities.Common.baseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entities.BuisnessEntities.Products.Entities
{
    public class ProductVisits : BaseEntity
    {
        public long UserIp { get; set; }

        public long ProductId { get; set; }
        public Product? Product { get; set; }


    }
}
