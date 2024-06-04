
using Microsoft.EntityFrameworkCore;
using Store.Entities.BuisnessEntities.Products.DTOs;
using Store.Entities.BuisnessEntities.Products.Entities;



namespace Store.DataAccessLayer.EntitiesExtention.ProductExtention
{
    public static class ProductQueryExtention
    {
        public static IQueryable<Product> ByProductName(this IQueryable<Product> products, string ProductName)
        {
            if(!string.IsNullOrEmpty(ProductName))
            {
                products = products.Where(x => x.ProductName == ProductName);
               
            }
            return products;
        }

        public static async Task<List<ProductFilterByProductName_DTO>> forProductSearchByProductName(this IQueryable<Product> products)
        {
            var productResult = await products.Select(x => new ProductFilterByProductName_DTO
            {
                ProductName = x.ProductName,
                Price = x.Price
            }).ToListAsync();

            return productResult;
        }

        public static IQueryable<Product> ById(this IQueryable<Product> products, long Id) 
        {
            if( Id != 0 && !string.IsNullOrEmpty(Id.ToString()))
            {
                products = products.Where(x => x.id == Id);
            }
            return products;

        }

        public static async Task<ProductFilterById_DTO> ForProductQueryResultSearchById(this IQueryable<Product> products)
        {
            var result = await products.Select(x => new ProductFilterById_DTO()
            {
                ProductName = x.ProductName,
                Price = x.Price,
                ShortDescription = x.ShortDescription,
                Description = x.Description
            }).FirstOrDefaultAsync();

            return result!;
        }

    }
}
