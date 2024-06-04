using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.Entities.Common.ApplicationResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entities.BuisnessEntities.Roles.Commands
{
    public class UpdateUserRole : IRequest<ApplicationServiceResponse<IdentityRole>>
    {
        public string RoleId { get; set; } = string.Empty;

        public string RoleName { get; set; } = string.Empty;

    }
}
