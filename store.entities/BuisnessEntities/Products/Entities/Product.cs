using Store.Entities.Common.baseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entities.BuisnessEntities.Products.Entities
{
    public class Product : BaseEntity
    {

        //private ICollection<ProductGallery> _productGalleries;
        //private ICollection<ProductVisits> _ProductVisits;
        //private ICollection<ProductSelectedCategory>? _ProductSelectedCategories;

        //public Product()
        //{
        //    ProductGallery = new List<ProductGallery>();
        //    ProductVisits = new List<ProductVisits>();
        //    ProductSelectedCategory = new List<ProductSelectedCategory>();
        //}

        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public bool IsExists { get; set; }
        public bool IsSpecial { get; set; }


        //public ICollection<ProductGallery> ProductGalleries { get; set; }

        //public ICollection<ProductVisits> productVisits { get; set; }

        //public ICollection<ProductSelectedCategory> ProductSelectedCategories { get; set; }

    }
}
