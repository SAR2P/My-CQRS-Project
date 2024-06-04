using Microsoft.EntityFrameworkCore;
using Store.Core.ApplicationServiceHandler;
using Store.DataAccessLayer.Repositories;
using Store.Entities.BuisnessEntities.Products.DTOs;
using Store.Entities.BuisnessEntities.Products.Entities;
using Store.Entities.BuisnessEntities.Products.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities.Products.Queries
{
    public class ProductQueryFilterGetAllHandler : BaseApplicationServiceHandler<ProductQueryFilterGetAll, List<ProductQueryFilterGetAll_DTO>, Product>
    {
        public ProductQueryFilterGetAllHandler(IGenericRepository<Product> _genericRepositori) : base(_genericRepositori)
        {
        }

        protected override async Task HandleRequest(ProductQueryFilterGetAll request, CancellationToken cancellationToken)
        {
            var result = await _genericRepository.GetAll().AsNoTracking().Select(x => new ProductQueryFilterGetAll_DTO()
            {
                ProductId = x.id,
                ProductName = x.ProductName,
                ProductImage = x.ProductName,
                Price = x.Price
            }).ToListAsync();
            if(result != null)
            {
            AddResult(result);
            }
            else
            {
                AddError("Products not found");
            }
        }
    }
}
