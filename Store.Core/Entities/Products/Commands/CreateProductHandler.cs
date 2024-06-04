using Store.Core.ApplicationServiceHandler;
using Store.DataAccessLayer.Repositories;
using Store.Entities.BuisnessEntities.Products.Commands;
using Store.Entities.BuisnessEntities.Products.Entities;

namespace Store.Core.Entities.Products.Commands
{
    public class CreateProductHandler : BaseApplicationServiceHandler<CreateProduct, Product, Product>
    {
        public CreateProductHandler(IGenericRepository<Product> _genericRepositori) : base(_genericRepositori)
        {
        }

        protected async override Task HandleRequest(CreateProduct request, CancellationToken cancellationToken)
        {
            Product product = new()
            {
                ProductName = request.ProductName,
                Description = request.Description,
                ShortDescription = request.ShortDescription,
                IsDeleted = false,
                IsExists = true,
                Price = request.Price,
                ImageName = request.ImageName
            };
            await _genericRepository.AddEntity(product);
            await _genericRepository.SaveChanges();
            AddResult(product);//add result method from baseApllicationHandler class


        }
    }
}
