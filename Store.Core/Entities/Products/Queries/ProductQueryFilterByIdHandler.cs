using Microsoft.EntityFrameworkCore;
using Store.Core.ApplicationServiceHandler;
using Store.DataAccessLayer.EntitiesExtention.ProductExtention;
using Store.DataAccessLayer.Repositories;
using Store.Entities.BuisnessEntities.Products.DTOs;
using Store.Entities.BuisnessEntities.Products.Entities;
using Store.Entities.BuisnessEntities.Products.Queries;



namespace Store.Core.Entities.Products.Queries
{
    public class ProductQueryFilterByIdHandler : BaseApplicationServiceHandler<ProductQueryFilterById, ProductFilterById_DTO, Product>
    {
        public ProductQueryFilterByIdHandler(IGenericRepository<Product> _genericRepositori) : base(_genericRepositori)
        {
        }

        protected override async Task HandleRequest(ProductQueryFilterById request, CancellationToken cancellationToken)
        {
            var result = await _genericRepository.GetAll()
                .AsNoTracking().ById(request.Id).ForProductQueryResultSearchById();
              
            if(result != null)
            {
                AddResult(result);
            }
            else
            {
                AddError($"Product By Id {request.Id} Is Not Defind");
            }
        }
    }
}
