using Microsoft.AspNetCore.Identity;
using Store.Core.ApplicationServiceHandler;
using Store.Entities.BuisnessEntities.User.DTOs;
using Store.Entities.BuisnessEntities.User.Entitites;
using Store.Entities.BuisnessEntities.User.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities.User.Queries
{
    public class UserQueryResultGetByIdHandler : UserApplicationServiceHandler<UserQueryResultGetById, UserQueryResultGetById_DTO>
    {
        public UserQueryResultGetByIdHandler(UserManager<Users> UserManager, SignInManager<Users> signInManager) : base(UserManager, signInManager)
        {
        }

        protected override async Task HandleRequest(UserQueryResultGetById request, CancellationToken cancellationToken)
        {
           
                var result = await _UserManager.FindByIdAsync(request.UserId);
                UserQueryResultGetById_DTO resultDTO = new()
                {
                    FullName = result!.FirstName + " " + result.LastName,
                    Email = result.Email!,
                    userName = result.UserName!
                };
                if (result != null)
                {
                    AddResult(resultDTO);
                }
                else
                {
                    AddStatus($"User By Id {request.UserId} is not defind");
                }
           
           
        }
    }
}
