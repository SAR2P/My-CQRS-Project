using Store.Entities.Common.baseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entities.BuisnessEntities.Products.Entities
{
    public class ProductCategory: BaseEntity
    {
        private ICollection<ProductSelectedCategory>? _productSelectedCategory;

        public ProductCategory()
        {
            
        }

        public string? Title { get; set; }

        public long? parentId { get; set; }

        public ProductCategory? ParentCategori { get; set; }//self Relation

        public ICollection<ProductSelectedCategory>? ProductSelectedCategories {
            get { return _productSelectedCategory; }
            set { _productSelectedCategory = value; }
        }

    }
}
