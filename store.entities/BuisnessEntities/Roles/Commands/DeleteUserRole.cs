



using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.Entities.Common.ApplicationResponse;

namespace Store.Entities.BuisnessEntities.Roles.Commands
{
    public class DeleteUserRole : IRequest<ApplicationServiceResponse<IdentityRole>>
    {
        public string RoleId { get; set; } = string.Empty;



    }
}
