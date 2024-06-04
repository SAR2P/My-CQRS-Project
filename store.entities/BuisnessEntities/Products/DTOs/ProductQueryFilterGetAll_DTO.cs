using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entities.BuisnessEntities.Products.DTOs
{
    public class ProductQueryFilterGetAll_DTO
    {

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public double Price { get; set; }


    }
}
