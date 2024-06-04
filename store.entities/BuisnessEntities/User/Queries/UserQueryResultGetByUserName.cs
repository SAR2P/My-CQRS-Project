using MediatR;
using Store.Entities.BuisnessEntities.User.DTOs;
using Store.Entities.Common.ApplicationResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entities.BuisnessEntities.User.Queries
{
    public class UserQueryResultGetByUserName: IRequest<ApplicationServiceResponse<UserQueryResultGetByUserName_DTO>>
    {
        public string UserName { get; set; } = string.Empty;

    }
}
