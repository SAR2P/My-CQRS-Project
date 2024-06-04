

using MediatR;
using Store.Entities.BuisnessEntities.Products.DTOs;
using Store.Entities.Common.ApplicationResponse;

namespace Store.Entities.BuisnessEntities.Products.Queries
{
    public class ProductQueriFilterByProductName : IRequest<ApplicationServiceResponse<List<ProductFilterByProductName_DTO>>>
    {
        public string ProductName { get; set; }



    }
}
