using MediatR;
using Store.Entities.BuisnessEntities.Products.DTOs;
using Store.Entities.Common.ApplicationResponse;


namespace Store.Entities.BuisnessEntities.Products.Queries
{
    public class ProductQueryFilterById: IRequest<ApplicationServiceResponse<ProductFilterById_DTO>>
    {

        public long Id { get; set; }


    }
}
