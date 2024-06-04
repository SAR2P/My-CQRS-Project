using MediatR;
using Store.Entities.BuisnessEntities.User.DTOs;
using Store.Entities.Common.ApplicationResponse;


namespace Store.Entities.BuisnessEntities.User.Queries
{
    public class UserQueryResultGetAll : IRequest<ApplicationServiceResponse<List<UserQueryResultGetAll_DTO>>>
    {

    }
}
