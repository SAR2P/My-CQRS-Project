using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public class UserQueryResultGetAllHandler : UserApplicationServiceHandler<UserQueryResultGetAll, List<UserQueryResultGetAll_DTO>>
    {
        public UserQueryResultGetAllHandler(UserManager<Users> UserManager, SignInManager<Users> signInManager) : base(UserManager, signInManager)
        {
        }

        protected override async Task HandleRequest(UserQueryResultGetAll request, CancellationToken cancellationToken)
        {
            var result = await _UserManager.Users.AsNoTracking()
                .Select(u => new UserQueryResultGetAll_DTO()
                {
                    UserId = u.Id,
                    FullName = $"{u.FirstName} {u.LastName}",
                    Email = u.Email
                }).ToListAsync();
            if (result != null)
            {
                AddResult(result);
            }
            else
            {
                AddError("User is not defind");
            }
        }
    }
}
