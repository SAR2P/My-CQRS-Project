using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.Entities.Common.ApplicationResponse;

namespace Store.Entities.BuisnessEntities.Roles.Commands
{
    public class AddUserRole : IRequest<ApplicationServiceResponse<IdentityRole>>
    {
        public string? RoleName { get; set; }


    }
}
