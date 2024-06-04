using MediatR;
using Store.Entities.BuisnessEntities.User.Entitites;
using Store.Entities.Common.ApplicationResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entities.BuisnessEntities.User.Commands
{
    public class UpdateUsersPassword : IRequest<ApplicationServiceResponse<Users>>
    {
        public string? Id { get; set; }

        public string? Password { get; set; }

    }
}
