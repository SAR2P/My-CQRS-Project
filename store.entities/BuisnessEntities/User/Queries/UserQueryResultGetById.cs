using MediatR;
using Store.Entities.BuisnessEntities.User.DTOs;
using Store.Entities.Common.ApplicationResponse;


namespace Store.Entities.BuisnessEntities.User.Queries
{
    public class UserQueryResultGetById: IRequest<ApplicationServiceResponse<UserQueryResultGetById_DTO>>
    {
        public string UserId { get; set; } = string.Empty;



    }
}
