using MediatR;
using Store.Entities.BuisnessEntities.Products.DTOs;
using Store.Entities.Common.ApplicationResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entities.BuisnessEntities.Products.Queries
{
    public class ProductQueryFilterGetAll :IRequest<ApplicationServiceResponse<List<ProductQueryFilterGetAll_DTO>>>
    {

    }
}
