using Microsoft.AspNetCore.Identity;
using Store.Core.ApplicationServiceHandler;
using Store.Entities.BuisnessEntities.User.Commands;
using Store.Entities.BuisnessEntities.User.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities.User.Commands
{
    public class UpdateUserPasswordHandler : UserApplicationServiceHandler<UpdateUsersPassword, Users>
    {
        public UpdateUserPasswordHandler(UserManager<Users> UserManager, SignInManager<Users> signInManager) : base(UserManager, signInManager)
        {
        }

        protected override async Task HandleRequest(UpdateUsersPassword request, CancellationToken cancellationToken)
        {
            var queryResult = await _UserManager.FindByIdAsync(request.Id!);
            
            if(queryResult != null)
            {
                await _UserManager.RemovePasswordAsync(queryResult);
                var result = await _UserManager.AddPasswordAsync(queryResult, request.Password);
                if (result.Succeeded)
                {
                    AddStatus("Password succesfuly Changed");
                }
                else
                {
                    AddStatus("error in changing pass");
                }

            }
            else
            {
                AddError($"User With this id {request.Id} not found");
            }


        }
    }
}
