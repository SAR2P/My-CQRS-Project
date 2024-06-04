using Microsoft.EntityFrameworkCore;
using Store.Core.ApplicationServiceHandler;
using Store.DataAccessLayer.EntitiesExtention.ProductExtention;
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
    public class ProductQueryFilterByProductNameHandler : BaseApplicationServiceHandler<ProductQueriFilterByProductName, List<ProductFilterByProductName_DTO>, Product>
    {
        public ProductQueryFilterByProductNameHandler(IGenericRepository<Product> _genericRepositori) : base(_genericRepositori)
        {
        }

        protected override async Task HandleRequest(ProductQueriFilterByProductName request, CancellationToken cancellationToken)
        {
            var productResult = await _genericRepository.GetAll().AsNoTracking()
                .ByProductName(request.ProductName).forProductSearchByProductName();

            AddResult(productResult);
        }
    }
}
